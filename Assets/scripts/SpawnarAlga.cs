using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnarAlga : MonoBehaviour
{

    public GameObject algaPrefab;

    public GameObject[] objetosObstaculosAlga;

    public const int tamanhoPool=1;

    [SerializeField]
    private Transform objectPoolTransform = null;

    private void Start()
    {
        objetosObstaculosAlga = new GameObject[tamanhoPool];

        for(int i=0; i < objetosObstaculosAlga.Length; i++)
        {
            var alga = Instantiate(algaPrefab);
            alga.transform.position = Vector3.zero;
            alga.SetActive(false);
            alga.transform.SetParent(objectPoolTransform);
            objetosObstaculosAlga[i] = alga;

            StartCoroutine("ReposicionarAlga");
        }
    }
    public GameObject GetFromAlga()
    {
        GameObject obstaculoAlga = null;
        int i = 0;

        while( i < objetosObstaculosAlga.Length)
        {
            if (!objetosObstaculosAlga[i].activeInHierarchy)
            {
                obstaculoAlga = objetosObstaculosAlga[i];
            }
            i++;
        }
        return obstaculoAlga;
    }
    public Vector2 PosicaoAlga()
    {
        Vector2 posicaoAlga;

        float EixoX = 6f;
        float EixoY = -3f;

        posicaoAlga = new Vector2(EixoX, EixoY);

        return posicaoAlga;
    }
    public void SpawnadorAlga(GameObject alga)
    {
        alga.transform.position = PosicaoAlga();
        alga.SetActive(true);
    }
    IEnumerator ReposicionarAlga()
    {
        yield return new WaitForSeconds(3);

        var objetoAlga = GetFromAlga();

        if(objetoAlga != null)
        {
            SpawnadorAlga(objetoAlga);
        }
    }

    
}
