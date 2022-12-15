using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float cameraY;
    [SerializeField] private float maxCameraY;
    [SerializeField] private float cameraX;
    [SerializeField] private GameObject cameraObject;
    [SerializeField] private GameObject gun;

    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI noDamageText;
    [SerializeField] private int hp;
    [SerializeField] private bool noDamage;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void Update()
    {
        Move();
        CameraMove();
        hpText.text = $"HP: {hp}";
    }

    private void CameraMove()
    {
        cameraX += Input.GetAxis("Mouse X") * cameraSpeed;
        cameraY += Input.GetAxis("Mouse Y") * cameraSpeed;
        cameraY = Math.Clamp(cameraY, -maxCameraY, maxCameraY);
        gameObject.transform.eulerAngles = new Vector3(-cameraY, cameraX, 0);
    }
    
    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveY);
        
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy") && !noDamage)
        {
            hp--;
            hpText.text = $"HP: {hp}";
            if (hp < 1)
                SceneManager.LoadScene("End");
            StartCoroutine(NoDamage());
        }
    }

    IEnumerator NoDamage()
    {
        noDamage = true;
        noDamageText.text = "NoDamage";
        yield return new WaitForSeconds(3f);
        noDamage = false;
        noDamageText.text = "";
    }
}
