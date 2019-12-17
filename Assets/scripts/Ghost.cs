using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   



    public Transform Player_;

  

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
        Vector2 PositionInitial = inipos;


       
       if (Time.time >= spawnFantasmaInicial1 + spawnFantasmaFinal1 && Input.GetKey(KeyCode.Space) && carregar==0)
       {
           
            clickDirecao(PositionInitial);

            spawnFantasmaInicial1 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial2+spawnFantasmaFinal2 && carregar == 1)
       {

            ProximasPossicoes(PositionInitial);


            spawnFantasmaInicial2 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial3+ spawnFantasmaFinal3 && carregar == 2)
       {
            ProximasPossicoes2(PositionInitial);


            
            spawnFantasmaInicial3 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }
       if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
       {
            ProximasPossicoes3(PositionInitial);

            spawnFantasmaInicial4 = Time.time;
            carregar = 0;
            GameObject currentGhost = Instantiate(ghost, PositionInitial, Quaternion.identity);
       }


    }
    
    public void clickDirecao(Vector2 Position)
    {
        

        if (Input.GetKeyDown(KeyCode.RightArrow))
        { 
            Position.x += 0.5f;
            Position.y += 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Position.x += -0.5f;
            Position.y += 0;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Position.x += 0;
            Position.y += 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Position.x += 0;
            Position.y += -0.5f;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Position.x += 0.5f;
            Position.y += 0.5f;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Position.x += -0.5f;
            Position.y += 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Position.x += 0.5f;
            Position.y += -0.5f;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Position.x += -0.5f;
            Position.y += -0.5f;
        }
    }
    public void ProximasPossicoes(Vector2 Position)
    {
        

        if (Position.x == 0.5f && Position.y==0)
        {
            Position.x += 1.4f;
            Position.y += 0;

        }
        if (Position.x == -0.5f && Position.y==0)
        {
            Position.x += -1.4f;
            Position.y += 0;

        }
        if(Position.x==0 && Position.y == 0.5f)
        {
            Position.x += 0;
            Position.y += 1.4f;
        }
        if(Position.x==0 && Position.y == -0.5f)
        {
            Position.x += 0;
            Position.y += -1.4f;
        }
        if (Position.x == 0.5f && Position.y == 0.5f)
        {
            Position.x += 1.4f;
            Position.y += 1.4f;

        }
        if (Position.x == 0.5f && Position.y == -0.5f)
        {
            Position.x +=  1.4f;
            Position.y += -1.4f;

        }
        if (Position.x == -0.5f && Position.y == 0.5f)
        {
            Position.x += -1.4f;
            Position.y += 1.4f;
        }
        if (Position.x == -0.5f && Position.y == -0.5f)
        {
            Position.x += -1.4f;
            Position.y += -1.4f;
        }


    }
    public void ProximasPossicoes2(Vector2 Position)
    {
       

        if (Position.x == 1.4f && Position.y == 0)
        {
            Position.x += 1.5f;
            Position.y += 0;

        }
        if (Position.x == -1.4f && Position.y == 0)
        {
            Position.x += -1.5f;
            Position.y += 0;

        }
        if (Position.x == 0 && Position.y == 1.4f)
        {
            Position.x += 0;
            Position.y += 1.5f;
        }
        if (Position.x == 0 && Position.y == -1.4f)
        {
            Position.x += 0;
            Position.y += -1.5f;
        }
        if (Position.x == 1.4f && Position.y == 1.4f)
        {
            Position.x += 1.5f;
            Position.y += 1.5f;

        }
        if (Position.x == 1.4f && Position.y == -1.4f)
        {
            Position.x += 1.5f;
            Position.y += -1.5f;

        }
        if (Position.x == -1.4f && Position.y == 1.4f)
        {
            Position.x += -1.5f;
            Position.y += 1.5f;
        }
        if (Position.x == -1.4f && Position.y == -1.4f)
        {
            Position.x += -1.5f;
            Position.y += -1.5f;
        }


    }
    public void ProximasPossicoes3(Vector2 Position)
    {
        

        if (Position.x == 1.5f && Position.y == 0)
        {
            Position.x += 2;
            Position.y += 0;

        }
        if (Position.x == -1.5f && Position.y == 0)
        {
            Position.x += -2;
            Position.y += 0;

        }
        if (Position.x == 0 && Position.y == 1.5f)
        {
            Position.x += 0;
            Position.y += 2;
        }
        if (Position.x == 0 && Position.y == -1.5f)
        {
            Position.x += 0;
            Position.y += 2;
        }
        if (Position.x == 1.5f && Position.y == 1.5f)
        {
            Position.x += 2;
            Position.y += 2;

        }
        if (Position.x == 1.5f && Position.y == -1.5f)
        {
            Position.x += 2;
            Position.y += -2;

        }
        if (Position.x == -1.5f && Position.y == 1.5f)
        {
            Position.x += -2;
            Position.y += 2;
        }
        if (Position.x == -1.5f && Position.y == -1.5f)
        {
            Position.x += -2;
            Position.y += 2;
        }


    }
}

