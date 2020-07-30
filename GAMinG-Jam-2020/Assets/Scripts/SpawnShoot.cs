using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShoot : MonoBehaviour
{
    [SerializeField] private float timeSpawn=1f;
    [SerializeField] private GameObject shoot;
    [SerializeField] private string nameSpawn;
    private Transform tSpawn;
    private CanShoot canShoot;
    private InimigoAndar iA;
    private bool aux;

    private void Start()
    {
        iA = GetComponent<InimigoAndar>();
        canShoot = GetComponentInChildren<CanShoot>();
        tSpawn = transform.Find(nameSpawn);
        StartCoroutine("Spawn");
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
        }
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            if (aux)
            {
                Instantiate(shoot, tSpawn.position, transform.rotation);
                yield return new WaitForSeconds(timeSpawn);
            }
            else
                yield return new WaitForSeconds(0);
        }
    }
}
