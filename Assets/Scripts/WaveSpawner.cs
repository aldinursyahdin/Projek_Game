using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //add event system
    public delegate void lastPanel(string teks);
    public delegate void Spawn();
    public static event lastPanel ClearStage;
    public static event Spawn spawn;
    public static event Spawn Clear;
    public enum SpawnState { SPAWNING, WAITING, COUNTING }
    // menjadikan instance dalam custom class dapat diakses di unity editor

    public Gelombang wave;
    public Enemy hitman,army;
    public ObjNotif Obj;
    public Data data;
    
    public Transform[] spawnPoints;
    public GameObject temp;
    public Notif notif;

    private SpawnState state = SpawnState.COUNTING;

    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    void reset()
    {
        wave.nextWave = 0;
        wave.iterasi1 = 0;
        Obj.iterasi = 0;
    }
    void Start()
    {
        reset();
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No Spawn Points");
        }
        wave.waveCountdown = wave.timeBetweenWaves;
    } 
    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            // check if enemy is still alive
            if(EnemyIsAlive() == false)
            {
                // Begin new round
                waveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if(wave.waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                // start spawning wave
                StartCoroutine(spawnWave());
            }
        }
        else
        {
            wave.waveCountdown -= Time.deltaTime;
        }
    }
    void waveCompleted()
    {
        //spawn and destroy
        if (spawn != null)
            spawn();
            
        state = SpawnState.COUNTING;
        wave.waveCountdown = wave.timeBetweenWaves;

        if(wave.nextWave + 1 > wave.gel.Length - 1)
        {
            if(ClearStage != null) 
            {
                Clear();
                ClearStage("Stage Completed");
                reset();
            }
            Debug.Log("ALL WAVES COMPLETED");
            Debug.Log("Game Has Ended");
        }
        wave.nextWave++;
    }

    bool EnemyIsAlive ()
    {
        wave.searchCountdown -= Time.deltaTime;
        if(wave.searchCountdown <= 0f)
        {
            wave.searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator spawnWave()
    {
        //spawn and destroy
        if (spawn != null)
            spawn();
        Debug.Log("Spawning Waves : " + wave.gel[wave.iterasi1].name);
        Debug.Log("iterasi " + wave.iterasi1);
        state = SpawnState.SPAWNING;

        // spawn jumlah musuh
        for(int i = 0; i < wave.gel[wave.iterasi1].count; i++)
        {
            SpawnEnemy(army.Prefab);
            yield return new WaitForSeconds(1f/wave.gel[wave.iterasi1].rate);
        }
        wave.iterasi1++;
        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(GameObject _enemy)
    {
        // Spawn Enemy di titik random yang sudah ditentukan
        Transform _sp = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
        temp = Instantiate(_enemy, _sp.position, _sp.rotation);
    }

}
