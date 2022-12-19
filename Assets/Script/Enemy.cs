using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent navAgent;
    [SerializeField]private GameObject heal;
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
            Dead();
        }
    }

    void Dead()
    {
        if (Random.Range(0, 2) == 0)
        {
            var position = transform.position;
            Instantiate(heal, new Vector3(position.x,2,position.z), Quaternion.identity);
        }
        ScoreManager.Instance.score += 100;
        GameObject.FindWithTag("ScoreText").GetComponent<ScoreText>().RefreshText();
        Destroy(gameObject);
    }
}
