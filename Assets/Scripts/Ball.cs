using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector2 startForce;

    public Rigidbody2D rb;
    public int wysokosc;
    private int rand;
    public GameObject nextBall;
    public GameObject bonusVines;
    public GameObject bonusPoints;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(startForce,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Split()
    {
        if (nextBall != null)
        {
            GameObject Ball1 = Instantiate(nextBall, rb.position + Vector2.right/4f ,Quaternion.identity);
            GameObject Ball2 = Instantiate(nextBall, rb.position + Vector2.left/4f,Quaternion.identity);

            Ball1.GetComponent<Ball>().startForce = new Vector2(2f, 5f);
            Ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 5f);
        }
        rand = Random.Range(0, 10);
        switch (rand)
        {
            case 0:
                GameObject BONUS1 = Instantiate(bonusVines, rb.position, Quaternion.identity);
                break;
            case 1:
                GameObject BONUS2 = Instantiate(bonusPoints, rb.position, Quaternion.identity);
                break;
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            rb.AddForce(new Vector2(0f, wysokosc), ForceMode2D.Impulse);
        }else if (collision.collider.tag == "Roof")
        {
            Destroy(gameObject);
        }
    }
}
