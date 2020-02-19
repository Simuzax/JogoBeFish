using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxControler5Mountains : MonoBehaviour
{
    Interface interface_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        parallax_ref = GameObject.Find("5Mountains").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax5Mountains();
    }
    public void DesativarParallax5Mountains()
    {
        if (interface_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
