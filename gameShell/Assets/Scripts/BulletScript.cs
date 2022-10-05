using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   
        
    [SerializeField] public bool isEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Debug.Log("Hit Detected: " + other.gameObject);
        }
    }
}
