using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 1000;
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    Transform feet;
    [SerializeField]
    float groundRadius = 0.2f;

    Rigidbody2D rigidbody;
    bool hasReleasedJumpButton = true;


    
    // Start is called before the first frame update
    void Awake() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    
    
    }

    // Update is called once per frame
    void Update()
    {
        // rörelseinput
        float moveX = Input.GetAxisRaw("Horizontal");

        // rörelsekod
        Vector2 movementX = new(moveX, 0);
        transform.Translate(movementX * speed * Time.deltaTime);

        // kolla om karaktär nuddar marken
        bool isGrounded = Physics2D.OverlapCircle(feet.position, groundRadius, groundLayer);


        // karaktären hoppar om man har tryckt på mellanslag och nuddar marken
        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
        {

            rigidbody.AddForce(Vector2.up * jumpForce);

            hasReleasedJumpButton = false;
        }

        // gör så man kan hoppa igen
        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpButton = true;
        }
    }
    private void OnDrawGizmos() 
    {
        // ritar ut en cirkel där fötterna är
        if (feet)
        {
            Gizmos.DrawWireSphere(feet.position, groundRadius);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
            // gör så att man dör om man nuddar en fiende
            if(other.gameObject.tag == "Enemy")
            {
                Debug.Log("krock");
                SceneManager.LoadScene(1);
            }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // gör så att man dör om man ramlar av en plattform
        if(other.gameObject.tag == "Void")
        {
            Debug.Log("oops");
            SceneManager.LoadScene(1);
        }    
    }    

}
