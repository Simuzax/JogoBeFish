using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnInimigo : MonoBehaviour
{
    
    public Transform LinhaDeSpawn;

    public GameObject tubaraoPrefab;
    public GameObject iscaPrefab;
    public GameObject redeDePescaPrefab;

    [SerializeField]
    private float spawnarIscaInicial;

    [SerializeField]
    private float spawnarIscaMax;

    [SerializeField]
    private float spawnarTubaraoInicial;

    [SerializeField]
    private float spawnarTubaraoMax;

    [SerializeField]
    private float spawnarRedePescaInicial;

    [SerializeField]
    private float spawnarRedePescaMax;

    [SerializeField]
    float distanceEnemyFromPlayer;

    [SerializeField]
    private Transform Camera;

    [SerializeField]
    private float acelerarIscaSpawninicial;

    [SerializeField]
    private float acelerarIscaSpawnMax;

    [SerializeField]
    private float desacelerarIscaSpawnInicial;

    [SerializeField]
    private float desacelerarIscaSpawnMax;

    [SerializeField]
    private float reacelerarIscaSpawnInicial;

    [SerializeField]
    private float reacelerarIscaSpawnMax;

    [SerializeField]
    private float maisIscas;

    [SerializeField]
    private float menosIscas;

    [SerializeField]
    private float maisIscas2;


    public bool novoValor=true;
    public bool antigoValor=false;

    


    public List<Obstaculo> ListInimigos = new List<Obstaculo>();
    public List<GameObject> ListInimigosVivos = new List<GameObject>();
   

    // Update is called once per frame
    void Update()
    {

        


         

           
            
        
        

       
         if(Time.time>= acelerarIscaSpawninicial + acelerarIscaSpawnMax && novoValor==true && antigoValor == false)
         {
            acelerarIscaSpawninicial = Time.time;

            spawnarIscaInicial -= maisIscas;
            spawnarIscaMax -= maisIscas;

            antigoValor = true;
         }
            

        
        

         if(Time.time>=desacelerarIscaSpawnInicial+desacelerarIscaSpawnMax && novoValor==true && antigoValor == true)
         {
            desacelerarIscaSpawnInicial = Time.time;

            spawnarIscaInicial += menosIscas;
            spawnarIscaMax += menosIscas;

            novoValor = false;
            antigoValor = false;
        }
            

        
      

        if(Time.time>=reacelerarIscaSpawnInicial+reacelerarIscaSpawnMax && novoValor==false && antigoValor == true)
        {
            reacelerarIscaSpawnInicial = Time.time;

            spawnarIscaInicial -= maisIscas2;
            spawnarIscaMax -= maisIscas2;

            novoValor = true;
            antigoValor = true;
        }


        spawnarIscaInicial += Time.deltaTime;
        if (spawnarIscaInicial>=spawnarIscaMax)
        {
            spawnarIscaInicial = 0;

            Vector2 position = LinhaDeSpawn.transform.position;


            SpawnarInimigos<Isca>(1, Random.Range(-1, 5), position);
        }




        spawnarTubaraoInicial += Time.deltaTime;
        if(spawnarTubaraoInicial>=spawnarTubaraoMax)
        {
            spawnarTubaraoInicial = 0;

            Vector2 position = LinhaDeSpawn.transform.position;
            
            SpawnarInimigos<Tubarao>(1, Random.Range(-1, 5), position);

            
        }

        
        spawnarRedePescaInicial += Time.deltaTime;
        if(spawnarRedePescaInicial>=spawnarRedePescaMax)
        {
            spawnarRedePescaInicial = 0;

            Vector2 position = LinhaDeSpawn.transform.position;
            
          
            
            SpawnarInimigos<RedePesca>(1, Random.Range(-1, 5), position);

            
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, float heightMax, Vector2 Position)
    {
       
                                                                          
        Position.y = heightMax;

        Obstaculo[] inimigosArray = ListInimigos.ToArray();                                                

        for (int i = 0; i < inimigosArray.Length; i++)
        {
            if (typeof(Y) == typeof(Isca))
            {
                GameObject isca = Instantiate(iscaPrefab, Position, Quaternion.identity);
                var script = isca.GetComponent<Isca>();

                ListInimigos.Add(script);
                //AdicionarOuDestruir(script);
            }
            if (typeof(Y) == typeof(Tubarao))
            {
                Tubarao tubarao = Instantiate(tubaraoPrefab, Position, Quaternion.identity).GetComponent<Tubarao>();
                var script = tubarao.GetComponent<Tubarao>();

                ListInimigos.Add(script);
                //AdicionarOuDestruir(tubarao);
            }
            if (typeof(Y) == typeof(RedePesca))
            {
                RedePesca rede = Instantiate(redeDePescaPrefab, Position, Quaternion.identity).GetComponent<RedePesca>();
                var script = rede.GetComponent<RedePesca>();

                ListInimigos.Add(script);
                //AdicionarOuDestruir(rede);
            }

            /*if (ListInimigos.Count > 0)
            {
                if (typeof(Y) == typeof(Isca))
                {
                    if (ListInimigos.OfType<Isca>().Any())
                    {
                        int posicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Isca));

                        Obstaculo Isca = ListInimigos[posicao];

                        ListInimigos.RemoveAt(posicao);

                        Isca.transform.position = position;

						Isca.gameObject.SetActive(true);
                    }
                }
                else if (typeof(Y) == typeof(RedePesca))
                {
                    if (ListInimigos.OfType<RedePesca>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(RedePesca));

                        Obstaculo RedePesca = ListInimigos[possicao];

                        ListInimigos.RemoveAt(possicao);

                        RedePesca.transform.position = position;

						RedePesca.gameObject.SetActive(true);
                    }
                }
                else if (typeof(Y) == typeof(Tubarao))
                {
                    if (ListInimigos.OfType<Tubarao>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Tubarao));

                        Obstaculo tubarao = ListInimigos[possicao];

                        ListInimigos.RemoveAt(possicao);

                        tubarao.transform.position = position;

						tubarao.gameObject.SetActive(true);
                    }
                }
            }*/
            //else
            //{

            //}
        }            
    }

    public void AdicionarOuDestruir(Obstaculo obstaculo)                                         
    {       
        if (ListInimigos.Count > 0)
        {
            ListInimigos.Add(obstaculo);
        }
        else
        {
            Destroy(obstaculo);
        }
    }
}
