using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public Player Personagem;


    BarraDeVida barraDeVida_ref;
    public SpawnInimigo spawnInimigo_ref;
    public SpawnarAlga spawnarAlga_ref;
    public SpawnarGhost spawnarGhost_ref;
    public SpawnarTesouro spawnarTesouro_ref;
   

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        spawnInimigo_ref = GetComponent<SpawnInimigo>();
        spawnarAlga_ref = GetComponent<SpawnarAlga>();
        spawnarGhost_ref = GetComponent<SpawnarGhost>();
        spawnarTesouro_ref = GetComponent<SpawnarTesouro>();
    }
    void Update()
    {
        DesabilitarControlesGame();
    }
    public void DesabilitarControlesGame()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            spawnInimigo_ref.enabled = false;
            spawnarAlga_ref.enabled = false;
            spawnarGhost_ref.enabled = false;
            spawnarTesouro_ref.enabled = false;
        }
    }
}
