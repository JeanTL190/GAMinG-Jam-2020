using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShootTower : MonoBehaviour
{
    [SerializeField] private GameObject shoot;
    [SerializeField] private string nameSpawn;
    private Transform tSpawn;
    private CanShootTower canShootTower;
    private AudioSource audio;
    private Life vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Life>();
        canShootTower = GetComponentInChildren<CanShootTower>();
        audio = GetComponent<AudioSource>();
        tSpawn = transform.Find(nameSpawn);
    }
    private void Update()
    {
        if (canShootTower.CanShoot())
            Spawn();
    }
    public void Spawn()
    {
        if(audio!=null)
            audio.Play();
        if(vida.GetLife()>0)
            Instantiate(shoot, tSpawn.position, transform.rotation);
    }
}
