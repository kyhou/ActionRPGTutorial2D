using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHP, currentHP;

    private SFXManager sfxManager;

    void Start()
    {
        currentHP = maxHP;

        sfxManager = FindObjectOfType<SFXManager>();
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            sfxManager.playerDead.Play();
            gameObject.SetActive(false);
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHP -= damageToGive;
        sfxManager.playerHurt.Play();
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
    }
}