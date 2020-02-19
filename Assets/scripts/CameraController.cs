using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   


    public Interface interface_ref;
    public cameraMove cameraMove_ref;

    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        cameraMove_ref = GameObject.Find("MainCamera").GetComponent<cameraMove>(); 
    }

    void Update()
    {
        DesabilitarControlesCamera();
    }
    public void DesabilitarControlesCamera()
    {
        if (interface_ref.hp <= 0)
        {
            cameraMove_ref.enabled = false;
        }
    }

}
