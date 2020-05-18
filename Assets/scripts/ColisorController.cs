using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorController : MonoBehaviour
{



    BarraDeVida barraDeVida_ref;
    public MovimentacaoColisores movimentacaoColisores_ref;
    // Start is called before the first frame update
    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        movimentacaoColisores_ref = GameObject.Find("ColisorDetras").GetComponent<MovimentacaoColisores>();
    }

    // Update is called once per frame
    void Update()
    {
        DesabilitarControlesColisores();
    }
    public void DesabilitarControlesColisores()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            movimentacaoColisores_ref.enabled = false;
        }
    }
}
