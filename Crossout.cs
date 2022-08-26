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
    // Start is called before the first frame update
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
        if (_GameManager.GameOver == false)
        {
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

  

    // Update is called once per frame

}

