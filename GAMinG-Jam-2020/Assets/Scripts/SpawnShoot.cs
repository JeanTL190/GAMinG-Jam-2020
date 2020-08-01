using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShoot : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private string nameSpawn;
    private Transform tSpawn;
    private CanShoot canShoot;
    private InimigoAndar iA;
    private AudioSource audio;
    private bool aux;

    private void Awake()
    {
        iA = GetComponent<InimigoAndar>();
        canShoot = GetComponentInChildren<CanShoot>();
        audio = GetComponent<AudioSource>();
        tSpawn = transform.Find(nameSpawn);
    }
    private void Update()
    {
        aux = canShoot.GetCanShoot();
        if (!aux)
        {
            iA.Walk(iA.GetSpeed());
        }
        if (aux)
        {
            iA.Walk(0);
            Spawn();
        }
    }
    public void Spawn()
    {
        if(audio!=null)
            audio.Play();
        Instantiate(shoot, tSpawn.position, transform.rotation);
    }

}
