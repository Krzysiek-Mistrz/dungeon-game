using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour 
{
    // text fields
    public Text levelText, hitPointText, coinsText, upgradeCostText, xpText;

    // logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    // character selection
    public void OnArrowClick(bool right)
    {
        if (right) 
        {
            currentCharacterSelection++;

            // if no more characters
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else 
        {
            currentCharacterSelection--;

            // if no more characters
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }
    }

    // character sprite swap
    public void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

    // weapon upgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    // update character info
    public void UpdateMenu()
    {
        // weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        // meta
        hitPointText.text = GameManager.instance.player.hitPoint.ToString();
        coinsText.text = GameManager.instance.coins.ToString();
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();

        // xp
        if (GameManager.instance.GetCurrentLevel() == GameManager.instance.xpTable.Count)
        {
            // displaying total xp if max level
            xpText.text = GameManager.instance.experience.ToString() + " XP";
            xpBar.localScale = new Vector3(0.5f, 0, 0);
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(GameManager.instance.GetCurrentLevel() - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(GameManager.instance.GetCurrentLevel());
            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;
            float completionRatio = (float)currXpIntoLevel / diff;
            xpBar.localScale = new Vector3(completionRatio, 0.45f, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff.ToString();
        }
    }
}
