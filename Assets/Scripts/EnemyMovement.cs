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
    public int scorePoint = 500;
    private int currentHealth;
    public bool isChase = true;
    public float speedRotation = 5f;

    Transform targetTf;

    // event trigger
    public delegate void DESTROY();
    public static event DESTROY destroy;
    public delegate void SCORE(int num);
    public static event SCORE add;
    // Start is called before the first frame update
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        targetTf = GameObject.FindGameObjectWithTag("Target").transform;
        currentHealth = maxHealth;
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
        anim.SetTrigger("IsHit");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            add(scorePoint);
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
    // tabrakan sama target
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            anim.SetBool("isChase", false);
            Die();
            return;
        }
    }
}
