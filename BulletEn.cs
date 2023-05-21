using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEn : MonoBehaviour
{
    public float speed;
    public float Lifetime = 4.0f;
    
    
    void Start()
    {
        Destroy(gameObject, Lifetime);
    }
    
    void Update()
    {
        Move();
        
    }
    
    void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            
        }
    }
}
