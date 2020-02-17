using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoControler : MonoBehaviour
{
   
    public Interface interface_ref;
    public HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;

    private void Awake()
    {
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
            habilidadesGeraisInimigo_ref.enabled = false;
        }
    }
}
