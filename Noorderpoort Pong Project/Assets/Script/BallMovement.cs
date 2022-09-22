using UnityEngine;
using UnityEngine.Jobs;

public class BallMovement : MonoBehaviour
{
    public float moveSpeed= 4f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(Random.Range(-1f,1f), Random.Range(-1f,1f));
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
        if (collision.gameObject.CompareTag("Paddle"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
        
    }
}
