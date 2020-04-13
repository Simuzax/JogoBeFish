using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isca : Obstaculo
{
	private void Awake()
	{
		spawnInimigo = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnInimigo>();

		tipo = TipoObstaculo.ISCA;
	}
}
