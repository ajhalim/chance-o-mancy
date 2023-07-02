using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    enum Status { Idle, Approach, Retreat }

    [Header("References")]
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] Transform visuals = null;
    [SerializeField] Animator anim = null;
    [SerializeField] ParticleSystem slowParticles = null;

    [Header("Settings")]
    float slowEndTime = 0; // global variable
    [SerializeField] float baseSpeed = 10f;
    float currentSpeed;

    [Header("Distances")]
    [SerializeField] float approachDistance = 10f;
    [SerializeField] float retreatDistance = 5f;
    [SerializeField] [Range(0f, 0.5f)] float idleThickness;
    float idleInner
    {
        get { return Mathf.Lerp(retreatDistance, approachDistance, idleThickness); }
    }
    float idleOuter
    {
        get { return Mathf.Lerp(approachDistance, retreatDistance, idleThickness); }
    }

    [Header("Line of sight")]
    [SerializeField] bool requiresLOS = true;
    [SerializeField] LayerMask visionBlocker = default;
    bool canSeePlayer = false;


    Status status;
    Transform player;


    void Start()
    {
        slowEndTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Could not find the player! Probably forgot to tag it with \"player\"");
        }

        slowParticles.Stop();
    }

    public void slowDown(float duration)
    {
        slowParticles.Play();
        slowEndTime = Mathf.Max(slowEndTime, Time.time + duration); // update slow end time if the newly applied one ends later
    }

    void Update()
    {
        if (slowEndTime < Time.time)
        {
            currentSpeed = baseSpeed;
            if (slowParticles.isPlaying)
            {
                slowParticles.Stop();
            }
        }
        else
        {
            currentSpeed = baseSpeed / 4;
            print("slowed!");
        }

        UpdateStatus();
        Move();
    }

    void UpdateStatus()
    {
        Vector2 dirToPlayer = player.position - transform.position;
        float distToPlayer = dirToPlayer.magnitude;

        canSeePlayer = !Physics2D.Raycast(transform.position, dirToPlayer, distToPlayer, visionBlocker);

        if (requiresLOS && !canSeePlayer)
        {
            status = Status.Idle;
        }
        else if (distToPlayer <= idleOuter && distToPlayer >= idleInner)
        {
            status = Status.Idle;
        }
        else if (distToPlayer >= approachDistance)
        {
            status = Status.Approach;
        }
        else if (distToPlayer <= retreatDistance)
        {
            status = Status.Retreat;
        }

    }

    void Move()
    {
        Vector2 dirToPlayer = player.position - transform.position;
        Vector2 movementDir = Vector2.zero;

        switch (status)
        {
            case (Status.Approach):
                movementDir = dirToPlayer.normalized;
                break;
            case (Status.Retreat):
                movementDir = -dirToPlayer.normalized;
                break;
            case (Status.Idle):
                movementDir = Vector2.zero;
                break;
        }

        rb.MovePosition(rb.position + movementDir.normalized * currentSpeed * Time.fixedDeltaTime);

        anim.SetBool("isMoving", status != Status.Idle);

        if (!requiresLOS || (requiresLOS && canSeePlayer))
        {
            //visuals.up = dirToPlayer;
        }
        else
        {
            //visuals.up = Vector3.up;
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, retreatDistance);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, approachDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, idleInner);
        Gizmos.DrawWireSphere(transform.position, idleOuter);
    }
}
