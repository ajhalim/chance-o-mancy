using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    [SerializeField] TrailRenderer rend = null;
    [SerializeField] Vector2 direction = default;

    void Update()
    {
        rend.material.SetTextureOffset("_MainTex", direction * Time.time);
    }
}
