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
    [SerializeField]
    private int screenSize = 16;

    //powerup freeze
    public GameObject powerupFreeze;
    private GameObject prefabPowerupFreeze;
    private bool powerupIsOnScreen;
    private bool powerupIsOnTheGround;
    public float powerupFreezeMinFrequence = 20f;
    public float powerupFreezeMaxFrequence = 30f;
    private float counterPowerupFreeze = 0f;
    private float frequency;
    public float velYPowerup;

    void Awake()
    {
        Debug.Assert(strip);
    }

    void Start()
    {
        frequency = Random.Range(powerupFreezeMinFrequence, powerupFreezeMaxFrequence);


        powerupIsOnTheGround = false;
        powerupIsOnScreen = false;

        spawns = new GameObject[numSpawns];
        velocities = new float[numSpawns];

        distanceBetweenSpawns = (float) screenSize / numSpawns;
        refStrips = strip.getStrips();

        

        //Debug.Log(refStrips.Length);
        InitSpawns();
    }




    void Update()
    {
        Debug.Log(powerupIsOnScreen);
        if (!powerupIsOnScreen && !powerupIsOnTheGround)
        {

            counterPowerupFreeze += Time.deltaTime;
            if (counterPowerupFreeze >= frequency)
            {
                Debug.Log("Spawn freeze powerup");
                int spawnLocation = Random.Range(0, spawns.Length - 1);
                prefabPowerupFreeze = Instantiate(powerupFreeze, spawns[spawnLocation].transform.position, Quaternion.identity);
                Debug.Log("instanciado");

                powerupIsOnScreen = true;
                powerupIsOnTheGround = false;
                



   
            }




        }
        if (powerupIsOnScreen && !powerupIsOnTheGround)
        {
            Debug.Log("moviendo");
            MovementPowerup();
        }


        for (int i = 0; i < refStrips.Length; i++)
        {
            MoveStrip(refStrips[i], velocities[i]);
            if (refStrips[i].childCount == 0)
            {
                GenerateRandomStrip(i);
            }
        }
    }



    public void MovementPowerup()
    {

        prefabPowerupFreeze.transform.Translate(new Vector3(0, -velYPowerup, 0) * Time.deltaTime);




    }
    public void PowerupIsGrounded()
    {

        powerupIsOnTheGround = true;


    }
    public void PowerupFreezeIsDestroyed()
    {

        powerupIsOnScreen = false;
        powerupIsOnTheGround = false;
        counterPowerupFreeze = 0f;
        frequency = Random.Range(powerupFreezeMinFrequence, powerupFreezeMaxFrequence);

        Debug.Log("is destroyed and ready to spawn another one");
    }

    void InitSpawns()
    {
        for(int i = 0; i<numSpawns; i++)
        {
            spawns[i] = Instantiate(spawn, new Vector3(0 + distanceBetweenSpawns / 2 + distanceBetweenSpawns * i, 15, 0), Quaternion.identity);
            GenerateRandomStrip(i);
        }

        refStrips = DeleteChildlessStrips();

    }

    public void GenerateRandomStrip(int posSpawn)
    {

        int ric = (int)Random.Range(0, 2);
       
        velocities[posSpawn] = Random.Range(5, 10);

        if (ric == 1) strip.CreateBlueStrip(Random.Range(3, 8), posSpawn, spawns[posSpawn]);
        else strip.CreateRedStrip(Random.Range(3, 8), posSpawn, spawns[posSpawn]);
    }

    public int getScreenSize()
    {

        return screenSize;


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

   

}
