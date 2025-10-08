using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public float moveForce;
    public float jumpForce;
    private bool isGrounded = true;
    private bool isFacingRight = true;
    private Vector2 direction;

    // Update is called once per frame
    private string[] scenes;
    private int currentScene = 0;
    void Start()
    {
        scenes = new string[] {"Start", "Energy"};
    }
    void Update()
    {
        // Input, is the way Unity manages player input, this works for controllers and keyboard//
        //Because these are if condidtions and NOT if else, that means you can do multiple inputs at once

        //Checks if the player is pressing D
        if(Input.GetKey(KeyCode.D))
        {
            //Makes sure the direction of the force applied to the rigid body is to the right
            direction = Vector2.right;
            //Using that right direction, multiplies force in taht direction, then multiplies gradually with impulse
            rb.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
            //Checks if the mouse if facing right, if not then flip the mouse
            if(isFacingRight == false)
            {
                //sr is Sprite Renderer which we pull into the game scene from the mouse game object, we can do this because of the "public" advative
                sr.flipX = true;
                //Makes it so next time it will not flip it if the player is already moving right
                isFacingRight = true;
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            //Make direction left
            direction = Vector2.left;
            rb.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
            //If facing right, make the mlouse face left
            if(isFacingRight == true)
            {
                sr.flipX = false;
                isFacingRight = false;
            }
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded == true)
        {
            //Since force is being applied directionally, just make the direcrtion up to make them jumo
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
        if (collision.gameObject.CompareTag("Zone"))
        {
Debug.Log("in zone");
            currentScene++;
            SceneManager.LoadScene(scenes[currentScene]);
        }
    }

}
