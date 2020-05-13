using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    

    HabilidadesGeraisPlayer habilidadesGeraisPlayer_ref;

    public bool devagar = false;

    [SerializeField]
    private float velocidadeLentaInicial;

    [SerializeField]
    private float velocidadeLentaMax;

    public int recuperacao;

    public int perder;

    // Start is called before the first frame update

    void Awake()
    {
        habilidadesGeraisPlayer_ref = GetComponent<HabilidadesGeraisPlayer>();
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (devagar)
        {
            velocidadeLentaInicial += Time.deltaTime;


            if (velocidadeLentaInicial >= velocidadeLentaMax)
            {

                devagar = false;
                habilidadesGeraisPlayer_ref.speed += recuperacao;

                velocidadeLentaInicial = 0;
            }
        }
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedeDepesca"))
        {
           if(habilidadesGeraisPlayer_ref.speed>=6)
           {
                habilidadesGeraisPlayer_ref.speed -= perder;
               devagar = true;
           }

            
        }
    }
}
