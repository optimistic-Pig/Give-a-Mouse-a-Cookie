using UnityEngine;

public class Cookie : MonoBehaviour
{
    public EnergyBar energyBar;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            energyBar.subtractBar(-4f);
        }
    }
}
