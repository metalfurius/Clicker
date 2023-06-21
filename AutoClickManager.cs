using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoClickManager : MonoBehaviour
{
    public List<float> autoClicker=new List<float>();
    public float autoClickerPrice;
    public TextMeshProUGUI autoClickerCountText;
    public TextMeshProUGUI autoClickerPriceText;
    private void Update() {
        for (int i = 0; i < autoClicker.Count; i++)
        {
            if(Time.time-autoClicker[i]>=1.0f){
                autoClicker[i]=Time.time;
                MonsterManager.instance.curMonster.Damage();
            }
        }
    }
    public void OnBuyAutoClicker(){
        if(GameManager.instance.money>=autoClickerPrice){
            GameManager.instance.TakeMoney(autoClickerPrice);
            autoClicker.Add(Time.time);
            autoClickerCountText.text="x "+autoClicker.Count.ToString();
            autoClickerPrice*=1.1f;
            autoClickerPrice+=4f;
            autoClickerPriceText.text="Buy clicker:"+autoClickerPrice.ToString("0");
        }
    }
}
