using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Update is called once per frame
    void Update()
    {
        // rörelsekod
        Vector2 movementX = new(speed,0);
        transform.Translate(movementX * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // gör så att om den nuddar en osynlig kant så byter den riktning
        if(other.gameObject.tag == "Edge")
        {
            // Debug.Log("kant");
            speed = -speed;
        }
    }
}
