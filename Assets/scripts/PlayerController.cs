using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HabilidadesGeraisPlayer Personagem;
  

    public Interface interface_ref;
    public PlayerMovimentacao playerMovimentacao;
    



    private void Awake()
    {
        
        interface_ref = GameObject.Find("Cascudo").GetComponent<Interface>();
        playerMovimentacao = GameObject.Find("Cascudo").GetComponent<PlayerMovimentacao>();

    }
    private void Update()
    {
        DesabilitarControles();
    }

    public void DesabilitarControles()
    {
        if (interface_ref.hp<=0)
        {
            playerMovimentacao.enabled = false;
            

        }
    }


}
