﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControler : MonoBehaviour
{

    BarraDeVida barraDeVida_ref;
    //public HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;
    SpawnInimigo spawnInimigo_ref;

    private void Awake()
    {
        spawnInimigo_ref = GetComponent<SpawnInimigo>();
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();  
        //habilidadesGeraisInimigo_ref = GameObject.Find("Tubarao").GetComponent<HabilidadesGeraisInimigo>();
    }

    private void Start()
    {
        barraDeVida_ref.OnPlayerDeath += DesativarControleInimigo; //aqui ja esta adicionado a função desde o começo do jogo 
    }
    
    //Essa função é chamada quando o evento "OnPlayerDeath()" é disparado, no Script Interface
    public void DesativarControleInimigo()
    {
        Debug.Log("Chamando função DesativarControleInimigo() em " + gameObject.name);

        //if (interface_ref.hp <= 0)                                             
        //{                                                                             //vetor e array é a mesma coisa? 
                                                                                            //aqui deve-se transformar a lista pq fica mais facil de percorer o vetor

            Debug.Log("Tamanho do vetor: " + spawnInimigo_ref.objetosObstaculosIsca.Length);
                                                                                                   
            if (spawnInimigo_ref.objetosObstaculosIsca.Length > 0) // verifica se tem objetos no array                      
            {
                for(int i = 0; i < spawnInimigo_ref.objetosObstaculosIsca.Length; i++)  //o i é um contador                          //aqui vai rodar cada objeto na lista
                {                                                                             
                    Debug.Log("Valor de i: " + i);

                    spawnInimigo_ref.objetosObstaculosIsca[i].GetComponent<HabilidadesGeraisInimigo>().enabled=false; //aqui no caso todos os da ListInimigosVivos tem essa classe?// 
                }
            }
        //}
    }

    private void OnDisable()
    {
        barraDeVida_ref.OnPlayerDeath -= DesativarControleInimigo; //em que parte esta função é acionada? 
    }

}
