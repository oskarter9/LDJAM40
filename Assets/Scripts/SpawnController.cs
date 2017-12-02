using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Strip strip;

    private GameObject[] spawns;

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
        distanceBetweenSpawns = (float) screenSize / numSpawns;

        InitSpawns();
    }

    void InitSpawns()
    {
        for(int i = 0; i<numSpawns; i++)
        {
            spawns[i] = Instantiate(spawn, new Vector3(-screenSize/2 + distanceBetweenSpawns/2 + distanceBetweenSpawns * i, 6, 0), Quaternion.identity);
            strip.CreateBlueStrip(Random.Range(3,8), i, spawns[i]);
        }
    }

    bool CheckActiveStrip(GameObject strip)
    {
        if (strip.transform.childCount > 0)
        {
            return true;
        }
        return false;
    }

    void MoveStrip(GameObject strip, float vel)
    {
        if(CheckActiveStrip(strip))
        {
            strip.transform.Translate(new Vector3(0, -vel*Time.deltaTime , 0));
        }
    }

    void Update()
    {
    }


}
