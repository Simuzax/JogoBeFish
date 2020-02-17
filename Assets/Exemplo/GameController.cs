using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exemplo
{
    public class GameController : MonoBehaviour
    {
        public Player player;

        private void Awake()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Player.playerInstance.DesabilitarControles();
                player.DesabilitarControles();
            }
        }
    }
}

