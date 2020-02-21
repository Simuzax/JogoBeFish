using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interface : MonoBehaviour
{
    public event Action OnPlayerDeath;
   
    public Slider sliderHp;


    [SerializeField]
    private int HPMax;

    
    public int hp;  // no inspector o h fica maiusculo?sim

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {

            hp = value;
            if (hp <= 0)
            {
                hp = 0;
                if (OnPlayerDeath != null)//aqui garante que tem algo dentro
                {
                    Debug.Log("acertou");
                    OnPlayerDeath();
                }

                if (sliderHp && sliderHp != null
                {
                    sliderHp.value = 0;
                }
                   
            }
            else if (hp >= HPMax)
            {
                hp = HPMax;

                if (sliderHp && sliderHp != null)
                {
                    sliderHp.value = 1;
                }
                

            }
            else
            {
                

                   if (sliderHp && sliderHp != null)
                   {
                       sliderHp.value = (float)hp / (float)HPMax; //colocar como float para poder trabalhar com valores de vida com virgula futuramente?
                   }
                    
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
