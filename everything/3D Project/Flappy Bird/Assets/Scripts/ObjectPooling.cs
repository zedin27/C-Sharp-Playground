using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Object Pooling: https://www.youtube.com/watch?v=YCHJwnmUGDk&ab_channel=JasonWeimann
** 
*/

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    private PlayerControl playerControllerScript;
    public int amountToPool;
    
    void Awake()
    {
        sharedInstance = this;
    }
    void Start()
    {
        playerControllerScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < amountToPool; i++) //Add objects to the pool and turns them invisible (false)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }
}
