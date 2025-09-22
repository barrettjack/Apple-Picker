using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float offScreenThresh = -20f; // Remark: static fields do not appear in the inspector.

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < offScreenThresh)
        {
            Destroy(this.gameObject); // `this` refers to this instance of the Apple (script) component
            // So, Destroy(this); is not what we want. Rather, we want to destroy a GameObject from within
            // an attached component class.
        }
    }
}
