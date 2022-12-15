using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool _delay;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bullet;
    [SerializeField] private  AudioSource audioSource;
    [SerializeField] private  AudioClip fireSound;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (!_delay)
            {
                audioSource.PlayOneShot(fireSound);
                Instantiate(bullet, firePos.position, firePos.rotation);
                StartCoroutine(Delay());
            }
        }
    }

    IEnumerator Delay()
    {
        _delay = true;
        yield return new WaitForSeconds(0.15f);
        _delay = false;
    }
}
