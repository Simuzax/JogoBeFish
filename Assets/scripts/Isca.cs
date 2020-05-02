using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Isca : Obstaculo
{
    SpawnInimigo spawnInimigo_ref; 
    
	private void Awake()
	{
		//spawnInimigo = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnInimigo>();
        spawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();
        
        
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
        yield return new WaitForSeconds(.2f);

        transform.position = spawnInimigo_ref.LinhaDeSpawn.position;
        MudarPosicao(Random.Range(1, 3), transform.position);
    }
    public void MudarPosicao(float alturaMax, Vector2 Position)
    {
        Position.y = alturaMax;
       
    }
}
