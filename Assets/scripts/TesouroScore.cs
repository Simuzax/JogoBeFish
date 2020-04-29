using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TesouroScore : MonoBehaviour
{
    public static TesouroScore instance;
    public TextMeshProUGUI text;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void mudarScore(int TesouroValor)
    {
        score += TesouroValor;
        text.text = "X" + score.ToString();
    }
}
