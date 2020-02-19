using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControle7Clouds2 : MonoBehaviour
{
    Interface interface_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        parallax_ref = GameObject.Find("7Clouds2").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax7Clouds2();
    }
    public void DesativarParallax7Clouds2()
    {
        if (interface_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
