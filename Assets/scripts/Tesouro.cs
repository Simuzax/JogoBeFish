using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesouro : Obstaculo
{
    public int TesouroValor = 1;

    

    
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

        tipo = TipoObstaculo.Tesouro;
        spawnarTesouro_ref = GameObject.Find("Game").GetComponent<SpawnarTesouro>();
        tesouroScore_ref = GameObject.Find("TesouroScore").GetComponent<TesouroScore>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ColisorDeTras"))
        {
            spawnarTesouro_ref.reutilizarTesouro(1.0f, 2.0f, 17.0f);
            gameObject.SetActive(false);

        }
        if (collision.gameObject.CompareTag("Piranha"))
        {
            spawnarTesouro_ref.reutilizarTesouro(1.0f, 2.0f, 17.0f);
            gameObject.SetActive(false);
            tesouroScore_ref.mudarScore(TesouroValor);
        }
        if (collision.gameObject.CompareTag("Cascudo"))
        {
            spawnarTesouro_ref.reutilizarTesouro(1.0f, 2.0f, 17.0f);
            gameObject.SetActive(false);
            tesouroScore_ref.mudarScore(TesouroValor);
        }

    }
    



}
