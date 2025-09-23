using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; ++i)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        } 
    }

    public void AppleMissed()
    {
        // remark: FindGameObjectsWithTag is supposedly a somewhat intensive method to call, but since
        // we only invoke the method when an apple falls off the screen, rather than say, every frame as
        // in update or every 1/50th of a second as in FixedUpdate, we may find its use to be acceptable.
        GameObject[] applesInScene = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in applesInScene)
        {
            Destroy(apple);
        }

        int basketIdx = basketList.Count - 1;
        GameObject basketGO = basketList[basketIdx];
        basketList.RemoveAt(basketIdx);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
