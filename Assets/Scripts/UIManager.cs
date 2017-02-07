using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider HpBar, ExpBar;
    public Text HpText, ExpText, lvlText;
    public PlayerHealthManager playerHP;
    private PlayerStats playerStats;

    private static bool UIExists;

    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        HpBar.maxValue = playerHP.maxHP;
        HpBar.value = playerHP.currentHP;
        HpText.text = "HP: " + playerHP.currentHP + "/" + playerHP.maxHP;

        if (playerStats.currentLvl < playerStats.expToLvlUp.Length)
        {

            ExpBar.maxValue = playerStats.expToLvlUp[playerStats.currentLvl];
            ExpText.text = "Exp: " + playerStats.currentExp + "/" + playerStats.expToLvlUp[playerStats.currentLvl];
            lvlText.text = "LvL: " + playerStats.currentLvl;
        }

        ExpBar.value = playerStats.currentExp;
        
    }
}