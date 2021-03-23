using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private Vector2 moveAmount;

    private int health; // current health

    [SerializeField] private int maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;

    }

    public void getMovement() // set the moveAmount array (get user input)
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = input.normalized * speed; // normalize means length is 1
    }

    public void move() // handle RigidBody movement
    {
        getMovement();
        rb.MovePosition(rb.position + moveAmount * Time.deltaTime);
    }

    public void takeDamage(int amt)
    {
        health -= amt;
        if(health <= 0)
        {
            print("Game Over");
        }
    }
}
