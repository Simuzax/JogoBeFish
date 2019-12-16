using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   



    public Transform Player_;

    //public int distanciaDoGhost;

    public float ghostDelay;
    public float ghostDelaySeconds;
    public GameObject ghost;

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
    private void FixedUpdate()
    {
       

        Vector2 inipos = Player_.transform.position;
        Vector2 Position = inipos;


       

        if (Time.time>=spawnFantasmaInicial1+spawnFantasmaFinal1 && Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.RightArrow) && carregar == 0)
            {
                PosicoesDosFantasmas1();
            }

            /*if (Input.GetKey(KeyCode.RightArrow))
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
            if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                Position.x += 0.5f;
                Position.y += 0.5f;
            }
            if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                Position.x += -0.5f;
                Position.y += 0.5f;
            }
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                Position.x += 0.5f;
                Position.y += -0.5f;
            }
            if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                Position.x += -0.5f;
                Position.y += -0.5f;
            }*/


            spawnFantasmaInicial1 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
        }
       if(Time.time>=spawnFantasmaInicial2+spawnFantasmaFinal2 && carregar == 1)
       {

            //PosicoesDosFantasmas();
           
            Position.x += 1.4f;
            Position.y += 0;
            spawnFantasmaInicial2 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial3+ spawnFantasmaFinal3 && carregar == 2)
       {
            //PosicoesDosFantasmas();
            
            Position.x += 1.5f;
            Position.y += 0;
            spawnFantasmaInicial3 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }
       if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
       {

            //PosicoesDosFantasmas();
            Position.x += 2;
            Position.y += 0;
          
            spawnFantasmaInicial4 = Time.time;
            carregar = 0;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }


    }
    public void PosicoesDosFantasmas1()
    {
       
            if(carregar==0)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 0.5f;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 1)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 1.4f;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 2)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 1.5f;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 3)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 2;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            
            
        
        
        
           /* if (carregar == 0)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += -0.5f;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);

            }
            if (carregar == 1)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += -1.4f;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 2)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += -1.5f;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 3)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += -2;
                Position.y += 0;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
        
        
        
            if (carregar == 0)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 0;
                Position.y += 0.5f;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 1)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 0;
                Position.y += 1.4f;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 2)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 0;
                Position.y += 1.5f;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }
            if (carregar == 3)
            {
                Vector2 inipos = Player_.transform.position;
                Vector2 Position = inipos;
                Position.x += 0;
                Position.y += 2;
                GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
            }*/
    }
}

