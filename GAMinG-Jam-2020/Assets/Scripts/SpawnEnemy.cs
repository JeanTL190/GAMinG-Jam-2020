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
            int aux = Random.Range(0, nv);
            Transform t = GetComponent<Transform>();
            Vector2 vet = new Vector2(t.position.x, enemies[aux].transform.position.y);
            t.position = vet;
            Instantiate(enemies[aux], t);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
