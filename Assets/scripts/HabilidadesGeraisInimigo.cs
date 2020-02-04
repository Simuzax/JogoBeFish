using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesGeraisInimigo : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip somCausarDano;
    AudioClip somTomarDano;

    

   
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
        //DefinirAlvo();
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    public void Mover()
    {
       
        transform.Translate(speed* direction* Time.deltaTime);
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
