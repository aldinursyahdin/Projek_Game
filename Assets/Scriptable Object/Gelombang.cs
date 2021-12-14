using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class Gelombang : ScriptableObject
{
    // iterasi1 untuk kontrol jumlah wave
    // iterasi1 untuk kontrol jumlah notif
    public int iterasi1 = 0;
    [Serializable]
    public class Gel
    {
        public string name;
        public int count;
        public float rate;
    }
    public Gel[] gel;
    public float timeBetweenWaves = 8f;
    public float waveCountdown;
    public float searchCountdown = 1f;
    public float timeDelay = 3f;
    public int nextWave = 0;
}


