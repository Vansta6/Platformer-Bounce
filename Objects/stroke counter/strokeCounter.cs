using TMPro;
using UnityEngine;

public class strokeCounter : MonoBehaviour
{
    public int strokes = 0;
    public GameObject text;
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("text");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.GetComponent<TextMeshProUGUI>().text = $"strokes: {strokes}";
    }
}
