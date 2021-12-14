using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy2Movement : MonoBehaviour
{

    // event trigger
    public delegate void DESTROY();
    public static event DESTROY destroy;
    public delegate void SCORE(int num);
    public static event SCORE add;

    public Rigidbody2D rb;
    public Collider2D cd;
    public AIPath aipath;
    public AIDestinationSetter aidestinationsetter;
    public Animator anim;
    public AudioClip[] _clips;
    public AudioSource _audio;

    public Enemy data;
    public Transform targetTf;

    void Start()
    {

        // takeComponent();
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
        data.currentHealth = data.maxHealth;
    }

    void FixedUpdate()
    {
        // set animator walk
        anim.SetBool("isChase", true);
        // always rotate toward target
        Rotate(targetTf);

    }
    // Update is called once per frame
    void Update()
    {
    }
        
    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("hit");
        data.currentHealth -= damage;
        if (data.currentHealth <= 0)
        {
            Die();
            add(data.scorePoint);
        }
    }
    void Die()
    {
        FindObjectOfType<AudioManager>().Play("die");
        Debug.Log("ENEMY DIED!");
        Destroy(gameObject);
    }
    public void assignTarget(Transform tf)
    {
        Debug.Log("Masuk");
        aidestinationsetter.target = tf;
    }
    void Rotate(Transform target)
    {
        Vector3 arah = target.position - transform.position;
        float angle = Mathf.Atan2(arah.y, arah.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            anim.SetBool("isChase", false);
            Die();
            return;
        }
    }
    void takeComponent()
    {
        _audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        aipath = GetComponent<AIPath>();
        aidestinationsetter = GetComponent<AIDestinationSetter>();
    }
}
