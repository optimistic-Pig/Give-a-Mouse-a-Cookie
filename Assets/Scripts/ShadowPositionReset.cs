using UnityEngine;

public class ShadowPositionReset : MonoBehaviour
{
    private Vector3 spawnPoint;
    void Start()
    {
        spawnPoint = transform.position;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision between Mouse and " + collision.gameObject + " detected");
        if (collision.gameObject.CompareTag("Shadow"))
        {
            Debug.Log("Position Reset Parameters met");
            transform.position = spawnPoint;
        }
    }
}
