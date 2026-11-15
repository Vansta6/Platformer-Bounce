using UnityEngine;
using UnityEngine.SceneManagement; 

public class Missile : MonoBehaviour
{
    public GameObject player;
    public float startSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.linearVelocity = (Vector2)transform.right * startSpeed;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public float timeBeforeTurn;
    public float timeBeforeLaunch;

    public float launchSpeed;

    float time;
    void FixedUpdate()
    {
        Vector2 targetPoint = player.transform.position;
        Vector2 direction = targetPoint - (Vector2)transform.position;

        if (direction != Vector2.zero && transform.position.y > 0.7 && time < timeBeforeLaunch)
        {
            rb.linearVelocity *= 0.4f;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 4);

            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        }

        if(time > timeBeforeLaunch)
        {
            rb.linearVelocity += (Vector2)transform.right * launchSpeed;
        }

        time++;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Destroy(gameObject);
    }
}
