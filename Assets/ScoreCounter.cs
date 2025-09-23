using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>(); // this is a relatively slow method, so best to bind to a reference at start
                                       // rather than call on every frame.
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = score.ToString("#,0");
    }
}
