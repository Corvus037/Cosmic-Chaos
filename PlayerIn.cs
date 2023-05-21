using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerIn : MonoBehaviour
{
    private float h, v;
    public float speed;
    public GameObject Bullet;
    public Transform Spawn;

    public float maxHealth = 100f;
    public float currentHealth;
    public Text Vida;

    private int numShots = 1; 
    private bool doubleShotCollected = false; 
    private bool shieldCollected = false; 

    private float doubleShotDuration = 10f; 
    private float doubleShotTimer; 

    private float shieldDuration = 5f; 
    private float shieldTimer; 

    public Life healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        
        if (doubleShotCollected)
        {
            
            doubleShotTimer -= Time.deltaTime;

            
            if (doubleShotTimer <= 0)
            {
                
                ResetNumShots();
            }
        }

        
        if (shieldCollected)
        {
            
            shieldTimer -= Time.deltaTime;

            
            if (shieldTimer <= 0)
            {
                
                DisableShield();
            }
        }
    }

    public void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        transform.position += (Vector3.right * h + Vector3.up * v) * speed;
    }

    public void Shoot()
    {
        for (int i = 0; i < numShots; i++)
        {
            Instantiate(Bullet, Spawn.position, Spawn.rotation);

            if (doubleShotCollected)
            {
                Instantiate(Bullet, Spawn.position + new Vector3(1f, 0f, 0f), Spawn.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("life"))
        {
            currentHealth += 10;
            UpdateHealthBar();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("doubleShot"))
        {
            doubleShotCollected = true;
            doubleShotTimer = doubleShotDuration; 
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("shield"))
        {
            EnableShield();
            Destroy(other.gameObject);
        }
        else
        {
            if (!shieldCollected)
            {
                currentHealth -= 10;
                UpdateHealthBar();
                if (currentHealth < 1)
                {
                    SceneManager.LoadScene("GameOverEndless");
                }
            }
        }
    }

    void ResetNumShots()
    {
        doubleShotCollected = false;
        numShots = 1;
    }
    void EnableShield()
    {
        shieldCollected = true;
        shieldTimer = shieldDuration; 
    }

    private void UpdateHealthBar()
    {
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }

    void DisableShield()
    {
        shieldCollected = false;
    }
}