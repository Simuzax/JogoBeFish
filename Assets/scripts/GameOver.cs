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



    void Awake()
    {
        PlayerMovimentacao_ref = GameObject.Find("Cascudo").GetComponent<PlayerMovimentacao>();
        Interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        CameraComLimites_ref = GameObject.Find("MainCamera").GetComponent<CameraComLimites>();
        SpawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();
        SpawnarAlga_ref = GameObject.Find("Game").GetComponent<SpawnarAlga>();
        spawnarGameOver_ref = GetComponent<SpawnarGameOver>(); 


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
public abstract class State
{
    public string Name;

    public virtual void Mudar()
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
            GameOver.singleton.SpawnInimigo_ref.enabled = false; //certo?
            GameOver.singleton.SpawnarAlga_ref.enabled = false;
            //GameOver.singleton.spawnarGameOver_ref.SpawnGameOver();
        }
    }
    
}
public class Vivo : State
{
    public int recuperarSpeedPlayer;
    public int recuperarSpeedCameraColisores;
    public Vivo(string NovoNome)
    {
        Name = NovoNome;
    }
    public override void Mudar()
    {
        if (GameOver.singleton.Interface_ref.hp > 0)
        {
            GameOver.singleton.PlayerMovimentacao_ref.speed = recuperarSpeedPlayer;
            GameOver.singleton.CameraComLimites_ref.speed = recuperarSpeedCameraColisores;
            GameOver.singleton.SpawnInimigo_ref.enabled = true; //certo?
            GameOver.singleton.SpawnarAlga_ref.enabled = true;
            
        }
    }

}
public class SpawnarGameOver
{
    public Transform ColisorDaFrente;

    public GameObject GameOverPrefab;

    public void SpawnGameOver()
    {
        Vector2 IniPos = ColisorDaFrente.transform.position;
        Vector2 Position = IniPos;
        Position.x = 5;
        Position.y = 5;

        GameObject fo = 
    }
}

