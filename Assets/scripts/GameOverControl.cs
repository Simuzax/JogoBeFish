using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    


    public Interface interface_ref;
    public SpriteRenderer spriteRenderer_ref;


    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        spriteRenderer_ref = GameObject.Find("GameOver").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        AtivarControlesGameOver();
    }
    public void AtivarControlesGameOver()
    {
        if (interface_ref.hp <= 0)
        {
            spriteRenderer_ref.enabled = true;
        }
    }
}
