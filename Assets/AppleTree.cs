using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirProba = 0.02f;
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }  

    // Update is called once per frame
    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        // Remark: leaving the following update code here makes changes in direction
        // not time-based, but instead frame-time-based, which is not desirable!
        //else if (Random.value < changeDirProba)
        //{
        //    speed = -1.0f * speed;
        //}
    }

    private void FixedUpdate() // Remark: FixedUpdate gets called 50 times per second.
    // Note how changes to the update frequency would change the expected number of dir-
    // ection changes per second!
    {
        if (Random.value < changeDirProba)
        {
            speed *= -1;
        }
    }
}
