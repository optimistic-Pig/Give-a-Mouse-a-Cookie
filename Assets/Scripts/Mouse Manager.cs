using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public EnergyBar energyBar;
    public float moveForce;
    public float jumpForce;
    private bool isGrounded = true;
    private bool isFacingRight = true;
    private Vector2 direction;

    // Update is called once per frame
    private string[] scenes;
    public int currentScene = 0;
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
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded == true && energyBar.canJump)
        {
            //Since force is being applied directionally, just make the direcrtion up to make them jumo
            direction = Vector2.up;
            rb.AddForce(direction.normalized * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
//Whenever the collider of the mouse touches a different collider this is called, collision is that other collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check the tag to decide what to d0
        //Death, is checking if the other collider will kill the player. So an enemy or the death plane
        if (collision.gameObject.CompareTag("Death"))
        {
            //scene manager controlls which scene to load from the possible options
            SceneManager.LoadScene(scenes[currentScene]);
        }
        //If it is ground keep track of the is Grounded boolean which will allow or disallow the player to jump, also to make sure energy is used when you jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if(energyBar.energy > 0.0f)
            {
                energyBar.subtractBar(.5f);
            }
            
        }
        if (collision.gameObject.CompareTag("Zone"))
        {
Debug.Log("in zone");
            currentScene++;
            energyBar.setEnergy(4f);
            SceneManager.LoadScene(scenes[currentScene]);
        }
        if(collision.gameObject.CompareTag("Cookie"))
        {
            Destroy(collision.gameObject);
            energyBar.subtractBar(-4f);
        }
    }
}
