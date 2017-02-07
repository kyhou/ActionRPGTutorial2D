﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber, enemiesToKill;
    public QuestManager questManager;
    public string startText, endText, targetItem, targetEnemy;
    public bool isItemQuest, isEnemyQuest;

    private int enemyKillCount;

    void Start()
    {

    }

    void Update()
    {
        if (isItemQuest)
        {
            if(questManager.itemCollected == targetItem)
            {
                questManager.itemCollected = null;
                EndQuest();
            }
        }

        if (isEnemyQuest)
        {
            if(questManager.enemyKilled == targetEnemy)
            {
                questManager.enemyKilled = null;
                enemyKillCount++;
            }
            if(enemyKillCount >= enemiesToKill)
            {
                EndQuest();
            }
        }
    }

    public void StartQuest()
    {

        questManager.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        questManager.ShowQuestText(endText);
        questManager.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}