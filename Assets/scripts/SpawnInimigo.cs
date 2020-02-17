using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnInimigo : MonoBehaviour
{
    [SerializeField]
    Isca isca;

    [SerializeField]
    RedePesca redePesca;

    [SerializeField]
    Tubarao tubarao;

    [SerializeField]
    private Transform LinhaDeSpawn;

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
    private Transform player_ref;

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

    


    List<GameObject> ListInimigos = new List<GameObject>();
    List<GameObject> ListInimigosVivos = new List<GameObject>();
    
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

        


        //spawnarIscaInicial += Time.deltaTime;
        //if(spawnarIscaInicial >= spawnarIscaMax)
        //{
            //spawnarIscaInicial = 0;
         if(Time.time >= spawnarIscaInicial+spawnarIscaMax)
         {
            spawnarIscaInicial = Time.time;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            //position.x += distanceEnemyFromPlayer;

            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;


            SpawnarInimigos<Isca>(1, 18, Random.Range(-1, 5), position, position2);
         } 

           
            
        
        

        //acelerarIscaSpawninicial += Time.deltaTime;
        //if (acelerarIscaSpawninicial >= acelerarIscaSpawnMax && novoValor == true && antigoValor == false)
        //{
            //acelerarIscaSpawninicial = 0;
         if(Time.time>= acelerarIscaSpawninicial + acelerarIscaSpawnMax && novoValor==true && antigoValor == false)
         {
            acelerarIscaSpawninicial = Time.time;

            spawnarIscaInicial -= maisIscas;
            spawnarIscaMax -= maisIscas;

            antigoValor = true;
         }
            

        
        //desacelerarIscaSpawnInicial += Time.deltaTime;
        //if (desacelerarIscaSpawnInicial >= desacelerarIscaSpawnMax && novoValor == true && antigoValor == true)
        //{
            //desacelerarIscaSpawnInicial = 0;

         if(Time.time>=desacelerarIscaSpawnInicial+desacelerarIscaSpawnMax && novoValor==true && antigoValor == true)
         {
            desacelerarIscaSpawnInicial = Time.time;

            spawnarIscaInicial += menosIscas;
            spawnarIscaMax += menosIscas;

            novoValor = false;
            antigoValor = false;
        }
            

        
        //reacelerarIscaSpawnInicial += Time.deltaTime;
        //if (reacelerarIscaSpawnInicial >= reacelerarIscaSpawnMax && novoValor == false && antigoValor == false)
        //{
            //reacelerarIscaSpawnInicial = 0;

        if(Time.time>=reacelerarIscaSpawnInicial+reacelerarIscaSpawnMax && novoValor==false && antigoValor == true)
        {
            reacelerarIscaSpawnInicial = Time.time;

            spawnarIscaInicial -= maisIscas2;
            spawnarIscaMax -= maisIscas2;

            novoValor = true;
            antigoValor = true;
        }
            
        




        spawnarTubaraoInicial += Time.deltaTime;
        if(spawnarTubaraoInicial>=spawnarTubaraoMax)
        {
            spawnarTubaraoInicial = 0;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            //position.x += distanceEnemyFromPlayer;
            
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            

            SpawnarInimigos<Tubarao>(1, 18, Random.Range(-1, 5), position, position2);

            
        }

        
        spawnarRedePescaInicial += Time.deltaTime;
        if(spawnarRedePescaInicial>=spawnarRedePescaMax)
        {
            spawnarRedePescaInicial = 0;

            Vector2 initialPos = player_ref.transform.position;
            Vector2 position = initialPos;
            //position.x += distanceEnemyFromPlayer; 
            
            Vector2 initialPosLinha = LinhaDeSpawn.transform.position;
            Vector2 position2 = initialPosLinha;
            




            SpawnarInimigos<RedePesca>(1, 18, Random.Range(-1, 5), position, position2);

            
        }
    }
    public void SpawnarInimigos<Y>(int quantidadeIinimigos, float distanceMax, float heightMax, Vector2 initialPos, Vector2 initialPos2)
    {
       

            
            
              
                Vector2 position = initialPos;
                position.x += distanceMax;                                                           


                Vector2 position2 = initialPos2;
                position2.y += heightMax;                                               //Random.Range(-1,5);

        for (int i = 0; i < quantidadeIinimigos; i++)
        {

            if (ListInimigos.Count > 0)
            {
                if (typeof(Y) == typeof(Isca))
                {
                    if (ListInimigos.OfType<Isca>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Isca));

                        GameObject Isca = ListInimigos[possicao];
                        ListInimigos.RemoveAt(possicao);




                        Isca.transform.position = position;
                        Isca.SetActive(true);


                    }
                }
                else if (typeof(Y) == typeof(RedePesca))
                {
                    if (ListInimigos.OfType<RedePesca>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(RedePesca));

                        GameObject RedePesca = ListInimigos[possicao];

                        ListInimigos.RemoveAt(possicao);



                        RedePesca.transform.position = position;
                        RedePesca.SetActive(true);


                    }
                }
                else if (typeof(Y) == typeof(Tubarao))
                {
                    if (ListInimigos.OfType<Tubarao>().Any())
                    {
                        int possicao = ListInimigos.FindLastIndex(x => x.GetType() == typeof(Tubarao));

                        GameObject tubarao = ListInimigos[possicao];
                        ListInimigos.RemoveAt(possicao);



                        tubarao.transform.position = position;
                        tubarao.SetActive(true);

                    }
                }
            }
            else
            {
                if (typeof(Y) == typeof(Isca))
                {
                    Isca GameObject = Instantiate(iscaPrefab, position, Quaternion.identity).GetComponent<Isca>();
                    ListInimigosVivos.Add(isca.gameObject);
                }
                if (typeof(Y) == typeof(Tubarao))
                {
                    Tubarao GameObject = Instantiate(tubaraoPrefab, position, Quaternion.identity).GetComponent<Tubarao>();
                    ListInimigosVivos.Add(tubarao.gameObject);
                }
                if (typeof(Y) == typeof(RedePesca))
                {
                    RedePesca GameObject = Instantiate(redeDePescaPrefab, position, Quaternion.identity).GetComponent<RedePesca>();
                    ListInimigosVivos.Add(redePesca.gameObject);
                }
            }

        }
                
            
        
    }
    public void adicionarOuDestruir(GameObject gameObject)                                         
    {
             
        if (ListInimigos.Count > 0)
        {
            ListInimigos.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
  
   



}
