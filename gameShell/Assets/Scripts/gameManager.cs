using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] public float spawnTime = 2f;
    [SerializeField] public GameObject enemyShip;
    [SerializeField] private bool gamePlay;
    // Start is called before the first frame update
    void Start()
    {
        gamePlay = true;
        InvokeRepeating("SpawnShip", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnShip()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-2.5f, 2.5f), 12, 0);
        Instantiate(enemyShip, spawnPosition, Quaternion.identity);
    }
}
