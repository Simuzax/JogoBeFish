using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubarao : Obstaculo
{
	private void Awake()
	{
		spawnInimigo = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnInimigo>();

		tipo = TipoObstaculo.TUBARAO;
	}
}