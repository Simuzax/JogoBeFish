using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class AtacandoPeixes : MonoBehaviour
{
    
    HabilidadesGeraisInimigo habilidadesGeraisInimigo_ref;

    CascudoArmadura cascudoArmadura_ref;

    public Cascudo cascudo;

    // Start is called before the first frame update
    void Awake()
    {
        habilidadesGeraisInimigo_ref = GetComponent<HabilidadesGeraisInimigo>();

        if (cascudo.gameObject.activeInHierarchy == true)
        {
            cascudoArmadura_ref = GameObject.Find("Cascudo").GetComponent<CascudoArmadura>();
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piranha"))
        {
            habilidadesGeraisInimigo_ref.CausarDano(collision.GetComponent<Player>());
        }
        if (collision.gameObject.CompareTag("Cascudo"))
        {
            if (cascudoArmadura_ref.armadura == true && cascudoArmadura_ref.intervaloDeColisao == false)
            {

                cascudoArmadura_ref.intervaloDeColisao = true;
                cascudoArmadura_ref.armadura = false;



            }
            if (cascudoArmadura_ref.armadura == false && cascudoArmadura_ref.intervaloDeColisao == true)
            {

                habilidadesGeraisInimigo_ref.CausarDano(collision.GetComponent<Player>());
                Debug.Log("acertou");
                cascudoArmadura_ref.intervaloDeColisao = false;

            }

        }
    }
}
