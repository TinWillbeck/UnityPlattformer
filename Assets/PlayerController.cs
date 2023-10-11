using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float moveX = Input.GetAxisRaw("Horizontal");


        Vector2 movementX = new(moveX, 0);

        transform.Translate(movementX * speed * Time.deltaTime);

        bool isGrounded = Physics2D.OverlapCircle(feet.position, groundRadius, groundLayer);



        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpButton == true && isGrounded)
        {

            rigidbody.AddForce(Vector2.up * jumpForce);

            hasReleasedJumpButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpButton = true;
        }
    }
    private void OnDrawGizmos() 
    {
        if (feet)
        {
            Gizmos.DrawWireSphere(feet.position, groundRadius);
        }
    }
}
