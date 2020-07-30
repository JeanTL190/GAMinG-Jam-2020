using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int vidaMax = 1;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private bool monster = false;
    private SpriteRenderer spriteRend;
    private int vidaAtual;
    private int minimaVida;
    private int quantSprites;

    private void Awake()
    {
        vidaAtual = vidaMax;
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (!monster)
        {
            quantSprites = sprites.Length-1;
            minimaVida = vidaMax / quantSprites;
        }
    }
    private void Update()
    {
        if (monster)
        {
            if (vidaAtual <= 0)
                Destroy(this.gameObject);

        }
        else
        {
            if (vidaAtual > 0)
            {
                for (int i = 0; i < quantSprites; i++)
                {
                    if (vidaAtual >= minimaVida * (i + 1))
                        spriteRend.sprite = sprites[i];
                }
            }
            else
            {
                spriteRend.sprite = sprites[quantSprites];
            }
        }
    }
    public void TakeDamage(int damage)
    {
        vidaAtual -= damage;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMax);
    }
    public void RepareBuild(int cura)
    {
        vidaAtual += cura;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMax);
    }
    public int GetLife()
    {
        return vidaAtual;
    }
}
