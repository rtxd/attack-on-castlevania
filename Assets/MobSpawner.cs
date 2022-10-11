using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject SkeletonPrefab;
    public float leftSpawnPos = -20;
    public float rightSpawnPos = 20;
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            spawnMob();
        }
    }

    void spawnMob()
    {
        
        Vector2 spawnPos = Random.value >= 0.5f ? new Vector2(rightSpawnPos, -0.2f) : new Vector2(leftSpawnPos, -0.2f); 
        GameObject skeleton = Instantiate(SkeletonPrefab, spawnPos, Quaternion.identity);
    }


    
}
