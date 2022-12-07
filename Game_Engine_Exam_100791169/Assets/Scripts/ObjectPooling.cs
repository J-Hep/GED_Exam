using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//DUCKS ARE POOLING BUT NOT ACTIVATED
public class ObjectPooling : MonoBehaviour
{
    //Editor settings for pooling
    [System.Serializable]
    public class Pool
    {

        public string tagDefined;
        public GameObject prefab;
        public int amount;

    }

    //Allowing access of script through pseudo-singleton
    public static ObjectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }


    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> pools;

    // Start is called before the first frame update
    void Start()
    {
        //Creating pool and populating with editor values
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool iPool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < iPool.amount; i++)
            {
                GameObject obj = Instantiate(iPool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);

            }

            poolDictionary.Add(iPool.tagDefined, objectPool);

        }

    }

    public GameObject spawnFromPool(string tag, Vector3 position, Quaternion rotation, Vector3 scale)
    {
        //Error checking if no tag present
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Error Tag not present");
            return null;
        }

        //Setting the dequeue'd object values to object to be spawned
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.transform.localScale = scale;

        IPooled pooled = objectToSpawn.GetComponent<IPooled>();

        if (pooled != null)
        {
            pooled.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
