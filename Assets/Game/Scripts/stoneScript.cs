using UnityEngine;
using Unity.Netcode;

public class StoneGolemMovement : NetworkBehaviour
{
    public float moveSpeed = 3f;
    public float uplift = 5f;
    private Rigidbody2D rb;


    void Start() {
        rb = GetComponent<Rigidbody2D>(); 
        rb.freezeRotation = true;
    }

    void Update()
    {
        if(!IsOwner) return;
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
            rb.AddForce(Vector2.up *uplift, ForceMode2D.Impulse);
    }
}
 