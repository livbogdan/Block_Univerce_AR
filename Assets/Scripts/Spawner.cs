using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("Amount of spawning objects")]
    public int numberToSpawn;
    [Tooltip("Lilst of game game objects with tag (Blocks)")]
    public List<GameObject> spawnPool;
    [Tooltip("Spawning ground")]
    public GameObject plane;

    void Start()
    {
        spawnObjects();
    }

    public void spawnObjects()
    {
        destroyObjects();
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider collider = plane.GetComponent<MeshCollider>();

        float screenX;
        float screenY;
        float screenZ;
        Vector3 position;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            screenY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            screenZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);
            position = new Vector3(screenX, screenY, screenZ);

            Instantiate(toSpawn, position, toSpawn.transform.rotation);

        }
    }
    private void destroyObjects()
    {
        foreach (GameObject blocks in GameObject.FindGameObjectsWithTag("Blocks"))
        {
            Destroy(blocks);
            Builder.score = 0;
        }
    }

}