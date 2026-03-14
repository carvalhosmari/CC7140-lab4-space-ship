using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    void Update()
    {
        float move = Input.GetAxisRaw("Vertical");
        Vector3 position = transform.position;
        position.y += move * speed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
