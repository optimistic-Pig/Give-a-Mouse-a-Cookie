using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveForce;
    public float jumpForce;
    private bool isGrounded = true;
    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
    Debug.Log(isGrounded);
        if(Input.GetKey(KeyCode.D)){
            direction = Vector2.right;
            rb.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
        }
        else if(Input.GetKey(KeyCode.A)){
            direction = Vector2.left;
            rb.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded == true){
        Debug.Log("In Up");
            direction = Vector2.up;
            rb.AddForce(direction.normalized * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }

}
