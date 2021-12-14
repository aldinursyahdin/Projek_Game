using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Player2Movement : MonoBehaviour
{
    public int health = 100;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public Camera cam;

    Vector2 movement;
    Vector2 mousepos;
    // Update is called once per frame
    void Update()
    {
        walk();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousepos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FindObjectOfType<AudioManager>().Play("att");
            anim.SetTrigger("fire");
        }
    }
    private void walk()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /*if (anim.GetFloat("Speed") > 0.01f)
        {
            FindObjectOfType<AudioManager>().Play("walk");
        }*/
        
        anim.SetFloat("Speed", movement.sqrMagnitude);
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void takeDamage(int dmg)
    {
        anim.SetTrigger("Hit");
        health -= dmg;
    }
}
