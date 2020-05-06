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
    /*private void Start()
    {
        //StartCoroutine("RedeObstaculo");
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            StartCoroutine("Reutilizar"); 
        }
    }
    IEnumerator Reutilizar()
    {
        yield return new WaitForSeconds(3);
        transform.position = MudarPosicao();
    }

    public Vector2 MudarPosicao()
    {
        Vector2 reposicionar;

        float eixoX = spawnInimigo.LinhaDeSpawn.position.x;
        float eixoY = Random.Range(4.0f, 14.0f);

        reposicionar = new Vector2(eixoX, eixoY);

        return reposicionar;
    }
    /*IEnumerator RedeObstaculo()
    {
        yield return new WaitForSeconds(3);

        var inimigo2 = spawnInimigo.GetFromRede();


        if(inimigo2 != null)
        {
            spawnInimigo.SpawnObstaculo(inimigo2, 8.0f, 14.0f);
        }
    }*/
}
