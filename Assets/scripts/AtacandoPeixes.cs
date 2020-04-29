using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class AtacandoPeixes : MonoBehaviour
{
    
    HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;
 
    
    


    // Start is called before the first frame update
    void Awake()
    {
        habilidadesGeraisInimigo_ref = GetComponent<HabilidadesGeraisInimigo>();

                  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            Debug.Log("mordida");
            habilidadesGeraisInimigo_ref.CausarDano(collision.GetComponent<Player>());

           
        }
    }*/
}
