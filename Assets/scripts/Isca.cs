using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Isca : Obstaculo
{
     
    
	private void Awake()
	{
        
        spawnInimigo = GameObject.Find("Game").GetComponent<SpawnInimigo>();
        
        
		tipo = TipoObstaculo.ISCA;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            gameObject.SetActive(false);
            /*var obstaculo1 = spawnInimigo.GetFromIsca();

            if(obstaculo1 != null)
            {
                
                obstaculo1.SetActive(false);
            }
            //StartCoroutine("Reposicionador");*/


        }
    }
    
    /*IEnumerator Reposicionador()
    {
        yield return new WaitForSeconds(2);

        transform.position = spawnInimigo.NovaPosicao(7.0f, 15.0f);
    }*/
    

   
}
