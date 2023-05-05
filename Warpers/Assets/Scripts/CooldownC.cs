using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownC : MonoBehaviour
{
    public Image cooldownImage;
    public float cooldownTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        cooldownImage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer < 3)
        {
            cooldownTimer += Time.deltaTime;
            cooldownImage.fillAmount = cooldownTimer / 3f;
        }
    }

    public void CDc()
    {
        Debug.Log("CDc called!");
        cooldownTimer = 0f;
    }
}
