using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    private string[] scenes;
    public int currentScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scenes = new string[] {"Start", "Energy", "Cat"};
        currentScene = 0;
        DontDestroyOnLoad(gameObject);
       
    }

    // Update is called once per frame
    public void NextScene()
    {
        ++currentScene;
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(scenes[currentScene]); 
    }
}
