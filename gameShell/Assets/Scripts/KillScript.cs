using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    [SerializeField] public float killTime;
    void Start()
    {
        Destroy(gameObject, killTime);
    }

   
}
