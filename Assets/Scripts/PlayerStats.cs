using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLvl, currentExp, currentHp, currentAtack, currentDefence;
    public int[] expToLvlUp, hpLvl, attackLvl, defenceLvl;

    private PlayerHealthManager playerHp;

    void Start()
    {
        currentHp = hpLvl[currentLvl];
        currentAtack = attackLvl[currentLvl];
        currentDefence = defenceLvl[currentLvl];
        playerHp = FindObjectOfType<PlayerHealthManager>();
    }

    void Update()
    {
        if (currentLvl < expToLvlUp.Length)
        {
            if (currentExp >= expToLvlUp[currentLvl])
            {
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        currentLvl++;
        currentHp = hpLvl[currentLvl];

        playerHp.maxHP = currentHp;
        playerHp.currentHP += currentHp - hpLvl[currentLvl - 1];

        currentAtack = attackLvl[currentLvl];
        currentDefence = defenceLvl[currentLvl];
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
    }
}