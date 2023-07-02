using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoeSize : MonoBehaviour
{

    //public Transform aoePoint;
    public float damage;
    private float duration;
    public int maxDuration;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.one * damage * 2;
    }

    // Update is called once per frame
    void Update()
    {
        duration += 1 * Time.deltaTime;
        if (duration >= maxDuration)
        {
            Destroy(this.gameObject);
        }
    }
}
