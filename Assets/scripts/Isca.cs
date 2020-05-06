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
        if (collision.gameObject.CompareTag ("ColisorDeTras"))
        {
            StartCoroutine("Reposicionador");
            
           
        }
    }
    
    IEnumerator Reposicionador()
    {
        yield return new WaitForSeconds(2);

        transform.position = NovaPosicao();
        
        
    }
    public Vector2 NovaPosicao()
    {
        Vector2 posicaoAleatoria;

        float EixoX = spawnInimigo.LinhaDeSpawn.position.x;
        float EixoY = Random.Range(4.0f, 14.0f);

        posicaoAleatoria = new Vector2(EixoX, EixoY);
        

        return posicaoAleatoria;
    }

   
}
