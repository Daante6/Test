using UnityEngine;

public class ChainCollision2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            Chain2.isFired2 = false;
            Chain2.VinesStop2 = false;
            StaticNameController.player2score += 10;
            col.GetComponent<Ball>().Split();
        }else if (col.tag == "Roof")
        {
            if (StaticNameController.player2VineActive)
            {
                Chain2.VinesStop2 = true;
            }
            else
            {
                Chain2.isFired2 = false;
            }   
        }
    }
}
