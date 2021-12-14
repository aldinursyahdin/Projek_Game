using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Animation anim;
    public int Tipe = 1;
    private int dmg = 0;

    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            det();
            collision.gameObject.GetComponent<EnemyMovement>().TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
    public void changeType(int type)
    {
        Tipe = type;
        switch (type)
        {
            case 1:
                anim.Play("white");
                break;
            case 2:
                anim.Play("blue");
                break;
            case 3:
                anim.Play("red");
                break;
            default:
                Debug.Log("Peluru tidak ada dalam daftar");
                break;
        }
    }
    private void det()
    {
        if (Tipe == 1)
        {
            dmg = 15;
        }
        else if (Tipe == 2)
        {
            dmg = 25;
        }
        else if (Tipe == 3)
        {
            dmg = 50;
        }
    }
}
