using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class diceScript : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb = null;
    [SerializeField] TMP_Text faceText;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite d4, d6, d8, d12, d20;
    [SerializeField] GameObject fire, earth, air, universe, water;
    [SerializeField] GameObject fireAoe, waterAoe, universeZone, airZone, rockSoundTrigger;
    public Transform dicePoint;

    public int diceNum;
    public string diceElem;

    int damage;

    public void Setup(Vector3 force, int num, string elem)
    {
        diceNum = num;
        diceElem = elem;

        // update visuals
        damage = Random.Range(1, num + 1); // +1 because Random.Range is exclusive
        faceText.text = damage.ToString();

        switch (num)
        {
            case 4:
                sprite.sprite = d4;
                break;
            case 6:
                sprite.sprite = d6;
                break;
            case 8:
                sprite.sprite = d8;
                break;
            case 12:
                sprite.sprite = d12;
                break;
            case 20:
                sprite.sprite = d20;
                break;
            default:
                break;
        }

        // elemental effects
        fire.SetActive(false);
        earth.SetActive(false);
        air.SetActive(false);
        universe.SetActive(false);
        water.SetActive(false);
        switch (elem)
        {
            case "fire":
                fire.SetActive(true);
                break;
            case "earth":
                earth.SetActive(true);
                break;
            case "wind":
                air.SetActive(true);
                break;
            case "universe":
                universe.SetActive(true);
                break;
            case "water":
                water.SetActive(true);
                break;
            default:
                break;
        }

        rb.AddForce(force, ForceMode2D.Impulse);

        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }

        //Fire
        if (diceElem == "fire")
        {
            Instantiate(fireAoe, dicePoint.position, dicePoint.rotation).GetComponent<aoeSize>().damage = damage;

            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, damage);
            foreach (Collider2D collider2D in colliderArray)
            {
                if (collider2D.gameObject.tag == "enemy")
                {
                    // collider2D.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
                    collider2D.gameObject.GetComponent<enemyHealth>().burnOverTime(damage / 3, damage);
                }
            }
        }
        //Water 
        if (diceElem == "water")
        {
            if (other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
            }

            Instantiate(waterAoe, dicePoint.position, dicePoint.rotation).GetComponent<aoeSize>().damage = damage;

            Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, damage);
            foreach (Collider2D collider2D in colliderArray)
            {
                if (collider2D.gameObject.tag == "enemy")
                {
                    collider2D.gameObject.GetComponent<EnemyMovement>().slowDown(damage);
                }
            }
        }
        // Earth
        if (diceElem == "earth")
        {
            if (other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
                other.gameObject.GetComponent<EnemyKnockback>().Knockback(damage, transform.up);
            }
            Instantiate(rockSoundTrigger, dicePoint.position, dicePoint.rotation);
        }

        // Universe
        if (diceElem == "universe")
        {
            if (other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
            }

            var zoneInstance = Instantiate(universeZone, dicePoint.position, dicePoint.rotation).GetComponent<LingeringZone>();
            if (other.gameObject.tag == "enemy")
            {
                zoneInstance.Setup(3 + damage, other.transform);
            }
            else
            {
                zoneInstance.Setup(3 + damage, null);
            }
        }

        // Air
        if (diceElem == "wind")
        {
            if (other.gameObject.tag == "enemy")
            {
                other.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
            }

            var zoneInstance = Instantiate(airZone, dicePoint.position, dicePoint.rotation).GetComponent<LingeringZone>();
            if (other.gameObject.tag == "enemy")
            {
                zoneInstance.Setup(10.0f + damage * 1.5f, other.transform);
            }
            else
            {
                zoneInstance.Setup(10.0f + damage * 1.5f, null);
            }
        }


        if (other.gameObject.tag == "enemy" &&
            diceElem == "earth" &&
            other.gameObject.GetComponent<enemyHealth>().GetHealth() <= 0)
        {
            Instantiate(rockSoundTrigger, dicePoint.position, dicePoint.rotation);
            // enemy was killed, so don't destroy projectile.
            // This allows for satisfying "bowling" moments.
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
