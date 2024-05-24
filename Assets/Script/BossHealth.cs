using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Image HealthCurrent;

    public void UpdateHealthBar(float fillAmount)
    {
        HealthCurrent.fillAmount = fillAmount;
    }

}
