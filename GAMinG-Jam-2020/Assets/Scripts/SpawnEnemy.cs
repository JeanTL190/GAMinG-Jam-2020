using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int nv = 0;
    [SerializeField] private int maxEnemy = 5;
    [SerializeField] private float timeSpawn = 1f;

    private void Start()
    {
        if(enemies!=null)
        {
            StartCoroutine("Spawn");
        }
    }
    IEnumerator Spawn()
    {
        for(int i=0;i<maxEnemy;i++)
        {
            Instantiate(enemies[Random.Range(0, nv)], this.transform);
            FindObjectOfType<AudioManager>().Play("Goblings " + Random.Range(1, 7));
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
