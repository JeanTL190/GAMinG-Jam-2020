using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountMoney : MonoBehaviour
{
    [SerializeField] private int moedas=1;
    public void MoreMoney(int money)
    {
        moedas += money;
    }
    public int GetMoedas()
    {
        return moedas;

    }
    public void BuyABuild(int cost)
    {
        moedas -= cost;
    }
}
