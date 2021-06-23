using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnDelay = 2.0f;
    public float RepeatInterval = 1.8f;
    Vector3 spawnPos = new Vector3(28, 0, 0);
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnobstacle", spawnDelay, RepeatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnobstacle()
    {
        if(playerController.isGameOver==false)
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
}
