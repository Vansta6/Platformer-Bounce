using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndLevelOnSpawn : MonoBehaviour
{
    public string level;
    void Start()
    {
        SceneManager.LoadScene(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
