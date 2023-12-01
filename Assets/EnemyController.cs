using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float speed;
    
    public int multiplier = 1;

    void Update()
    {
        // rörelsekod, en vektor som får input i X axeln och är noll i Y axeln
        Vector2 movementX = new(speed,0);
        // här uppdateras fiendens position med vektorn * en multiplier som inte används just nu * en kontroll som gör att rörelsen inte blir beroende av fps.
        transform.Translate(movementX * multiplier * Time.deltaTime);
        
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
