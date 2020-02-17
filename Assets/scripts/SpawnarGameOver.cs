using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnarGameOver : MonoBehaviour
{
    public Transform ColisorDaFrente;

    public GameObject GameOverPrefab;

    public void SpawnGameOver()
    {
        Vector2 IniPos = ColisorDaFrente.transform.position;
        Vector2 Position = IniPos;
        Position.x = -5;
        Position.y = 5;

        GameObject fo = Instantiate(GameOverPrefab, Position, Quaternion.identity);
    }
  
}
