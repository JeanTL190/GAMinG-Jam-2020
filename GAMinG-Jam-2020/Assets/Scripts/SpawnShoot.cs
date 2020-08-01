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
    private bool aux;

    private void Awake()
    {
        iA = GetComponent<InimigoAndar>();
        canShoot = GetComponentInChildren<CanShoot>();
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
        //FindObjectOfType<AudioManager>().Play("Flechada 1");
        Instantiate(shoot, tSpawn.position, transform.rotation);
    }

}
