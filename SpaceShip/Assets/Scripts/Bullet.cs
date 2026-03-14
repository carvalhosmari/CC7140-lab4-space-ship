using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 1;
    public string targetTag;
    public Vector2 direction = Vector2.right;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 12f || Mathf.Abs(transform.position.y) > 7f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
