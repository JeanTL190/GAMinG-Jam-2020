using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShootTower : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private string nameSpawn;
    private Transform tSpawn;
    private CanShootTower canShootTower;
    private Life vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Life>();
        canShootTower = GetComponentInChildren<CanShootTower>();
        tSpawn = transform.Find(nameSpawn);
    }
    public void Spawn()
    {
       // FindObjectOfType<AudioManager>().Play("Flechada 1");
        if (vida.GetLife()>0)
            Instantiate(shoot, tSpawn.position, transform.rotation);
    }
}
