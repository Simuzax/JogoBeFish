using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoDeObjetos : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
    }
    public void Mover()
    {
        transform.Translate(speed * direction * Time.deltaTime);
    }
}
