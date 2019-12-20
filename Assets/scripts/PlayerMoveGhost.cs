using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveGhost : MonoBehaviour
{
    public Rigidbody2D righ;
    public float speed;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        get_Input();
    }
    void get_Input()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            righ.velocity = new Vector2(speed, righ.velocity.x);
            anim.SetBool("Moving", true);
            transform.localScale = new Vector3(1, 1, 1); 
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            righ.velocity = new Vector2(-speed, righ.velocity.x);
            anim.SetBool("Moving", true);
            transform.localScale = new Vector3(-1, 1, 1);
                 
        }
        else
        {
            righ.velocity = new Vector2(0, 0);
            anim.SetBool("Moving", false);
        }
    }
}
