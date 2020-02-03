using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class SpawnarGhost : MonoBehaviour
{
   

    
   

    public GameObject ghostPrefab;

    [SerializeField]
    GhostPiranha spectre;

    List<GameObject> ListGhost = new List<GameObject>();

    public Transform Player_;

    private float spawnFantasmaInicial1;
    [SerializeField]
    private float spawnFantasmaFinal1;

    private float spawnFantasmaInicial2;
    [SerializeField]
    private float spawnFantasmaFinal2;

    private float spawnFantasmaInicial3;
    [SerializeField]
    private float spawnFantasmaFinal3;

    private float spawnFantasmaInicial4;
    [SerializeField]
    private float spawnFantasmaFinal4;

    [SerializeField]
    private float destruirFantasmaInicial;

    [SerializeField]
    private float destruirFantasmaFinal;

   


    public int carregar = 0;





    public float ghostDelay;
    public float ghostDelaySeconds;

    public bool makeGhost = false;







    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    // Update is called once per frame
    void Update()
    {


        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                GameObject currentGhost = Instantiate(ghostPrefab, transform.position, transform.rotation);
                ghostDelaySeconds = ghostDelay;
            }

        }


       

        

        if (Time.time >= spawnFantasmaInicial1 + spawnFantasmaFinal1 && Input.GetKey(KeyCode.Space) && carregar == 0)
        {

            

            spawnFantasmaInicial1 = Time.time;
            carregar++;

            Vector2 inicialPos = Player_.transform.position;
            Vector2 Position = inicialPos;

            SpawnarFantasmas(1,Position);
            clickDirecao();
        }
        

        if (Time.time >= spawnFantasmaInicial2 + spawnFantasmaFinal2 && carregar == 1)
        {

            

            spawnFantasmaInicial2 = Time.time;
            carregar++;



            Vector2 iniPos = Player_.transform.position;
            Vector2 Position = iniPos;

            SpawnarFantasmas(1, Position);
            ProximaPosicao();

        }
        

        if (Time.time >= spawnFantasmaInicial3 + spawnFantasmaFinal3 && carregar == 2)
        {

            


            spawnFantasmaInicial3 = Time.time;
            carregar++;




            Vector2 iniPos = Player_.transform.position;
            Vector2 Position = iniPos;
            SpawnarFantasmas(1, Position);
            ProximaPosicao2();


        }
        

        if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
        {


            spawnFantasmaInicial4 = Time.time;
            carregar = 0;



            Vector2 iniPos = Player_.transform.position;
            Vector2 Position = iniPos;
            SpawnarFantasmas(1, Position);
            ProximaPosicao3();

            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                Position.x = 0;
                Position.y = 0;
            }


        }

        /*destruirFantasmaInicial += Time.deltaTime;
        if(destruirFantasmaInicial>=destruirFantasmaFinal)
        {
            GhostPiranhaAdicionarOuDestruir(spectre.gameObject);
            destruirFantasmaInicial = 0;
        }*/

        










    }
    public void GhostPiranhaAdicionarOuDestruir(GameObject gameObject)
    {
        if (ListGhost.Count > 0)
        {
            ListGhost.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void clickDirecao()
    {
        Vector2 Position = Player_.transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
           Position.x += -0.5f;
           Position.y += 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Position.x += 0.5f;
            Position.y += 0;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Position.x += 0;
            Position.y += -0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Position.x += 0;
            Position.y += 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            Position.x += -0.5f;
            Position.y += -0.5f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            Position.x += 0.5f;
            Position.y += -0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            Position.x += -0.5f;
            Position.y += 0.5f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            Position.x += 0.5f;
            Position.y += 0.5f;
        }
        


    }
    public void ProximaPosicao()
    {
        Vector2 Position = Player_.transform.position;

        if (Position.x < Position.y && Position.x == -0.5f && Position.y==0)
        {
            Position.x += -1;
            Position.y += 0;
        }
        if (Position.x > Position.y && Position.x == 0.5f && Position.y==0)
        {
            Position.x += 1;
            Position.y += 0;
        }
        if (Position.x > Position.y && Position.x == 0 && Position.y == -0.5f)
        {
            Position.x += 0;
            Position.y += 1;
        }
        if (Position.x < Position.y && Position.x == 0 && Position.y == 0.5f)
        {
            Position.x += 0;
            Position.y += 1;
        }
        if (Position.x == Position.y && Position.x == -0.5f && Position.y == -0.5f)
        {
            Position.x += -1;
            Position.y += -1;
        }
        if (Position.x > Position.y && Position.x == 0.5 && Position.y == -0.5f)
        {
            Position.x += 1;
            Position.y += -1;
        }
        if (Position.x > Position.y && Position.x == -0.5 && Position.y == 0.5f)
        {
            Position.x += -1;
            Position.y += 1;
        }
        if (Position.x == Position.y && Position.x == 0.5f && Position.y == 0.5f)
        {
            Position.x += 1;
            Position.y += 1;
        }


    }
    public void ProximaPosicao2()
    {
        Vector2 Position = Player_.transform.position;

        if (Position.x < Position.y && Position.x == -1 && Position.y == 0)
        {
            Position.x += -1.5f;
            Position.y += 0;
        }
        if (Position.x > Position.y && Position.x == 1 && Position.y == 0)
        {
            Position.x += 1.5f;
            Position.y += 0;
        }
        if (Position.x > Position.y && Position.x == 0 && Position.y == -1)
        {
            Position.x += 0;
            Position.y += 1.5f;
        }
        if (Position.x < Position.y && Position.x == 0 && Position.y == 1)
        {
            Position.x += 0;
            Position.y += 1.5f;
        }
        if (Position.x == Position.y && Position.x == -1 && Position.y == -1)
        {
            Position.x += -1.5f;
            Position.y += -1.5f;
        }
        if (Position.x > Position.y && Position.x == 1 && Position.y == -1f)
        {
            Position.x +=  1.5f;
            Position.y += -1.5f;
        }
        if (Position.x > Position.y && Position.x == -1 && Position.y == 1)
        {
            Position.x += -1.5f;
            Position.y +=  1.5f;
        }
        if (Position.x == Position.y && Position.x == 1 && Position.y == 1)
        {
            Position.x += 1.5f;
            Position.y += 1.5f;
        }


    }
    public void ProximaPosicao3()
    {
        Vector2 Position = Player_.transform.position;

        if (Position.x < Position.y && Position.x == -1.5f && Position.y == 0)
        {
            Position.x += -2;
            Position.y +=  0;
        }
        if (Position.x > Position.y && Position.x == 1.5f && Position.y == 0)
        {
            Position.x += 2;
            Position.y += 0;
        }
        if (Position.x > Position.y && Position.x == 0 && Position.y == -1.5f)
        {
            Position.x += 0;
            Position.y += 2;
        }
        if (Position.x < Position.y && Position.x == 0 && Position.y == 1.5f)
        {
            Position.x += 0;
            Position.y += 2;
        }
        if (Position.x == Position.y && Position.x == -1.5f && Position.y == -1.5f)
        {
            Position.x += -2;
            Position.y += -2;
        }
        if (Position.x > Position.y && Position.x == 1.5f && Position.y == -1.5f)
        {
            Position.x +=  2;
            Position.y += -2;
        }
        if (Position.x > Position.y && Position.x == -1.5f && Position.y == 1.5f)
        {
            Position.x += -2;
            Position.y +=  2;
        }
        if (Position.x == Position.y && Position.x == 1.5f && Position.y == 1.5f)
        {
            Position.x += 2;
            Position.y += 2;
        }


    }

    public void SpawnarFantasmas(int QuantidadeFantasmas, Vector2 initialpos)
    {
        
        Vector2 Position = initialpos;
       






        for (int i=0; i < QuantidadeFantasmas; i++)
        {
            if (ListGhost.Count > 0)
            {
                if (ListGhost.OfType<GhostPiranha>().Any())
                {
                    int objeto = ListGhost.FindLastIndex(x => x.GetType() == typeof(GhostPiranha));

                    GameObject ghost = ListGhost[objeto];
                    ListGhost.RemoveAt(objeto);

                    ghost.transform.position = Position;
                    ghost.SetActive(true);

                    
                }
            }
            else
            {
                GhostPiranha GameObject = Instantiate(ghostPrefab, Position, Quaternion.identity).GetComponent<GhostPiranha>();
            }
        } 
    }
    
    
    
}    

