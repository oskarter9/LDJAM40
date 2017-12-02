using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Strip strip;

    private GameObject[] spawns;
    private Transform[] refStrips;
    private float[] velocities;

    [SerializeField]
    private int numSpawns;

    [SerializeField]
    private GameObject spawn;

    private float distanceBetweenSpawns;
    private int screenSize = 16;
    
    void Awake()
    {
        Debug.Assert(strip);
    }

    void Start()
    {
        spawns = new GameObject[numSpawns];
        velocities = new float[numSpawns];
        Debug.Log(velocities.Length);
        distanceBetweenSpawns = (float) screenSize / numSpawns;
        refStrips = strip.getStrips();
        Debug.Log(refStrips.Length);
        refStrips = DeleteChildlessStrips();
        Debug.Log(refStrips.Length);
        InitSpawns();
    }

    void InitSpawns()
    {
        for(int i = 0; i<numSpawns; i++)
        {
            GenerateRandomStrip(i);
        }
    }

    public void GenerateRandomStrip(int posSpawn)
    {
        int ric = Random.Range(0, 2);
        Debug.Log(ric);
        spawns[posSpawn] = Instantiate(spawn, new Vector3(-screenSize / 2 + distanceBetweenSpawns / 2 + distanceBetweenSpawns * posSpawn, 6, 0), Quaternion.identity);
        velocities[posSpawn] = Random.Range(2, 6);

        if (ric == 1) strip.CreateBlueStrip(Random.Range(3, 8), posSpawn, spawns[posSpawn]);
        else strip.CreateRedStrip(Random.Range(3, 8), posSpawn, spawns[posSpawn]);
    }

    bool CheckActiveStrip(Transform strip)
    {
        if (strip.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }

    void MoveStrip(Transform strip, float vel)
    {
        if(CheckActiveStrip(strip))
        {
            strip.transform.Translate(new Vector3(0, -vel*Time.deltaTime , 0));
        }
    }

    public Transform[] GetRefStrip()
    {
        return refStrips;
    }

    private Transform[] DeleteChildlessStrips()
    {
        Transform[] aux = new Transform[spawns.Length];

        for(int i = 0; i < spawns.Length; i++)
        {
            aux[i] = refStrips[i+1];
        }

        return aux;
    }

    void Update()
    {
        for(int i = 0; i<refStrips.Length; i++)
        {    
            MoveStrip(refStrips[i], velocities[i]);
        }
    }


}
