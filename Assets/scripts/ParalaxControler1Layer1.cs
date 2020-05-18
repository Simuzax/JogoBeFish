using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControler1Layer1 : MonoBehaviour
{
    BarraDeVida barraDeVida_ref;
    Parallax parallax_ref;
   
    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        parallax_ref = GameObject.Find("1Layer1").GetComponent<Parallax>(); 
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax1Layer1();
    }
    public void DesativarParallax1Layer1()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }

}
