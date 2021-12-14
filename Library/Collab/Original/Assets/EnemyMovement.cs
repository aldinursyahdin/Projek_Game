using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D cd;
    public AIPath aipath;
    public AIDestinationSetter aidestinationsetter;
    public Animator anim;
    public AudioClip[] _clips;
    public AudioSource _audio;

    public int maxHealth = 100;
    private int currentHealth;
    public bool isChase = true;
    public float speedRotation = 5f;

    Transform targetTf;
    // Start is called before the first frame update
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        targetTf = GameObject.FindGameObjectWithTag("Target").transform;
        currentHealth = maxHealth;
    }
    void Update()
    {
    }
    void FixedUpdate()
    {
        // set animator walk
        anim.SetBool("isChase", isChase);
        // always rotate toward target
        Rotate(targetTf);
    }

    public void TakeDamage(int damage)
    {
        FindObjectOfType<AudioManager>().Play("hit");
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();  
        }
    }
    void Die()
    {
        FindObjectOfType<ScoreScript>().update2();
        
       //ScoreScript.update2();
        ScoreScript.scoreValue += 500;
        FindObjectOfType<AudioManager>().Play("die");
        // play die animation

        // disable enemy
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
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("HITTTTTTTTTTTTTTTTTTT");
            collision.gameObject.GetComponent<Target>().reduction();
            aipath.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetBool("isChase", false);
            Destroy(rb);
            Destroy(gameObject, 3f);
            this.enabled = false;
        }
    }
}
