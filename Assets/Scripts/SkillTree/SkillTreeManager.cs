using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;

    public void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilityPointSpent;
        SkillSlot.OnSkillMaxed += HandleSkillMaxed;
        ExpManager.OnLevelUp += UpdateAbilityPoints;
    }
    public void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilityPointSpent;
        SkillSlot.OnSkillMaxed -= HandleSkillMaxed;
        ExpManager.OnLevelUp -= UpdateAbilityPoints;
    }

    private void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(()=>CheckAvailablePoints(slot));
        }
        UpdateAbilityPoints(0);
    }
    private void CheckAvailablePoints(SkillSlot slot)
    {
        if (availablePoints > 0)
        {
            slot.TryUpgradeSkill();
        }

    }

    private void HandleAbilityPointSpent(SkillSlot skillSlot)
    {
        if (availablePoints > 0)
        {
            UpdateAbilityPoints(-1);
        }
    }

    public void HandleSkillMaxed(SkillSlot skillSlot)
    {
        foreach(SkillSlot slot in skillSlots)
        {
            if(!slot.isUnlocked&&slot.CanUnlockSkill())
            slot.Unlock();
        }
    }
         
    public void UpdateAbilityPoints(int amount)
    {
        availablePoints += amount;
        pointsText.text = "Points:" + availablePoints;
    }
}
