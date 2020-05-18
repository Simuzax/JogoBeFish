using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{



    BarraDeVida barraDeVida_ref;
    public SpriteRenderer spriteRenderer_ref;


    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        spriteRenderer_ref = GameObject.Find("GameOver").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        AtivarControlesGameOver();
    }
    public void AtivarControlesGameOver()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            spriteRenderer_ref.enabled = true;
        }
    }
}
