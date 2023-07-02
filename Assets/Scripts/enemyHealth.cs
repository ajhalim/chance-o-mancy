using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{

    [SerializeField] float maxHealth;
    [SerializeField] Healthbar healthbar = null;
    [SerializeField] ParticleSystem universeParticleSystem = null;
    [SerializeField] ParticleSystem burnParticleSystem = null;
    [SerializeField] GameObject floatingTextPrefab;

    float health;

    int universeCounter;

    private void Start()
    {
        health = maxHealth;
        universeParticleSystem.Stop();
        burnParticleSystem.Stop();
    }

    public void TakeDamage(float amount)
    {
        if (universeCounter > 0)
        {
            Debug.Log($"Damage {amount}x2 = {amount * 2}");
            amount *= 2;
        } else {
            Debug.Log($"Damage {amount}");
        }

        health -= amount;
        healthbar.UpdateHealth(health, maxHealth);

        var floatingTextInstance = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        var child = floatingTextInstance.transform.GetChild(0);
        child.localScale = Vector3.one * Mathf.Max(1f, amount * 0.2f);

        if (universeCounter > 0)
        {
            child.GetComponent<TextMesh>().text = $"{amount}\nDOUBLED!";
        }
        else
        {
            child.GetComponent<TextMesh>().text = $"{amount}";
        }
        
        
        Destroy(floatingTextInstance, 1f);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void burnOverTime(float burnDamage, float burnStacks)
    {
        StartCoroutine(burnOverTimeCouroutine(burnDamage, burnStacks));
    }

    IEnumerator burnOverTimeCouroutine(float burnDmg, float burnDuration)
    {
        burnParticleSystem.Play();
        while (true)
        {
            TakeDamage(burnDmg);
            burnDuration--;
            //print(burnDuration);

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "universeZone")
        {

            if (universeCounter == 0)
            {
                universeParticleSystem.Play();
            }
            ++universeCounter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "universeZone")
        {
            --universeCounter;
            if (universeCounter < 0)
            {
                Debug.LogError("Universe counter is less than 0. something's gone wrong.");
                universeCounter = 0;
            }

            if (universeCounter == 0)
            {
                universeParticleSystem.Stop();
            }
        }
    }

    public float GetHealth() {
        return health;
    }
}
