using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameOver : MonoBehaviour
{
    
    public static GameOver singleton;

    public Interface Interface_ref;
    public PlayerMovimentacao PlayerMovimentacao_ref;
    public CameraComLimites CameraComLimites_ref;
    public SpawnInimigo SpawnInimigo_ref;
    public SpawnarAlga SpawnarAlga_ref;
    public SpawnarGameOver spawnarGameOver_ref;
    public HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;
    public DestruirGameOver destruirGameOver_ref;
    public SpawnarTesouro spawnarTesouro_ref;


    void Awake()
    {
        PlayerMovimentacao_ref = GameObject.Find("Cascudo").GetComponent<PlayerMovimentacao>();
        Interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        CameraComLimites_ref = GameObject.Find("MainCamera").GetComponent<CameraComLimites>();
        SpawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();
        SpawnarAlga_ref = GameObject.Find("Game").GetComponent<SpawnarAlga>();
        spawnarGameOver_ref = GameObject.Find("Game").GetComponent<SpawnarGameOver>();
        habilidadesGeraisInimigo_ref = GameObject.Find("Tubarao").GetComponent<HabilidadesGeraisInimigo>();
        spawnarTesouro_ref = GameObject.Find("Game").GetComponent<SpawnarTesouro>();
        
        


        if(singleton != this && singleton != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            singleton = this;
        }
    }

}
public class StateJogador
{
    State StateJog;

    public void MudarState(State NovoState)
    {
        StateJog = NovoState;
    }
    public void Mudar()
    {
        StateJog.Mudar();
    }

}
public abstract class State //as variaveis das classes abstract não aparecem no inspector mesmo deixando elas como public?
{
    public string Name;

    public virtual void Mudar()//pq não posso usar um metodo abstarct aqui?
    {

    }
}
public class Morto : State
{
    

    


    public Morto(string NovoName)
    {
        Name = NovoName;
    }
    public override void Mudar()
    {
        if (GameOver.singleton.Interface_ref.hp<=0)
        {
            GameOver.singleton.PlayerMovimentacao_ref.speed = 0;
            GameOver.singleton.CameraComLimites_ref.speed = 0;
            GameOver.singleton.habilidadesGeraisInimigo_ref.speed = 0;
            GameOver.singleton.SpawnInimigo_ref.enabled = false; //certo?
            GameOver.singleton.SpawnarAlga_ref.enabled = false;
            GameOver.singleton.spawnarTesouro_ref.enabled = false;
            GameOver.singleton.spawnarGameOver_ref.SpawnGameOver();
        }
    }
    
}
public class Vivo : State
{
    public DestruirGameOver destruirGameOver_ref;

    void Awake()
    {
        destruirGameOver_ref = GameObject.Find("Game").GetComponent<DestruirGameOver>();
    }
    public Vivo(string NovoNome)
    {
        Name = NovoNome;
    }
    public override void Mudar()
    {
        if (GameOver.singleton.Interface_ref.hp > 0)
        {
            GameOver.singleton.PlayerMovimentacao_ref.speed = GameOver.singleton.destruirGameOver_ref.recuperarSpeedPlayer;
            GameOver.singleton.CameraComLimites_ref.speed = GameOver.singleton.destruirGameOver_ref.recuperarSpeedCamera; //aqui os colisores ja recuperariam sua velocidade tambem devido a eles herdarem a velocidade da câmera?

            GameOver.singleton.SpawnInimigo_ref.enabled = true; //certo?
            GameOver.singleton.SpawnarAlga_ref.enabled = true;
            GameOver.singleton.spawnarTesouro_ref.enabled = true;

            if (destruirGameOver_ref.tubarao.tag == "Inimigo")
            {
                GameOver.singleton.habilidadesGeraisInimigo_ref.speed = destruirGameOver_ref.recuperarSpeedTubarao; //não sei se esta certo?
            }
            if (destruirGameOver_ref.isca.tag == "Inimigo2")
            {
                GameOver.singleton.habilidadesGeraisInimigo_ref.speed = destruirGameOver_ref.recuperarSpeedIscaDePeixe; //não sei se esta certo?
            }

            


            destruirGameOver_ref.GuardarOuDestruirGameOver(destruirGameOver_ref.gameOver.gameObject);


        }
    }

}


