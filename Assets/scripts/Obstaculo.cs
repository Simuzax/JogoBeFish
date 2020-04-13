using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoObstaculo
{
	TUBARAO, ISCA, REDE
};

public class Obstaculo : MonoBehaviour
{
	protected SpawnInimigo spawnInimigo;

	public TipoObstaculo tipo { get; protected set; }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log(gameObject.name + " colidiu com " + collision.name);
	}
}
