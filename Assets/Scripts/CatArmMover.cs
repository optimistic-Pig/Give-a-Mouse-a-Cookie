using System;
using UnityEngine;

public class CatArmMover : MonoBehaviour 
{
    //Link to what taught me how to rotate an object in Unity https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/
    void rotationPos()
    {
        int degreesPerSecond = 30;
        transform.Rotate(new Vector3(0,0, degreesPerSecond) * Time.deltaTime);
    }
    void rotationNeg()
    {
        int degreesPerSecond = -45;
        transform.Rotate(new Vector3(0,0, degreesPerSecond) * Time.deltaTime);
    }
    void Update()
    {
        rotationNeg();
    }
}
