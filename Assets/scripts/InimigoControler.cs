using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControler : MonoBehaviour
{
   
    public Interface interface_ref;
    public HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;
    SpawnInimigo spawnInimigo_ref;

    private void Awake()
    {
        spawnInimigo_ref = GetComponent<SpawnInimigo>();
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        habilidadesGeraisInimigo_ref = GameObject.Find("Tubarao").GetComponent<HabilidadesGeraisInimigo>();
    }

    void Update()
    {
        desativarControleInimigo();
    }
    public void desativarControleInimigo()
    {
        if (interface_ref.hp <= 0)
        {
            GameObject[] inimigosArray = spawnInimigo_ref.ListInimigosVivos.ToArray();

            if (inimigosArray.Length > 0) // verifica se tem objetos no array
            {
                for(int i=0;i> inimigosArray.Length; i++)
                {
                    inimigosArray[i].GetComponent<HabilidadesGeraisInimigo>().enabled=false;
                }
            }
        }
    }
}
