using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    [SerializeField] Text textHp;
    [SerializeField] Text textHunger;
    [SerializeField] Text textThirst;
    static int MaxHP = 100;
    static int MaxHunger = 100;
    static int MaxThirst = 100;

    int currentHP =100;
    int currentHunger =100;
    int currentThirst =100;

    void StartStat()
    {
        textHp.text = currentHP.ToString();
        textHunger.text = currentHunger.ToString();
        textThirst.text = currentThirst.ToString();
    }
    private void Start()
    {
        StartStat();
    }
    public void StatManager(int hp, int hunger, int thirst)
    {
        if (currentHP <= MaxHP)
        {
            currentHP += hp;
            if(currentHP>MaxHP)currentHP = MaxHP;
        }
        if(currentHunger <= MaxHunger) {
            currentHunger += hunger;
            if (currentHunger > MaxHunger) currentHunger = MaxHunger;
        }
        if (currentThirst <= MaxThirst)
        {
            currentThirst += thirst;
            if (currentThirst > MaxThirst) currentThirst = MaxThirst;
        }
        StatText();
        void StatText()
        {
            textHp.text=currentHP.ToString();
            textHunger.text=currentHunger.ToString();
            textThirst.text=currentThirst.ToString();
        }

    }
    
}
