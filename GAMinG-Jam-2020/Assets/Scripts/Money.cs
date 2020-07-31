using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int money = 1;
    [SerializeField] private float timeToDesapear = 1f;
    [SerializeField] private bool willDesapear = true;

    private void Awake()
    {
        if (willDesapear)
            StartCoroutine("Desapear");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountMoney count;
        if(collision!=null)
        {
            count = collision.GetComponent<CountMoney>();
            if(count!=null)
            {
                count.MoreMoney(money);
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator Desapear()
    {
        yield return new WaitForSeconds(timeToDesapear);
        Destroy(this.gameObject);
    }
}
