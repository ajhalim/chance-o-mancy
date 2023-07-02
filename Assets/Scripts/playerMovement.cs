using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    [SerializeField] Animator anim = null;
    [SerializeField] ParticleSystem airParticleSystem = null;

    Vector2 movement;
    int airCounter = 0;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        float modifiedMoveSpeed = (airCounter > 0) ? moveSpeed * 2 : moveSpeed;
        rb.MovePosition(rb.position + movement.normalized * modifiedMoveSpeed * Time.fixedDeltaTime);
        anim.SetBool("isMoving", movement.magnitude > 0.01);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "airZone")
        {

            if (airCounter == 0)
            {
                airParticleSystem.Play();
            }
            ++airCounter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "airZone")
        {
            --airCounter;
            if (airCounter < 0)
            {
                Debug.LogError("Air counter is less than 0. something's gone wrong.");
                airCounter = 0;
            }

            if (airCounter == 0)
            {
                airParticleSystem.Stop();
            }
        }
    }

}
