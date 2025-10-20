using System;
using UnityEngine;

public class CatArmMover : MonoBehaviour 
{
    //Link to what taught me how to rotate an object in Unity https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/
    void rotationPos()
    {
        Vector2 rotPerFramePos = new Vector2(0, 2);
        transform.Rotate(rotPerFramePos);
    }
    void rotationNeg()
    {
        Vector2 rotPerFrameNeg = new Vector2(0, -1);
        transform.Rotate(rotPerFrameNeg);
    }

    void Update()
    {
        for (int gameRunning = 0; gameRunning <999; gameRunning++)
        {
            for (int i = 0; i < 30; i++)
            {
                rotationPos();
            }
            for (int i = 0; i < 30; i++) 
            { 
                rotationNeg();
            }
        }
    }
}
