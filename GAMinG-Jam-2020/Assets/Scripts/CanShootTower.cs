using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShootTower : MonoBehaviour
{
    private Queue<Collider2D> fila;

    private void Update()
    {
        Life vidaInimigo = fila.Peek().GetComponent<Life>();
        if (vidaInimigo != null)
        {
            if (vidaInimigo.GetLife() <= 0)
            {
                fila.Dequeue();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Life vidaInimigo = collision.GetComponent<Life>();
            if (vidaInimigo != null)
            {
                fila.Enqueue(collision);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(fila!=null)
        {
            if (collision == fila.Peek())
            {
                fila.Dequeue();
            }
        }
    }
    public Queue<Collider2D> GetQueue()
    {
        return fila;
    }
    public bool CanShoot()
    {
        return (fila.Count > 0);
    }
}
