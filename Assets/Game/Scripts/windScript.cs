using UnityEngine;
using Unity.Netcode;

public class windScript : NetworkBehaviour
{
    public float moveSpeed = 2f;
    public float floatForce = 3f;
    public float maxVy = 1.5f;
    private Rigidbody2D rb;

    void Start() { 
        rb = GetComponent<Rigidbody2D>(); 
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!IsOwner) { return; }
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);
        if (rb.linearVelocityY >= maxVy) {  rb.linearVelocityY = maxVy;}
        if (Input.GetKey(KeyCode.W)) // float up
            rb.linearVelocityY += 1f;

    }
}

