using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemplo
{
    public class Player : MonoBehaviour
    {
        //public static Player playerInstance;

        private Movimentacao m_Movimentacao;

        private void Awake()
        {
            /*if (playerInstance != null && playerInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                playerInstance = this;
            }*/

            m_Movimentacao = GetComponent<Movimentacao>();
        }

        public void DesabilitarControles()
        {
            m_Movimentacao.enabled = false;
        }
    }
}
