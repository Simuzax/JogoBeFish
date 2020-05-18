using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilidadesGeraisPlayer : MonoBehaviour
{ 
    Animator animator;
    Rigidbody2D rigidbody2D_;
    public int speed;

    //public SpawnarGhost spawnarGhost_ref;



    BarraDeVida barraDeVida_ref;
    // Start is called before the first frame update
    void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        animator = GetComponent<Animator>();
        rigidbody2D_ = GetComponent<Rigidbody2D>();
        //spawnarGhost_ref = GetComponent<SpawnarGhost>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Position = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidbody2D_.velocity = Position * speed;

        if (Position.x > 0 || Position.x < 0 || Position.y > 0 || Position.y < 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

    }

    public void TomarDano(int dano)
    {
        barraDeVida_ref.HP -= dano;
    }
    /*public void SomPlay(AudioClip Som)
    {
        audioSource.clip = Som;
        audioSource.Play();
    }*/

    
}
