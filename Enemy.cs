using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject bulletPrefab;
    public GameObject itemPrefab;
    public Transform firePoint;
    public int numShots = 3;
    public int NumShotsTaken = 0;
    public Text Score;
    private Vector3 oldPosition;
    public float horizontalSpeed;
    public float verticalSpeed;
    

    private float nextFireTime;

    
    private static int globalPoints;

    void Start()
    {
        
        globalPoints = 0;
    }

    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        Fire();
    }

    void MoveHorizontal()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
    transform.Translate(Vector3.right * horizontalMovement);
    }

    void MoveVertical()
    {
         float verticalMovement = -verticalSpeed * Time.deltaTime;
    transform.Translate(Vector3.down * verticalMovement);
    }

    void Fire()
    {
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            NumShotsTaken++;
            if (NumShotsTaken >= numShots)
            {
                float x = Random.Range(-52, 66);
                float y = Random.Range(38, 39);
                Vector3 pos = new Vector3(x, y, 73);
                oldPosition = transform.position; 
                transform.position = pos;
                NumShotsTaken = 0;
                globalPoints++; 
                Score.text = "Score: " + globalPoints;
                if (globalPoints > 19)
                {
                    SceneManager.LoadScene("Win");
                }
                if (Random.value < 0.5f)
                {
                    Instantiate(itemPrefab, oldPosition, Quaternion.identity);
                }
            }
        }
    }
}