using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private bool ranged = true;
    [SerializeField] private bool tower = false;
    [SerializeField] private int damage = 1;
    [SerializeField] private Animator anim;
    [SerializeField] private string gatilho;
    private InimigoAndar iA;
    private Life vidaInimigo;
    private AudioSource audio;

    private void Awake()
    {
        iA = GetComponent<InimigoAndar>();
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            vidaInimigo = collision.GetComponent<Life>();
            if (vidaInimigo != null && !tower)
            {
                if (ranged)
                {
                    vidaInimigo.TakeDamage(damage);
                    Destroy(this.gameObject);
                }
                else
                {
                    audio.Play();
                    anim.SetBool(gatilho, true);
                    iA.Walk(0);
                }
            }
            else if(vidaInimigo!=null && tower)
            {
                DisparoTower disparo = GetComponent<DisparoTower>();
                if (disparo.GetCol() == collision)
                {
                    vidaInimigo.TakeDamage(damage);
                }
            }
        }
    }
    public void DamegeMelee()
    {
        vidaInimigo.TakeDamage(damage);
        if(vidaInimigo.GetLife()<=0)
        {
            audio.Stop();
            anim.SetBool(gatilho, false);
            iA.Walk(iA.GetSpeed());
        }
    }
}
