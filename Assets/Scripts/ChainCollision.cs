using UnityEngine;

public class ChainCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ball")
        {
            Chain.isFired = false;
            Chain.VinesStop = false;
            StaticNameController.player1score += 10;
            col.GetComponent<Ball>().Split();
        }else if (col.tag == "Roof")
        {
            if (StaticNameController.player1VineActive)
            {
                Chain.VinesStop = true;
            }
            else
            {
                Chain.isFired = false;
            }   
        }
    }
}
