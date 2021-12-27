using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField] private float speed = 9;
    [SerializeField] private float rotationSpeed = 1.5f;
    private float dazedTime;
    public float startDazedTime;

    private Transform target;

    void Awake()
    {
        target = FindObjectOfType<Movement>().transform;
    }

    // Start is called before the first frame update
    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        var dir = target.position - transform.position;

        transform.up = Vector3.MoveTowards(transform.up, dir, rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        health -= damage;
        Debug.Log("TAKEN DAMGE!");
    }

    
}
