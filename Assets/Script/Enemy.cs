using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;
    private int _hp = 5;
    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navAgent = GetComponent<NavMeshAgent>();
    }
 
    public void Update()
    {
        navAgent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            DownHp();
        }
    }

    void DownHp()
    {
        _hp--;
        if (_hp < 1)
        {
            Destroy(gameObject);
        }
    }
}
