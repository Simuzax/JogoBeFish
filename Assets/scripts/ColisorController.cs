using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorController : MonoBehaviour
{
   


    public Interface interface_ref;
    public MovimentacaoColisores movimentacaoColisores_ref;
    // Start is called before the first frame update
    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        movimentacaoColisores_ref = GameObject.Find("ColisorDetraz").GetComponent<MovimentacaoColisores>();
    }

    // Update is called once per frame
    void Update()
    {
        DesabilitarControlesColisores();
    }
    public void DesabilitarControlesColisores()
    {
        if (interface_ref.hp <= 0)
        {
            movimentacaoColisores_ref.enabled = false;
        }
    }
}
