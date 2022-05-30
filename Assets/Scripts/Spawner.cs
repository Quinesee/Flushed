using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject spawned;

    [SerializeField]
    float spawnTimerTime = 2f;

    [SerializeField]
    bool isActive = false;

    float spawnTimer = 0f;

    void Start()
    {
        spawnTimer = spawnTimerTime;
    }

    void Update()
    {
        if (isActive)
        {
            if (spawnTimer <= 0)
            {
                Spawn();
                spawnTimer = spawnTimerTime;
            }

            spawnTimer -= Time.deltaTime;
        }
    }

    void Spawn()
    {
        GameObject newObj =
            Instantiate(spawned, transform.position, Quaternion.identity);
    }

    public void Activate()
    {
        isActive = true;
    }
}
