using UnityEngine;
using UnityEngine.SceneManagement;
public class ZoneLoading : MonoBehaviour
{
    private string[] scenes;
    private int currentScene = 0;
    void Start()
    {
        scenes = new string[] {"Start", "Energy"};
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
Debug.Log("In collision zone");
        if (collision.gameObject.CompareTag("Player")){
            currentScene++;
            SceneManager.LoadScene(scenes[currentScene]);
            
        }
    }
}
