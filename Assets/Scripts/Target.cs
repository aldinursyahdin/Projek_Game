using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Target : MonoBehaviour
{
    public delegate void GAMEOVER(string teks);
    public static event GAMEOVER gameover;
    public delegate void PAUSE();
    public static event PAUSE pause;

    public Data data;
    public int supply;
    public int score;

    public GameObject live, sc;
    public TextMeshProUGUI liveNumber, scoreNumber;

    public Button buyBata, buySupreme;
    public int priceBata = 2500, priceSupreme = 5000;
    public Transform checklistPoint1, checklistPoint2;
    public GameObject checkPrefab;

    private void OnEnable()
    {
        EnemyMovement.add += scoreUp;
    }
    private void OnDisable()
    {
        EnemyMovement.add -= scoreUp;
    }
    // Start is called before the first frame update
    void Start()
    {
        supply = data.lives;
        score = data.score;

        buyBata.onClick.AddListener(Bata);
        buySupreme.onClick.AddListener(Supreme);
    }

    // Update is called once per frame
    void Update()
    {
        
        // always update live and score
        liveNumber.text = supply.ToString();
        scoreNumber.text = score.ToString();
        if(supply <= 0)
        {
            pause();
            gameover("Game Over");
        }
    }
    public void reduction()
    {
        supply--;
        Debug.Log("Supply left:" + supply);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ASUUU");
            reduction();
        }
    }
    void scoreUp(int num)
    {
        score += num;
        Debug.Log("Score : " + score);
    }
    void Bata()
    {
        if(score >= priceBata)
        {
            Debug.Log("Masuk BATA");
            GameObject temp = Instantiate(checkPrefab, checklistPoint1.position, checklistPoint1.rotation, GameObject.FindGameObjectWithTag("bataShop").transform) as GameObject;
            FindObjectOfType<Shooting>().tipe = 2;
            temp.SetActive(true);
            score -= priceBata;
        }
    }
    void Supreme()
    {
        if(score >= priceSupreme)
        {
            GameObject temp = Instantiate(checkPrefab, checklistPoint2.position, checklistPoint2.rotation, GameObject.FindGameObjectWithTag("supremeShop").transform) as GameObject;
            FindObjectOfType<Shooting>().tipe = 3;
            temp.SetActive(true);
            score -= priceSupreme;
        }
    }
}
