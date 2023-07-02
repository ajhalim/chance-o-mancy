using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LingeringZone : MonoBehaviour
{

    [SerializeField] float dissipateSeconds;
    [SerializeField] Collider2D col;

    Transform parent = null;
    bool deathTriggered = false;

    public void Setup(float size, Transform parent)
    {
        transform.localScale = Vector3.one * size;
        this.parent = parent;
    }

    private void Update()
    {
        if (parent != null)
        {
            transform.position = parent.position;
        }
        else if (!deathTriggered)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(dissipateSeconds);
        col.enabled = false;
        yield return 0;
        Destroy(gameObject);
    }
}
