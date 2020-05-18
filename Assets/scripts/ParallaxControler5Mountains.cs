using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControler5Mountains : MonoBehaviour
{
    BarraDeVida barraDeVida_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        parallax_ref = GameObject.Find("5Mountains").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax5Mountains();
    }
    public void DesativarParallax5Mountains()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
