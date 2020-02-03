using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startpos;
    public GameObject cam;  //aqui eu poderia fazer a referencia Cam cam para usa-la?
    [SerializeField]
    private float acelerarParallaxInicial;
    [SerializeField]
    private float acelerarParallaxMax;

    [SerializeField]
    private float desacelerarParallaxInicial;
    [SerializeField]
    private float desacelerarParallaxMax;
    
    public float parallaxEffect;

    public float elevarVelocidade;

    public float baixarVelocidade;

    public bool rapido = false;

    public bool mudarValor = true;

    [SerializeField]
    private float mudancaDeValorInicial;

    [SerializeField]
    private float mudancaDeValorMax;

    public float novoValorVelocidade;

    //[SerializeField]
    //private float novoValorParallax;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x; // qual posição esta se referendo?
        length = GetComponent<SpriteRenderer>().bounds.size.x; // aqui pega o tamanho de todo o cenário?
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));

        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos+dist,transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length)startpos -= length; 
    }
    void Update()
    {

        /*if (rapido == false && mudarValor == true)
        {
            StartCoroutine("TrocarValor");
            mudarValor = false;
        }*/

        if (rapido == false && mudarValor == true)
        {
            mudancaDeValorInicial += Time.deltaTime;
            if (mudancaDeValorInicial >= mudancaDeValorMax)
            {
                parallaxEffect -= novoValorVelocidade;
                mudancaDeValorInicial = 0;
                mudarValor = false;

            }
        }
        /*if (rapido == true && mudarValor == false)
        {
            StartCoroutine("Desacelerar");
            rapido = false;
        }*/
        if (rapido == true && mudarValor == false)
        {
            desacelerarParallaxInicial += Time.deltaTime;
            if (desacelerarParallaxInicial >= desacelerarParallaxMax)
            {
                parallaxEffect += baixarVelocidade;
                desacelerarParallaxInicial = 0;
                rapido = false;
            }
        }



        /*if (rapido == false && mudarValor == false)
        {
            StartCoroutine("Acelerar");
            rapido = true;
        }*/
        if (rapido == false && mudarValor == false)
        {
            acelerarParallaxInicial += Time.deltaTime;
            if (acelerarParallaxInicial >= acelerarParallaxMax)
            {
                parallaxEffect -= elevarVelocidade;
                acelerarParallaxInicial = 0;
                rapido = true;
            }
        }



        
        

    }



    /*IEnumerator TrocarValor()
    {
        for (int i = 0; i >= mudancaDeValorInicial; i++)
        {
            parallaxEffect -= novoValorParallax;
            mudarValor = false;

            yield return null;
        }
        


    }
    IEnumerator Desacelerar()
    {
        for (int i = 0; i >= desacelerarParallaxInicial; i++)
        {
            parallaxEffect += baixarVelocidade;
            rapido = false;
            yield return null;
        }
    }

    IEnumerator Acelerar()
    {
        for (int i = 0; i >= acelerarParallaxInicial; i++)
        {
            parallaxEffect -= elevarVelocidade;
            rapido = true;
            yield return null;
        }
    }*/
    
    

}

