using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxControle7Clouds : MonoBehaviour
{
    Interface interface_ref;
    Parallax parallax_ref;

    private void Awake()
    {
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        parallax_ref = GameObject.Find("7Clouds").GetComponent<Parallax>();
    }

    // Update is called once per frame
    void Update()
    {
        DesativarParallax7Clouds();
    }
    public void DesativarParallax7Clouds()
    {
        if (interface_ref.hp <= 0)
        {
            parallax_ref.enabled = false;
        }
    }
}
