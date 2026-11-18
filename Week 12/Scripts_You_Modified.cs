// PlayerMovement
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearright;
    public Sprite bearleft;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = bearleft;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = bearright;
        }
        else
        {
            speedX = 0;
        }
        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;
        }
        else
        {
            speedY = 0;
        }
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}

// GameManager
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameOverUI;

    public GameObject PlayAgainUI;

    private bool isGameOver = false;
    // Start is called once before the first execution of Update after MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        GameEnd();
    }
    void GameEnd()
    {
        if (playerHealth.health <= 0 && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
            IEnumerator VictoryMessage()
            {
                Debug.Log("You entered a special area!");

                yield return new WaitForSeconds(3f);

                Debug.Log("Bonus unlocked!");
            }
        }

    }
    IEnumerator BeforeEnd()
    {

        playerHealth.healthText.text = "Health: ";
        player.SetActive(false);
        PlayAgainUI.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayAgainUI.SetActive(false);
        gameOverUI.SetActive(true);
    }







}

//PlayerAttack
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Attack()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    void Shoot()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }

}
