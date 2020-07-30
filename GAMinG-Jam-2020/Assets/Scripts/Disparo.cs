using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{    
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxDist=1f;
    private Rigidbody2D rb;
    private Vector3 posiInicial;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        posiInicial = transform.position;
    }
    void Update()
    {
        Vector3 aux = transform.position - posiInicial;
        if (aux.magnitude >= maxDist)
        {
            Destroy(this.gameObject);
        }
    }
}
