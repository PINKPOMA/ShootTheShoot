using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        Instantiate(enemyPrefab, transform.position, quaternion.identity);
        yield return new WaitForSeconds(Random.Range(1f, 5.5f));
        StartCoroutine(Spawn());
    }
    
}
