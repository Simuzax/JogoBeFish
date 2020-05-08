using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rede : Obstaculo
{
    private void Awake()
    {
        spawnInimigo = GameObject.Find("Game").GetComponent<SpawnInimigo>();

        tipo = TipoObstaculo.REDE;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            StartCoroutine("Reutilizar"); 
        }
    }
    IEnumerator Reutilizar()
    {
        yield return new WaitForSeconds(2);
        transform.position = spawnInimigo.NovaPosicao(4.0f, 14.0f);
    }

    
    
}
