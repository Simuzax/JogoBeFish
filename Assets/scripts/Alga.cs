using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alga : Obstaculo
{
    SpawnarAlga spawnarAlga_ref;

    private void Awake()
    {
        spawnarAlga_ref = GameObject.Find("Game").GetComponent<SpawnarAlga>();

        tipo = TipoObstaculo.Alga;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent("ColisorDeTras"))
        {
            StartCoroutine("ReutilizarAlga");
        }
    }
    IEnumerator ReutilizarAlga()
    {
        yield return new WaitForSeconds(3);

        transform.position = spawnarAlga_ref.PosicaoAlga();

    }







}
