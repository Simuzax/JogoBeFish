using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{



    BarraDeVida barraDeVida_ref;
    public cameraMove cameraMove_ref;

    private void Awake()
    {
        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        cameraMove_ref = GameObject.Find("MainCamera").GetComponent<cameraMove>(); 
    }

    void Update()
    {
        DesabilitarControlesCamera();
    }
    public void DesabilitarControlesCamera()
    {
        if (barraDeVida_ref.hp <= 0)
        {
            cameraMove_ref.enabled = false;
        }
    }

}
