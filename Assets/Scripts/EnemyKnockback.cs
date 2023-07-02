using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] EnemyMovement movement = null;
    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] Collider2D earthCollider = null;
    [SerializeField] aoeScript aoeScript = null;
    [SerializeField] ParticleSystem[] earthParticles = null;

    const float KNOCKBACK_DURATION = 0.2f;
    const float KNOCKBACK_STRENGTH = 30f;

    public void Knockback(float damage, Vector2 dir)
    {
        StartCoroutine(StunCorountine(damage, dir));
    }

    IEnumerator StunCorountine(float damage, Vector2 dir) {
        movement.enabled = false;
        aoeScript.damage = damage;
        earthCollider.enabled = true;
        foreach (var particles in earthParticles)
        {
            particles.Play();
        }

        rb.velocity = dir * (KNOCKBACK_STRENGTH + damage * 2);
        yield return new WaitForSeconds(KNOCKBACK_DURATION);
        rb.velocity = Vector2.zero;


        movement.enabled = true;
        earthCollider.enabled = false;
        foreach (var particles in earthParticles)
        {
            particles.Stop();
            //particles.Clear();
        }
    }
}
