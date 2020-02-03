using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesouro : MonoBehaviour
{
    public int TesouroValor = 1;

    [SerializeField]
    Tesouro tesouro;

    
    SpawnarTesouro spawnarTesouro_ref;

    
    TesouroScore tesouroScore_ref;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        spawnarTesouro_ref = GameObject.Find("Game").GetComponent<SpawnarTesouro>();
        tesouroScore_ref = GameObject.Find("TesouroScore").GetComponent<TesouroScore>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            spawnarTesouro_ref.adicionarOuDestruirTesouro(tesouro.gameObject);

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ColidiuTesouro");
            spawnarTesouro_ref.adicionarOuDestruirTesouro(tesouro.gameObject);
            tesouroScore_ref.mudarScore(TesouroValor);
        }

    }
    



}
