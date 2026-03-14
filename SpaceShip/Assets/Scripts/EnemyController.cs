using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float minY = -4f;
    public float maxY = 4f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 1.2f;

    private int direction = 1;
    private float fireTimer;

    void Update()
    {
        Move();
        ShootAutomatically();
    }

    void Move()
    {
        Vector3 position = transform.position;
        position.y += direction * speed * Time.deltaTime;

        if (position.y >= maxY)
        {
            position.y = maxY;
            direction = -1;
        }
        else if (position.y <= minY)
        {
            position.y = minY;
            direction = 1;
        }

        transform.position = position;
    }

    void ShootAutomatically()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            fireTimer = 0f;
        }
    }
}
