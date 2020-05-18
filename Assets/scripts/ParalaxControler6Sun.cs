using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControler6Sun : MonoBehaviour
{
    BarraDeVida barraDeVida_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        parallax_ref = GameObject.Find("6Sun").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax6Sun();
    }
    public void DesativarParallax6Sun()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
