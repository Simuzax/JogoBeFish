using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirGameOver : MonoBehaviour
{
    public List<GameObject> ListGameOver = new List<GameObject>();
    

    public int recuperarSpeedPlayer;
    public int recuperarSpeedCamera;
    //public int recuperarSpeedColisores;
    public int recuperarSpeedTubarao;
    public int recuperarSpeedIscaDePeixe;

    public Tubarao tubarao;
    public Isca isca;
    
    

    
    public GameOver gameOver;
    public void GuardarOuDestruirGameOver(GameObject gameObject)
    {
        if (ListGameOver.Count > 0)
        {
            ListGameOver.Add(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
