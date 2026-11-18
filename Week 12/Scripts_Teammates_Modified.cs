// Bullet.cs
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTime = 3f;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {
        rb.linearVelocity = transform.up * speed;
        Destroy(gameObject, destroyTime);
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}


// Enemy.cs
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int enemyHealth = 50;
    // Start is called once before the first execution of Update after MonoBehaviour is created
void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Death();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sword") || other.CompareTag("Bullet"))
        {
            enemyHealth -= 10;
        }
    }
    void Death()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}