using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SpawnarTesouro : MonoBehaviour
{
    public bool contarTempo = false;

    public Transform LinhaSpawnTesouro;

    GameObject[] objetosObstaculosTesouro;

    public GameObject TesouroPrefab;

    private const int tamanhoPool = 3;

   

    [SerializeField]
    private Transform objectPoolTransform = null;

    private void Start()
    {
        objetosObstaculosTesouro = new GameObject[tamanhoPool];

        for(int i=0; i < objetosObstaculosTesouro.Length; i++)
        {
            var obstaculo = Instantiate(TesouroPrefab);
            obstaculo.transform.position = Vector2.zero;
            obstaculo.SetActive(false);
            objetosObstaculosTesouro[i] = obstaculo;

            obstaculo.transform.SetParent(objectPoolTransform);
        }
        StartCoroutine("ReposicionarTesouro");
    }
    public GameObject GetFromTesouro()
    {
        GameObject Tesouro = null;
        int i = 0;

        while(i < objetosObstaculosTesouro.Length)
        {
            if (!objetosObstaculosTesouro[i].activeInHierarchy)
            {
                Tesouro = objetosObstaculosTesouro[i];
            }
            i++; //se coloca o i++ aqui em baixo por que é assim q o while funciona? 
        }
        return Tesouro;
    }
    public void SpawnTesouro(GameObject tesouro, float minimo, float maximo)
    {
        tesouro.transform.position = PosicaoTesouro(minimo, maximo);
        tesouro.SetActive(true);
    }


    public Vector2 PosicaoTesouro(float minimo,float maximo)
    {
        Vector2 reposicionamento;

        float eixoX = LinhaSpawnTesouro.position.x;
        float eixoY = Random.Range(minimo, maximo);

        reposicionamento = new Vector2(eixoX, eixoY);

        return reposicionamento;
    }
    IEnumerator ReposicionarTesouro()
    {
        yield return new WaitForSeconds(2);

        var tesouro = GetFromTesouro();

        if(tesouro != null)
        {
            SpawnTesouro(tesouro, 2.0f, 17.0f);
        }
    }
    public void reutilizarTesouro(float tempoTotal, float maximo,float minimo)
    {
        var tesouro = GetFromTesouro();

        if (tesouro != null)
        {
            StartCoroutine(Contagem(tempoTotal, tesouro, maximo, minimo));
        }
    }

    IEnumerator Contagem(float TempoTotal,GameObject tesouro, float maximo, float minimo)
    {
        
        contarTempo = true; // aqui é obrigado usar a buleana contarTempo? não vejo a necessidade, sendo que não é utilizada com if  
        float tempo = 0;

        while (tempo < TempoTotal)
        {
            tempo += Time.deltaTime;
            yield return null;
        }
        SpawnTesouro(tesouro, maximo, minimo);
        contarTempo = false;
    }
    

    






}
