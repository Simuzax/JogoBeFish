using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControler3Layer3 : MonoBehaviour
{
    BarraDeVida barraDeVida_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        parallax_ref = GameObject.Find("3Layer3").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax3Layer3();
    }
    public void DesativarParallax3Layer3()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
