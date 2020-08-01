using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShootTower : MonoBehaviour
{
    private Queue<Collider2D> fila;
    public Animator m_Animator;

    private void Awake()
    {
        fila = new Queue<Collider2D>();
    }
    private void Update()
    {
        Life vidaIni;
        if (fila.Count > 0)
        {
            vidaIni = fila.Peek().GetComponent<Life>();
            if (vidaIni != null)
            {
                if (vidaIni.GetLife() <= 0)
                {
                    fila.Dequeue();
                }
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
                m_Animator.SetBool("isShooting", true);
                FindObjectOfType<AudioManager>().Play("Flechada 1");
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
                m_Animator.SetBool("isShooting", false);
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
