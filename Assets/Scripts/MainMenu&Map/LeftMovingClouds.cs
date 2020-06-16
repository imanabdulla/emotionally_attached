using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LeftMovingClouds : MonoBehaviour
{
    [Serializable]
    public class CloudPool
    {
        public int size;
        public GameObject prefab;
    }
    public CloudPool cloudPool;
    public float smoothing;
    public Queue<GameObject> cloudsQueue;

    
    GameObject spawnedCloud;
    void Start()
    {
        cloudsQueue = new Queue<GameObject>();
        for (int i = 0; i < cloudPool.size; i++)
        {
            GameObject instance = Instantiate(cloudPool.prefab, transform.position, Quaternion.identity, transform);
            instance.name = instance.name+i;
            instance.SetActive(false);
            cloudsQueue.Enqueue(instance);
        }
        spawnedCloud = SpwanFromCloudPool();
    }

    private void Update()
    {
        float x = spawnedCloud.transform.position.x - (Time.deltaTime * smoothing);
        spawnedCloud.transform.position = new Vector3(x, spawnedCloud.transform.position.y, spawnedCloud.transform.position.z);
        if (x <= -1880)
        {
            ReturnCloudToPool(spawnedCloud);
            spawnedCloud = SpwanFromCloudPool();
        }
    }

    GameObject SpwanFromCloudPool()
    {
        spawnedCloud = cloudsQueue.Dequeue();
        spawnedCloud.SetActive(true);
        return spawnedCloud;
    }

    void ReturnCloudToPool(GameObject spawnedCloud)
    {
        cloudsQueue.Enqueue(spawnedCloud);
        spawnedCloud.transform.position = transform.position;
        spawnedCloud.SetActive(false);
    }
}
