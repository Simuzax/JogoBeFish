using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControle8Stars : MonoBehaviour
{
    BarraDeVida barraDeVida_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        parallax_ref = GameObject.Find("8Stars").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax8Stars();
    }
    public void DesativarParallax8Stars()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
