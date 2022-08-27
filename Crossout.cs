using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class     Crossout : MonoBehaviour
{
    private bool ReadyForShoot;
    public GameManager _GameManager;
    public GameObject Washer_;
    public Joystick joystik;
    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_GameManager.GameOver == false)
        {
            Cursor.visible = false;
        }
    }
    private void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,1);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 JoystikPos = new Vector3(joystik.Horizontal, joystik.Vertical);
        Vector3 objPosAndroid = Camera.main.ScreenToWorldPoint(JoystikPos);
        if (_GameManager.GameOver == false)
        {
            transform.position = objPosAndroid;
            transform.position = objPos;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && _GameManager.GameOver == false)
        {
            Instantiate(Washer_, transform.position, transform.rotation);
        }
       
   
        
        if (_GameManager.GameOver == true)
        {
            Cursor.visible = true;
        }
    }

     public void ButtonClickForShoot()
    {
        if (_GameManager.GameOver == false)
        {
            Instantiate(Washer_, transform.position, transform.rotation);
        }
    }
}


