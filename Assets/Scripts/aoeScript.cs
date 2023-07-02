using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoeScript : MonoBehaviour
{
    public float damage;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy" && other.transform != transform.root)
        {
            other.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
        }
    }

}
