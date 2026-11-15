using System.Collections.Generic;
using UnityEngine;

public class PlayerColors : MonoBehaviour
{
    public Color fullColor;
    public List<Color> colors = new List<Color>();
    Color targetColor;

    PlayerBounceController playerBounce;
    PlayerMovement playerMovement;
    SpriteRenderer sr;
    
    void Start()
    {
        playerBounce = gameObject.GetComponent<PlayerBounceController>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();

        sr = gameObject.GetComponent<SpriteRenderer>();

        targetColor = fullColor;
    }

    public float changespeed;
    
    void Update()
    {
        Color firstColor = colors[0] * (playerBounce.framesForCharge - playerBounce.framesSinceCharge) / playerBounce.framesForCharge;
        Color secondColor =  fullColor * (playerBounce.framesSinceCharge) / playerBounce.framesForCharge;

        sr.color = firstColor + secondColor;

        if(playerBounce.framesSinceCharge == 0 || playerMovement.forceBounce) sr.color = fullColor;
        
        if(playerMovement.forceNotBounce) sr.color = colors[0];

    }
}
