using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPosition = new Vector3(28, 0, 0);

    private float startDelay = 0;
    private float intervalDelay = 1.5f;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, intervalDelay);
    }

    void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.GetGameOverStatut() != true)
        {
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        }
    }

}
