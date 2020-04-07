using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SpawnarTesouro : MonoBehaviour
{
    [SerializeField]
    private Transform Player;

    [SerializeField]
    private Transform linhaSpawnTesouro;

    

    public GameObject TesouroPrefab;

    public List<GameObject> ListTesouros = new List<GameObject>();

    [SerializeField]
    private float spawnarTesouroInicial;

    [SerializeField]
    private float spawnarTesouroMax;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        spawnarTesouroInicial += Time.deltaTime;
        if (spawnarTesouroInicial >= spawnarTesouroMax)
        {
            spawnarTesouroInicial = 0;

            Vector2 inipos = Player.transform.position;
            Vector2 Position = inipos;


            //Vector2 inipos2 = linhaSpawnTesouro.transform.position;
            //Vector2 Position2 = inipos2;




            SpawnTesouro(1, Random.Range(18, 24), Random.Range(-1, 5), Position /*Position2*/);
        }

            
        

    }
    public void SpawnTesouro(int quantidadeTesouro, float distanciaPlayerSpawnTesouro, float alturaMax, Vector2 PlayerPos /*Vector2 LinhaSpawnTesouroPos*/)                                                           
    {
        Vector2 Position = PlayerPos;
        Position.x += distanciaPlayerSpawnTesouro;
        Position.y += alturaMax;


        //Vector2 Position2 = LinhaSpawnTesouroPos;
        //Position2.y += alturaMax;
        
       

        

        for(int i=0; i < quantidadeTesouro; i++)
        {
            if (ListTesouros.Count > 0)
            {
                if (ListTesouros.OfType<Tesouro>().Any())
                {
                    int Lugar = ListTesouros.FindLastIndex(x => x.GetType() == typeof(Tesouro));
                    GameObject Tesouro = ListTesouros[Lugar];
                    ListTesouros.RemoveAt(Lugar);

                    Tesouro.transform.position = Position;
                    
                    Tesouro.SetActive(true);
                }
            }
            else
            {
                Tesouro GameObject = Instantiate(TesouroPrefab, Position, Quaternion.identity).GetComponent<Tesouro>();
                adicionarOuDestruirTesouro(this.gameObject);
            }
        }

        
    } 
    public void adicionarOuDestruirTesouro(GameObject gameObject)
    {
        if (ListTesouros.Count > 0)
        {
            ListTesouros.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
