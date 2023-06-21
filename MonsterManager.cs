using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs;
    public GameObject[] bossPrefabs;
    public Monster curMonster;
    public Transform canvas;
    public static MonsterManager instance;
    private float counter;
    private int monsterCount;

    private void Awake() {
        instance = this;
    }
    public void SpawnMonster(){
        if(monsterCount%5==0){
            SpawnBoss();
        }
        else{
            SpawnNormalMonster();
        }
    }

    private void SpawnNormalMonster()
    {
        GameObject monsterToSpawn=monsterPrefabs[Random.Range(0,monsterPrefabs.Length)];
        GameObject obj=Instantiate(monsterToSpawn,canvas);
        curMonster=obj.GetComponent<Monster>();
        counter+=0.05f;
        monsterCount++;
        curMonster.curHealth*=1f+counter;
        curMonster.maxHealth*=1f+counter;
        curMonster.moneyToGive*=1f+counter;
    }

    public void SpawnBoss(){
        GameObject bossToSpawn=bossPrefabs[Random.Range(0,bossPrefabs.Length)];
        GameObject obj=Instantiate(bossToSpawn,canvas);
        curMonster=obj.GetComponent<Monster>();
        counter+=0.05f;
        monsterCount++;
        curMonster.curHealth*=1f+counter;
        curMonster.maxHealth*=1f+counter;
        curMonster.moneyToGive*=1f+counter;
    }
    public void ReplaceMonster(GameObject curMonster){
        Destroy(curMonster);
        FindObjectOfType<AudioManager>().Play("Win");
        SpawnMonster();
    }
    public void ReplaceBoss(GameObject curMonster){
        Destroy(curMonster);
        FindObjectOfType<AudioManager>().Play("Lose");
        SpawnBoss();
    }
}
