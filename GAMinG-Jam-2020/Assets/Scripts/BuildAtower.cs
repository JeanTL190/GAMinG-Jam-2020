using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildAtower : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private int[] prices;
    [SerializeField] private GameObject canvas;
    [SerializeField] private bool ativo = false;
    private CountMoney money;
    private int price;
    private bool inCollider = false;
    private void Update()
    {
        if(buttons!=null && money!=null)
        {
            int aux = money.GetMoedas();
            ColorBlock corCanBuy = new ColorBlock();
            ColorBlock corCantBuy = new ColorBlock();
            corCanBuy.highlightedColor = Color.green;
            corCanBuy.pressedColor = Color.yellow;
            corCantBuy.highlightedColor = Color.red;
            corCantBuy.pressedColor = Color.yellow;
            for (int i=0;i<buttons.Length-1;i++)
            {
                
                if(aux>prices[i])
                {
                    buttons[i].colors = corCanBuy;
                }
                else
                {
                    buttons[i].colors = corCantBuy;
                }
            }
        }
        if(inCollider)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ativo = !ativo;
                canvas.SetActive(ativo);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision != null)
        {
            money = collision.GetComponent<CountMoney>();
            inCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inCollider = false;
        canvas.SetActive(false);
    }
    public void BuildATower(GameObject tower)
    {
        if (money != null)
        {
            if(money.GetMoedas()>=price)
            {
                Transform t = GetComponentInParent<Transform>();
                Instantiate(tower, t.position,t.rotation);
                money.BuyABuild(price);
                Destroy(this.gameObject);
            }
        }
    }
    public void Price(int p)
    {
        price = p;
    }
}
