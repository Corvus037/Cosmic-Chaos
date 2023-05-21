using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime = 2.0f;

    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += (Vector3.up * Time.deltaTime) * speed;
    }
}