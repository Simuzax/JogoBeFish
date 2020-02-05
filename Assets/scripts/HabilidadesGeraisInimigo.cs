using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesGeraisInimigo : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip somCausarDano;
    AudioClip somTomarDano;

    Interface interface_ref;

   
    HabilidadesGeraisPlayer habilidadesGeraisPlayer_ref;
    
     
     
    
    public int strength; 

    

    [SerializeField]
    float speed;

    [SerializeField]
    private Vector2 direction;

    

    // Start is called before the first frame update
    void Awake()
    {

        habilidadesGeraisPlayer_ref = GameObject.Find("Cascudo").GetComponent<HabilidadesGeraisPlayer>();
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    public void Mover()
    {
        if (interface_ref.estaVivo == true)
        {
            transform.Translate(speed * direction * Time.deltaTime);
        }
       
        
    }

    


    public void CausarDano(Player alvo)
    {
        habilidadesGeraisPlayer_ref.TomarDano(strength);


    }
    public void SomPlay(AudioClip Som)
    {
        audioSource.clip = Som;
        audioSource.Play();
    }
}
