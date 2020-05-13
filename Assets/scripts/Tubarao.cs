using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubarao : Obstaculo
{
    

	private void Awake()
	{
        spawnInimigo = GameObject.Find("Game").GetComponent<SpawnInimigo>();

		tipo = TipoObstaculo.TUBARAO;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {

            Debug.Log("tubaraoAcerta");

            spawnInimigo.StopCoroutine("TubaraoObstaculo");

            var obstaculo3 = spawnInimigo.GetFromTubarao();

            if (obstaculo3 != null)
            {
                
                obstaculo3.SetActive(false);
            }
            spawnInimigo.valorObjeto = 1;
            


            //StartCoroutine("Reutilizar");
        }
    }
    /*IEnumerator Reutilizar()
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = spawnInimigo.NovaPosicao(7.0f, 15.0f);
        
    }*/
 

}