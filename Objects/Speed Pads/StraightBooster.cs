using UnityEngine;

public class StraightBooster : MonoBehaviour
{
    public float speedAdd = 10;
    void OnCollisionEnter2D(Collision2D collision)
    {
        float rot = transform.eulerAngles.z;
        Vector2 directionVector = transform.right;
        collision.rigidbody.linearVelocity += directionVector * speedAdd;
    }
}
