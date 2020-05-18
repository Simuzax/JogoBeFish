using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HabilidadesGeraisPlayer Personagem;
  

    BarraDeVida barraDeVida_ref;
    public PlayerMovimentacao playerMovimentacao;
    



    private void Awake()
    {

        barraDeVida_ref = GameObject.Find("Game").GetComponent<BarraDeVida>();
        playerMovimentacao = GameObject.Find("Cascudo").GetComponent<PlayerMovimentacao>();

    }
    private void Update()
    {
        DesabilitarControles();
    }

    public void DesabilitarControles()
    {
        if (barraDeVida_ref.hp<=0)
        {
            playerMovimentacao.enabled = false;
            

        }
    }


}
