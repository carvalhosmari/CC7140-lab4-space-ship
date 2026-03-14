using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCooldown = 0.3f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("bulletPrefab não foi atribuído ou foi destruído.");
            return;
        }

        if (firePoint == null)
        {
            Debug.LogError("firePoint não foi atribuído.");
            return;
        }

        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }
}
