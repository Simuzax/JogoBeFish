﻿using System.Collections;
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
            //StartCoroutine("Reutilizar");
            var obstaculo2 = spawnInimigo.GetFromRede();
            
            if(obstaculo2 != null)
            {
                obstaculo2.SetActive(false);
            }

        }
    }
    /*IEnumerator Reutilizar()
    {
        yield return new WaitForSeconds(2);
        transform.position = spawnInimigo.NovaPosicao(7.0f, 15.0f);

        
    }*/

    
    
}
