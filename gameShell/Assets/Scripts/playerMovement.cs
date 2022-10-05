using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float shipSpeed = 4f; // controls the ships speed 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vMove = Input.GetAxisRaw("Horizontal"); // allows the use of the arrow keys left right or A D to move horizontally 
        transform.Translate(vMove * shipSpeed * Time.deltaTime, 0, 0); // allows player to move left or right 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -14, 14), transform.position.y, transform.position.z); // doesn't allow the player to move beyond the certain points that are set -3, 3 respectively

    }
}
