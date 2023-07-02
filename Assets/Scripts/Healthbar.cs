using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Image healthImage = null;

    public void UpdateHealth(float health, float maxHealth)
    {
        healthImage.fillAmount = health / maxHealth;
    }
}
