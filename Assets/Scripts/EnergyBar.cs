using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    public float energy;
    public bool canJump;
    public GameObject bar;
    
    public void subtractBar(float changeBy){
        energy -= changeBy;
Debug.Log(energy);
        Vector3 scale = new Vector3 (energy, .5f,1f);
        bar.transform.localScale = scale;

        if(energy <= 0.0f){
            canJump = false;
        }
        else if(energy >= 0.0f){
            canJump = true;
        }
    }
}
