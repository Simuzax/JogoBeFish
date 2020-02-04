using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacandoPeixes : MonoBehaviour
{
    
    HabilidadesGeraisInimigo habilidadesGeraisInimigo;

    
    HabilidadesGeraisPlayer habilidadesGeraisPlayer_ref;


    // Start is called before the first frame update
    void Awake()
    {
        habilidadesGeraisInimigo = GetComponent<HabilidadesGeraisInimigo>();

        habilidadesGeraisPlayer_ref = GameObject.Find("piranhaA").GetComponent<HabilidadesGeraisPlayer>();          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Debug.Log("acertou");

            habilidadesGeraisPlayer_ref.Damage(habilidadesGeraisInimigo.strength);

           
        }
    }
}
