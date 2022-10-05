using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 4f;
    [SerializeField] public float _frequency = 6f;
    [SerializeField] public float _distance = 0.75f;

    [SerializeField] public int enemyHitCount = 3;

    [SerializeField] Vector3 _position;
    //[SerializeField] 
    [SerializeField] float sinCenterX;
    // Start is called before the first frame update
    void Start()
    {
        sinCenterX = transform.position.x;
        transform.Rotate(0, 180, -180);
    }

    // Update is called once per frame
    void Update()
    {
        _position = transform.position;
        float _sin = Mathf.Sin(_position.y * _frequency) * _distance;
        _position.x = sinCenterX + _sin;

        _position.y -= moveSpeed * Time.deltaTime;
        transform.Translate(0, -2.5f * Time.deltaTime, 0);
       
        transform.position = _position;
        
    }

    
}
