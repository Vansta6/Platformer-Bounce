using UnityEngine;

public class SpeedPad : MonoBehaviour
{

    public float speedMult;
    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.linearVelocity = collision.rigidbody.linearVelocity / collision.rigidbody.linearVelocity.magnitude * speedMult;
    }
}
