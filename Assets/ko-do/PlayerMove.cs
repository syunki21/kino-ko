using UnityEngine;

public class PlayerMove: MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A D / Å© Å®
        float v = Input.GetAxis("Vertical");   // W S / Å™ Å´

        Vector3 move = new Vector3(h, 0f, v) * moveSpeed;
        Vector3 velocity = new Vector3(move.x, rb.velocity.y, move.z);

        rb.velocity = velocity;
    }
}
