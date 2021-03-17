using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chain : MonoBehaviour
{
    public static bool isFired;
    public static bool VinesStop;
    public Transform player;
    public float speed;

    public Transform spike;

    public InputAction shoot;

    // Start is called before the first frame update
    void Start()
    {
        isFired = false;
        VinesStop = false;
    }
    void OnEnable()
    {
        shoot.Enable();
    }

    void OnDisable()
    {
        shoot.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (shoot.triggered)
        {
            shootFunction();
        }

        if (isFired)
        {
            if (VinesStop)
            {

            }
            else
            {
                transform.localScale = transform.localScale + Vector3.up * speed * Time.deltaTime;
            }
            
        }
        else
        {
            //transform.position = player.position;
            transform.position = new Vector3(player.position.x,player.position.y - 0.3f,player.position.z);
            transform.localScale = new Vector3(1f, 0f, 1f);
        }
        spike.localScale = new Vector3(.5f, 1f/(transform.localScale.y+0.01f), 1f);
    }
    public void shootFunction()
    {
        isFired = true;
    }
}
