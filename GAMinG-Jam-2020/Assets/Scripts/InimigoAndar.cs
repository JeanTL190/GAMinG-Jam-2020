using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAndar : MonoBehaviour
{
    [SerializeField] private GameObject king;
    [SerializeField] private float speed;
    private Vector2 aux;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aux = new Vector2(king.transform.position.x - transform.position.x, 0);
        aux = aux.normalized;
        if (aux.x < 0)
            transform.Rotate(0, 180, 0);
        Walk(speed);
    }

    public void Walk(float vel)
    {
        rb.velocity = aux.normalized * vel;
    }

    public float GetSpeed()
    {
        return speed;
    }
}
