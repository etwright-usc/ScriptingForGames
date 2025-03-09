using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    public int maxHealth;

    public GameManager gm;

    Rigidbody2D rb;
    float horizontalAxisInput;
    bool isGrounded = false;
    private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        gm.UpdateHealthText();
    }

    void Update()
    {
        horizontalAxisInput = Input.GetAxis("Horizontal");

        rb.velocity += new Vector2(0, gravity * Time.deltaTime);

        rb.position += new Vector2(horizontalAxisInput * moveSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal == Vector2.up && collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectible")
        {
            gm.UpdateScore(collision.GetComponent<Collectible>().points);
            StartCoroutine(collision.GetComponent<Collectible>().Collected());
        }

        if (collision.gameObject.tag == "Hazard")
        {
            health -= collision.GetComponent<Saw>().damageAmount;
            gm.UpdateHealthText();
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
