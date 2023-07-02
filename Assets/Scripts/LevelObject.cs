using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{

    public void Spawn(GameObject prefab, bool shouldRotate)
    {
        var instance = Instantiate(prefab);
        instance.transform.position = transform.position;
        if (shouldRotate)
        {
            instance.transform.up = transform.up;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}
