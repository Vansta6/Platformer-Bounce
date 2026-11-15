using UnityEngine;
using UnityEngine.SceneManagement; 

public class DeathBall : MonoBehaviour
{
    Rigidbody2D rb;
    public float startVelRandom = 1.2f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(Random.Range(-startVelRandom, startVelRandom), Random.Range(-startVelRandom, startVelRandom));
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
