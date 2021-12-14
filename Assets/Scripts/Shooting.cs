using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Transform firepoint;
    public Animator anim;

    public float bulletForce = 20f;
    public int tipe;

    GameObject bullet;
    Rigidbody2D rb;
    Animation tmp;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        anim.SetInteger("Tipe", tipe);
        switch (tipe)
        {
            case 1:
                bullet = Instantiate(bulletPrefab[0], firepoint.position, firepoint.rotation);
                rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
                break;
            case 2:
                bullet = Instantiate(bulletPrefab[1], firepoint.position, firepoint.rotation);
                rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
                break;
            case 3:
                bullet = Instantiate(bulletPrefab[2], firepoint.position, firepoint.rotation);
                rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
                break;
            default:
                break;
        }
    }
}
