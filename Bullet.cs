using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

void Start()
    {
       
    }
    void Update()
    {
        Move();
    }
    void Move()
    {
       transform.position +=(Vector3.up*Time.deltaTime)*speed;
    }
}
