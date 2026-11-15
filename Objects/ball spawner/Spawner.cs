using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public float interval;
    public int spawns;
    public GameObject endSpawnee;

    float time = 0;
    void Start()
    {
        time = interval;
    }

    
    void FixedUpdate()
    {
        if(time % interval == 0)
        {
            if(spawns > 0)
            {
                Instantiate(spawnee, transform.position, spawnee.transform.rotation);
                spawns--;
            }
            else
            {
                Instantiate(endSpawnee, transform.position, transform.rotation);
            }
        }

        time++;
    }
}
