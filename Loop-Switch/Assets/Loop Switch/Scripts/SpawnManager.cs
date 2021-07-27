using UnityEngine;

public class SpawnManager : MonoBehaviour 
{

    public float lastPositionY;

    public float lastpositionX;

    private Quaternion lastRotation;

    public static SpawnManager instance;

    ObjectPooler objectpooler;

    GameObject lastLoop;

    public GameObject loopSpawnEffect;

    public int axis;

    void Start () 
    {
        objectpooler = ObjectPooler.instance;
        MakeSingleton();
        lastPositionY = 2f;
        lastpositionX = 0f;
        lastRotation = Quaternion.identity;
        axis = 1;
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update ()
    {
        if (lastLoop != null)
        {
            lastRotation = lastLoop.transform.rotation;
        }
    }

    public void Spawn()
    {
        if (Random.value > 0.5f)
        {
            lastPositionY += 2;
            axis = 1;
        } 
        else
        {
            lastpositionX += 2;
            axis = -1;
        }
        
        Vector2 spawnPosition = new Vector2(lastpositionX, lastPositionY);
        Instantiate(loopSpawnEffect, spawnPosition, lastRotation);
        lastLoop = objectpooler.SpawnFromPool("Loop", spawnPosition, lastRotation);
    }
}
