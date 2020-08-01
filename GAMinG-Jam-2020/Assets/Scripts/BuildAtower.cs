using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildAtower : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private int[] prices;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject canvasAux;
    [SerializeField] private bool ativo = false;
    private CountMoney money;
    private int price;
    private bool inCollider = false;
    private void Awake()
    {
        for(int i=0;i<buttons.Length;i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = prices[i].ToString();
        }
    }
    private void Update()
    {
        if(buttons!=null && money!=null)
        {
            int aux = money.GetMoedas();
            ColorBlock cor;
            for (int i=0;i<buttons.Length;i++)
            {
                
                if(aux>=prices[i])
                {
                    cor = buttons[i].colors;
                    cor.highlightedColor = Color.green;
                    cor.pressedColor = Color.yellow;
                    buttons[i].colors = cor;
                }
                else
                {
                    cor = buttons[i].colors;
                    cor.highlightedColor = Color.red;
                    cor.pressedColor = Color.yellow;
                    buttons[i].colors = cor;
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
            canvasAux.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inCollider = false;
        canvas.SetActive(false);
        canvasAux.SetActive(false);
    }
    public void BuildATower(GameObject tower)
    {
        if (money != null)
        {
            if(money.GetMoedas()>=price)
            {
                Transform t = GetComponent<Transform>();
                Vector2 vet = new Vector2(t.position.x, tower.transform.position.y);
                t.position = vet;
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
