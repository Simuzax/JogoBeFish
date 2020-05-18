using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControle7Clouds : MonoBehaviour
{
    BarraDeVida barraDeVida_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        parallax_ref = GameObject.Find("7Clouds").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax7Clouds();
    }
    public void DesativarParallax7Clouds()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
