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
        if(Input.GetKey(KeyCode.D))
        {
            direction = Vector2.right;
            rb.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
            if(isFacingRight == false)
            {
                sr.flipX = true;
                isFacingRight = true;
            }
        }
        if(Input.GetKey(KeyCode.A))
        {
            direction = Vector2.left;
            rb.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
            if(isFacingRight == true)
            {
                sr.flipX = false;
                isFacingRight = false;
            }
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded == true)
        {
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
        if (collision.gameObject.CompareTag("Zone"))
        {
Debug.Log("in zone");
            currentScene++;
            SceneManager.LoadScene(scenes[currentScene]);
        }
    }

}
