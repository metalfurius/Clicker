using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public float curHealth,maxHealth;
    public float moneyToGive;
    public Image healthBarFill;
    public void Damage(){
        curHealth--;
        FindObjectOfType<AudioManager>().Play("Hit");
        healthBarFill.fillAmount = (float)curHealth / (float)maxHealth;
        if(curHealth<=0){
            Caught();
        }
    }

    public void Caught()
    {
        GameManager.instance.AddMoney(moneyToGive);
        MonsterManager.instance.ReplaceMonster(gameObject);
    }
    public void CantBoss()
    {
        MonsterManager.instance.ReplaceBoss(gameObject);
    }
}
