using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
      void OnCollisionEnter(Collision Floor)
    {
       float x = Random.Range (-52,66);
         float y = Random.Range(38,39);
        
        Vector3 pos = new Vector3 (x,y,62);
        transform.position = pos;
    }

    
    
}
