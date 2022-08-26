using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private bool LeftOrRight;
    public float MoveSpeed = 1f;
    private Washer _washer;
    private GameManager _gameManager;
   

    private void Start()
    {
        _washer = GetComponent<Washer>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        LeftOrRight = false;
    }

    void Update()
    {
        Difficult();
        if (_gameManager.GameOver == false)
        {
            if (LeftOrRight == false)
            {
                transform.Translate(Vector3.back * Time.deltaTime * MoveSpeed);
            }
            else
            {
                transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
            }
        }
        
    }

    void Difficult()
    {
       MoveSpeed = _gameManager.DifficaltValue / MoveSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LeftBorder"))
        {
            LeftOrRight = false;

        }

        if (collision.gameObject.CompareTag("RightBorder"))
        {
            LeftOrRight = true;
        }

        if (collision.gameObject.TryGetComponent(out _washer))
        {
            _gameManager.Catched();
            Destroy(_washer.gameObject);
            Debug.Log("ewq");
        }
        
       
    }
}
