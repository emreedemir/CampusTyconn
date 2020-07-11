using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Character 
{
    public string characterName { get; set; }

    public string characterGender { get; set; }

    public int health { get; set; }

    public int morela { get; set; }

    public int respect { get; set; }

    public int selfRealization { get; set; }

    public int money { get; set; }

    public int deltaDay { get; set; }

    public Country country { get; set; }

    public Department department { get; set; }
  
    public int creditFee;

    public Character()
    {
        creditFee = 0;
        health = 50;
        morela = 50;
        respect = 50;
        selfRealization = 50;
        money = 100000;
    }
}
