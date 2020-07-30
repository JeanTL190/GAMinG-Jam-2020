using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private bool ranged = true;
    [SerializeField] private int damage = 1;
    [SerializeField] private Animator anim;
    [SerializeField] private string gatilho;
    private Life vidaInimigo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            vidaInimigo = collision.GetComponent<Life>();
            if (vidaInimigo != null)
            {
                if (ranged)
                {
                    vidaInimigo.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
                else
                {
                    anim.SetBool(gatilho, true);
                }
            }
        }
    }
    public void DamegeMelee()
    {
        vidaInimigo.TakeDamage(damage);
        if(vidaInimigo.GetLife()<=0)
            anim.SetBool(gatilho, false);
    }
}
