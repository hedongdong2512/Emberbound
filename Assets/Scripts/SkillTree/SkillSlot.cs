using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public List<SkillSlot> prerequisiteSkillSlots;
    public SkillSo skillSo;

    public int currentLevel;
    public bool isUnlocked;
    
    public Image skillIcon;
    public Button skillButton;
    public TMP_Text skillLevelText;

    public static event Action<SkillSlot> OnAbilityPointSpent;
    public static event Action<SkillSlot > OnSkillMaxed;


    private void OnValidate()
    {
        if(skillSo != null&&skillLevelText!=null)
        {
            UpdateUI();
        }
    }
    public void TryUpgradeSkill()
    {
        if(isUnlocked&&currentLevel<skillSo.maxLevel)
        {
            currentLevel++;
            OnAbilityPointSpent?.Invoke(this);
            if(currentLevel >= skillSo.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }
            UpdateUI();
        }
    }
    public bool CanUnlockSkill()
    {
        foreach(SkillSlot slot in prerequisiteSkillSlots)
        {
            if (!slot.isUnlocked || slot.currentLevel < slot.skillSo.maxLevel)
            {
                return false;
            }
        }
        return true;
    }
    public void Unlock()
    {
        isUnlocked = true;
        UpdateUI();
    }
    private void UpdateUI()
    {
          skillIcon.sprite = skillSo.skillIcon;
        if (isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = currentLevel.ToString() + "/" + skillSo.maxLevel.ToString();
            skillIcon.color = Color.white;
        }
        else {
            skillButton.interactable = false;
            skillLevelText.text = "Locked";
            skillIcon.color = Color.gray;
        }
    }
}
