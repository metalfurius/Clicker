using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float money;
    public TextMeshProUGUI moneyText;
    public static GameManager instance;
    private void Awake() {
        instance = this;
    }
    public void AddMoney(float amount){
        money += amount;
        moneyText.text = money.ToString("0");
    }
    public void TakeMoney(float amount){
        money -= amount;
        moneyText.text = money.ToString("0");
    }
    public void GameOver(){
        Debug.Log("Game Over");
        FindObjectOfType<Monster>().CantBoss();
    }
}
