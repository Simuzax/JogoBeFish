using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class Ghost : MonoBehaviour
{
    Ghost ghost_;

    public List<GameObject> ListGhost = new List<GameObject>();

    public Transform Player_;

   

    public float ghostDelay;
    public float ghostDelaySeconds;
    public GameObject ghost;
    public bool makeGhost=false;

    

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

    public int carregar = 0;


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
                    GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
                    ghostDelaySeconds = ghostDelay;
                }

            }
    


        

        Vector2 PositionInitial = Player_.transform.position;
        







       if (Time.time >= spawnFantasmaInicial1 + spawnFantasmaFinal1 && Input.GetKey(KeyCode.Space)  && carregar==0)
       {
           
            clickDirecao(PositionInitial);

            spawnFantasmaInicial1 = Time.time;
            carregar++;

            if (ghost_.ListGhost.OfType<Ghost>().Any())
            {
                int lugar = ghost_.ListGhost.FindLastIndex(x => x.GetType() == typeof(Ghost));

            }

            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial2+spawnFantasmaFinal2 && carregar == 1)
       {

            ProximaPosicao(PositionInitial);

            spawnFantasmaInicial2 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial3+ spawnFantasmaFinal3 && carregar == 2)
       {

            ProximaPosicao(PositionInitial);


            spawnFantasmaInicial3 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
       {

            ProximaPosicao(PositionInitial);

            spawnFantasmaInicial4 = Time.time;
            carregar = 0;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }


    
    }
    public void clickDirecao(Vector2 Position)
    {


            if (Input.GetKey(KeyCode.RightArrow))
            {
              
              
                Position.x += 0.5f;
                Position.y += 0;

                
               
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Position.x += -0.5f;
                Position.y += 0;

            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Position.x += 0;
                Position.y += 0.5f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Position.x += 0;
                Position.y += -0.5f;
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                Position.x += 0.5f;
                Position.y += 0.5f;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                Position.x += -0.5f;
                Position.y += 0.5f;
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                Position.x += 0.5f;
                Position.y += -0.5f;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                Position.x += -0.5f;
                Position.y += -0.5f;
            }
        

    }
    public void ProximaPosicao(Vector2 Position)
    {
        if (Position.x > Position.y)
        {
            Position.x += 1;
            Position.y += 0;
        }
        if(Position.x < Position.y)
        {
            Position.x += -1;
            Position.y += 0;
        }
        if (Position.x < Position.y && Position.x == 0)
        {
            Position.x += 0;
            Position.y += 1;
        }
        if(Position.x > Position.y && Position.x == 0)
        {
            Position.x += 0;
            Position.y += -1;
        }
        if (Position.x == Position.y && Position.x == 0.5)
        {
            Position.x += 1;
            Position.y += 1;
        }
        if(Position.x < Position.y && Position.x == -0.5)
        {
            Position.x += -1;
            Position.y += 1;
        }
        if(Position.x > Position.y && Position.x == 0.5)
        {
            Position.x += 1;
            Position.y += -1;
        }
        if(Position.x == Position.y && Position.x == -0.5)
        {
            Position.x += -1;
            Position.y += -1;
        }

    }
    public void GhostAdicionarOuDestruir(GameObject gameObject)
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
}    

