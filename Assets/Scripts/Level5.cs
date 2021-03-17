using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : MonoBehaviour
{
    public GameObject Door;
    private bool doorDestroyed = false;
    // Update is called once per frame
    void Update()
    {
        GameObject[] objectsCount = GameObject.FindGameObjectsWithTag("Ball");
        if (objectsCount.Length == 1 && doorDestroyed == false)
        {
            Destroy(Door);
            doorDestroyed = true;
        }
    }
}
