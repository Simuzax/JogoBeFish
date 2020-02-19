using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControler6Sun : MonoBehaviour
{
    Interface interface_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        parallax_ref = GameObject.Find("6Sun").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax6Sun();
    }
    public void DesativarParallax6Sun()
    {
        if (interface_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
