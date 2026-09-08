using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public TMP_Text healthText;
    public Animator helthTextAnim;

    private void Start()
    {
        healthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;
        helthTextAnim.Play("TextUpdate");
        healthText.text = "HP:" + StatsManager.Instance.currentHealth + "/" + StatsManager.Instance.maxHealth;
        if (StatsManager.Instance.currentHealth <=0)
        {
            gameObject.SetActive(false);
        }
    }
}
