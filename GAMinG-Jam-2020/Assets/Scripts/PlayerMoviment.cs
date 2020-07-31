using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float velocidade = 1f;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float aux = Input.GetAxis("Horizontal");
        if (aux > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            rb.velocity = transform.right * velocidade;
        }
        else if (aux < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            rb.velocity = transform.right * velocidade;
        }
        else
            rb.velocity = Vector2.zero;
    }
}
