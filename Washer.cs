using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Washer : MonoBehaviour
{
    public AudioSource NotCatch;
    private Rigidbody rb;
    private GameManager _gameManager;
    public float force = 10;
    void Start()
    {
        NotCatch = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * force, ForceMode.Impulse);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gates"))
        {
            NotCatch.Play();
            _gameManager.NotCatched();
            Destroy(gameObject);
        }
    }
}
