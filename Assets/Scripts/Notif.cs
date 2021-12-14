using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using TMPro;

public class Notif : MonoBehaviour
{
    public GameObject tf, temp;
    public GameObject[] list;

    public Gelombang wave;
    public ObjNotif Obj;

    // registering method lastpanel
    public static UnityAction play, back, quit;
    
    private void OnEnable()
    {
        WaveSpawner.ClearStage += Panel;
        WaveSpawner.spawn += show;
        Target.gameover += Panel;
    }
    private void OnDisable()
    {
        WaveSpawner.ClearStage -= Panel;
        WaveSpawner.spawn -= show;
        Target.gameover -= Panel;
    }
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void show()
    {
        StartCoroutine(_notif());
    }
    
    IEnumerator _notif()
    {
        Debug.Log("Notif in : " + Obj.iterasi);
        GameObject temp = Instantiate(list[0], tf.transform.position, tf.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform);
        temp.gameObject.GetComponent<TextMeshProUGUI>().text = Obj.str[Obj.iterasi++];
        yield return new WaitForSeconds(3f);
        Debug.Log("Notif out");
        Destroy(temp);
        yield break;
        
    }
    void Panel(String teks) 
    {
        // instantiate objek dan posisi yg benar
        Vector3 tmp;
        tmp.x = 960;
        tmp.y = 540;
        tmp.z = 0;
        GameObject _obj = Instantiate(list[1], tf.transform.position, tf.transform.rotation, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
        _obj.transform.position = tmp;

        // ganti teks
        _obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = teks;

        //olah objek
        Button[] btn = _obj.GetComponentsInChildren<Button>();
        btn[0].onClick.AddListener(play);
        btn[1].onClick.AddListener(back);
        btn[2].onClick.AddListener(quit);
        return;
    }
}
