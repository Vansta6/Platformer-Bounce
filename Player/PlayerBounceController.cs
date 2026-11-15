using UnityEngine;

public class PlayerBounceController : MonoBehaviour
{
    public int framesSinceCharge;
    public int framesForCharge = 3;

    PlayerMovement playermove;
    void Start()
    {
        playermove = gameObject.GetComponent<PlayerMovement>();
    }


    void FixedUpdate()
    {
        if(!playermove.canBounce) framesSinceCharge += 1;

        if(framesSinceCharge >= framesForCharge) 
        {
            playermove.canBounce = true;
            framesSinceCharge = 0;
        }
    }
}
