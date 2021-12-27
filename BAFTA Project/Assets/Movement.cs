using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float maxHealth = 3;
    [SerializeField] private GameObject deathEffect, hitEffect;
    private float currentHealth;

    [SerializeField] private Healthbar healthbar;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        currentHealth -= Random.Range(0.5f, 1.5f);

        if(currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(gameObject);
        }
        else
        {
            healthbar.UpdateHealthBar(maxHealth, currentHealth);
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
}
