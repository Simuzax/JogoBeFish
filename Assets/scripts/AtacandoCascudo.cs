using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacandoCascudo : MonoBehaviour
{
    

    
    CascudoArmadura cascudoArmadura_ref;

    
    HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;

    


    private void Awake()
    {
        habilidadesGeraisInimigo_ref = GetComponent<HabilidadesGeraisInimigo>();
        cascudoArmadura_ref = GameObject.Find("Cascudo").GetComponent<CascudoArmadura>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (cascudoArmadura_ref.armadura == true && cascudoArmadura_ref.intervaloDeColisao==false)
            {

                cascudoArmadura_ref.intervaloDeColisao = true;
                cascudoArmadura_ref.armadura = false;
                


            }
            if (cascudoArmadura_ref.armadura == false && cascudoArmadura_ref.intervaloDeColisao==true)                       
            {
                
                habilidadesGeraisInimigo_ref.CausarDano(collision.GetComponent<Player>());
                Debug.Log("acertou");
                cascudoArmadura_ref.intervaloDeColisao = false;
                
            }
            
        }
    }
   
}
