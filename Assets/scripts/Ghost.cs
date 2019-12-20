using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{




    public Transform Player_;

   

    public float ghostDelay;
    public float ghostDelaySeconds;
    public GameObject ghost;
    public bool makeGhost=false;

    public int quantidadeDeFantasmas;

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
        







       if (Time.time >= spawnFantasmaInicial1 + spawnFantasmaFinal1 && Input.GetKey(KeyCode.Space) && carregar==0)
       {
           
            clickDirecao(PositionInitial);

            spawnFantasmaInicial1 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial2+spawnFantasmaFinal2 && carregar == 1)
       {

            

            spawnFantasmaInicial2 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial3+ spawnFantasmaFinal3 && carregar == 2)
       {
            


            
            spawnFantasmaInicial3 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
       {
           

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
    public void ProximaPosicao(Vector2 )
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if ( x > y)
        {
            Position.x += 0.5f;
            Position.y += 0;
        }
    }
}    

