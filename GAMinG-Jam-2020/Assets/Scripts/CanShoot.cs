using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShoot : MonoBehaviour
{
    private bool canShoot=false;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
            canShoot = true;
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
