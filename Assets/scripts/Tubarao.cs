using System.Collections;
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

			spawnInimigo.Reutilizacao(0.5f, 4.0f, 14.0f);

			gameObject.SetActive(false);
		}
    }
}