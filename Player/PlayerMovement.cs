using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector2 mousePos;
    Rigidbody2D rb;
    LineRenderer line;
    public Material lineMat;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        line = gameObject.AddComponent<LineRenderer>();
        line.material = lineMat;

        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        line.positionCount = 2;

        line.startColor = Color.black;
        line.endColor = Color.black;
        
    }

    bool is_mouseDown = false;

    public float speed = 10;
    public bool canBounce = true;
    
    public bool forceBounce = false;
    public bool forceNotBounce = false;

    public float slowTime = 0.3f;
    float deltaTime = 0.02f;
    float time = 1;


    void Update()
    {
        Vector2 screenPos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(screenPos);

        if(Input.GetMouseButtonUp(0) && is_mouseDown)
        {
            GetComponent<strokeCounter>().strokes += 1;

            rb.linearVelocity = (mousePos - rb.position) / (mousePos - rb.position).magnitude * speed;
            canBounce = false;
        }

        if (Input.GetMouseButton(0) && (canBounce || forceBounce) && !forceNotBounce)
        { 
            is_mouseDown = true;
            line.SetPosition(0, rb.position);
            line.SetPosition(1, mousePos);

            if(time > slowTime)
            {
                time = slowTime;
            }
        
        }
        else 
        {
            is_mouseDown = false;
            line.SetPosition(0, Vector2.zero);
            line.SetPosition(1, Vector2.zero);

            time = 1;
        }
        Time.timeScale = time;
        Time.fixedDeltaTime = time * deltaTime;


    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        MonoBehaviour[] scripts = other.gameObject.GetComponents<MonoBehaviour>();

        foreach(MonoBehaviour script in scripts)
        {
            if(script.GetType().Name == "BounceZone")
            {
                if(script.GetComponent<BounceZone>().canBounce)
                {
                    forceBounce = true;
                }
                else
                {
                    is_mouseDown = false;
                    forceNotBounce = true;
                }
            }

            if(script.GetType().Name == "SceneChanger")
            {
                SceneManager.LoadScene(script.GetComponent<SceneChanger>().SceneName);
            }

            if(script.GetType().Name == "ForceTunnel")
            {
                rb.linearVelocity += script.GetComponent<ForceTunnel>().direction * script.GetComponent<ForceTunnel>().speed;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        MonoBehaviour[] scripts = other.gameObject.GetComponents<MonoBehaviour>();

        foreach(MonoBehaviour script in scripts)
        {
            if(script.GetType().Name == "BounceZone")
            {

                if(script.GetComponent<BounceZone>().canBounce)
                {
                    is_mouseDown = false;
                    forceBounce = false;
                }
                else
                {
                    forceNotBounce = false;
                }
            }
        }
    }
}
