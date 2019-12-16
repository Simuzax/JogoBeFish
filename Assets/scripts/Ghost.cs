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
        Vector2 Position = inipos;


       
       if (Time.time >= spawnFantasmaInicial1 + spawnFantasmaFinal1 && Input.GetKey(KeyCode.Space) && carregar==0)
       {
           
            clickDirecao(Position);

            spawnFantasmaInicial1 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial2+spawnFantasmaFinal2 && carregar == 1)
       {

            ProximasPossicoes(Position);


            spawnFantasmaInicial2 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }
       if(Time.time>=spawnFantasmaInicial3+ spawnFantasmaFinal3 && carregar == 2)
       {
            ProximasPossicoes2(Position);


            //Position.x += 1.5f;
            //Position.y += 0;
            spawnFantasmaInicial3 = Time.time;
            carregar++;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }
       if (Time.time >= spawnFantasmaInicial4 + spawnFantasmaFinal4 && carregar == 3)
       {
            ProximasPossicoes3(Position);

            spawnFantasmaInicial4 = Time.time;
            carregar = 0;
            GameObject currentGhost = Instantiate(ghost, Position, Quaternion.identity);
       }


    }
    
    public void clickDirecao(Vector2 inipos)
    {
        inipos = Player_.transform.position;
        Vector2 Position = inipos;

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
    public void ProximasPossicoes(Vector2 inipos)
    {
        inipos = Player_.transform.position;
        Vector2 Position = inipos;

        if (Position.x == 0.5f && Position.y==0)
        {
            Position.x += 1.4f;
            Position.y += 0;

        }
        else if (Position.x == -0.5f && Position.y==0)
        {
            Position.x += -1.4f;
            Position.y += 0;

        }
        else if(Position.x==0 && Position.y == 0.5f)
        {
            Position.x += 0;
            Position.y += 1.4f;
        }
        else if(Position.x==0 && Position.y == -0.5f)
        {
            Position.x += 0;
            Position.y += -1.4f;
        }
        else if (Position.x == 0.5f && Position.y == 0.5f)
        {
            Position.x += 1.4f;
            Position.y += 1.4f;

        }
        else if (Position.x == 0.5f && Position.y == -0.5f)
        {
            Position.x +=  1.4f;
            Position.y += -1.4f;

        }
        else if (Position.x == -0.5f && Position.y == 0.5f)
        {
            Position.x += -1.4f;
            Position.y += 1.4f;
        }
        else if (Position.x == -0.5f && Position.y == -0.5f)
        {
            Position.x += -1.4f;
            Position.y += -1.4f;
        }


    }
    public void ProximasPossicoes2(Vector2 inipos)
    {
        inipos = Player_.transform.position;
        Vector2 Position = inipos;

        if (Position.x == 1.4f && Position.y == 0)
        {
            Position.x += 1.5f;
            Position.y += 0;

        }
        else if (Position.x == -1.4f && Position.y == 0)
        {
            Position.x += -1.5f;
            Position.y += 0;

        }
        else if (Position.x == 0 && Position.y == 1.4f)
        {
            Position.x += 0;
            Position.y += 1.5f;
        }
        else if (Position.x == 0 && Position.y == -1.4f)
        {
            Position.x += 0;
            Position.y += -1.5f;
        }
        else if (Position.x == 1.4f && Position.y == 1.4f)
        {
            Position.x += 1.5f;
            Position.y += 1.5f;

        }
        else if (Position.x == 1.4f && Position.y == -1.4f)
        {
            Position.x += 1.5f;
            Position.y += -1.5f;

        }
        else if (Position.x == -1.4f && Position.y == 1.4f)
        {
            Position.x += -1.5f;
            Position.y += 1.5f;
        }
        else if (Position.x == -1.4f && Position.y == -1.4f)
        {
            Position.x += -1.5f;
            Position.y += -1.5f;
        }


    }
    public void ProximasPossicoes3(Vector2 inipos)
    {
        inipos = Player_.transform.position;
        Vector2 Position = inipos;

        if (Position.x == 1.5f && Position.y == 0)
        {
            Position.x += 2;
            Position.y += 0;

        }
        else if (Position.x == -1.5f && Position.y == 0)
        {
            Position.x += -2;
            Position.y += 0;

        }
        else if (Position.x == 0 && Position.y == 1.5f)
        {
            Position.x += 0;
            Position.y += 2;
        }
        else if (Position.x == 0 && Position.y == -1.5f)
        {
            Position.x += 0;
            Position.y += 2;
        }
        else if (Position.x == 1.5f && Position.y == 1.5f)
        {
            Position.x += 2;
            Position.y += 2;

        }
        else if (Position.x == 1.5f && Position.y == -1.5f)
        {
            Position.x += 2;
            Position.y += -2;

        }
        else if (Position.x == -1.5f && Position.y == 1.5f)
        {
            Position.x += -2;
            Position.y += 2;
        }
        else if (Position.x == -1.5f && Position.y == -1.5f)
        {
            Position.x += -2;
            Position.y += 2;
        }


    }
}

