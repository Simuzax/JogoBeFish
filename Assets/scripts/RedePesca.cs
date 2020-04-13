using UnityEngine;

public class RedePesca : Obstaculo
{
	private void Awake()
	{
		spawnInimigo = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnInimigo>();

		tipo = TipoObstaculo.ISCA;
	}
}
