using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    private bool canShoot=false;
    private Life vidaInimigo;

    private void Update()
    {
        if (vidaInimigo != null)
        {
            int aux = vidaInimigo.GetLife();
            if(aux<=0)
            {
                canShoot = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            vidaInimigo = collision.GetComponent<Life>();
            if (vidaInimigo != null)
            {
                int aux = vidaInimigo.GetLife();
                if (aux > 0)
                {
                    canShoot = true;
                    
                }
                else
                {
                    canShoot = false;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision!=null)
            canShoot = false;
    }
    public bool GetCanShoot()
    {
        return canShoot;
    }
}
