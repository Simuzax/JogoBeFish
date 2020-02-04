using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tubarao : MonoBehaviour
{
    [SerializeField]
    Tubarao Shark;

    
    SpawnInimigo spawnInimigo_ref;

    void Awake()
    {
        spawnInimigo_ref = GameObject.Find("Game").GetComponent<SpawnInimigo>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            spawnInimigo_ref.adicionarOuDestruir(Shark.gameObject);
        }
    }


}





