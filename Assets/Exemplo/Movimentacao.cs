using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movimentacao : MonoBehaviour
{
    float speed = 15f;

    Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Mover(x, y);
    }

    void Mover(float x, float z)
    {
        Vector3 direcao = new Vector3(x, 0, z);

        Vector3 movimento = direcao * speed * Time.deltaTime;

        m_Rigidbody.MovePosition(movimento);
    }
}
