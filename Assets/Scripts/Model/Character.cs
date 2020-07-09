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

    public int security { get; set; }

    public int money { get; set; }

    public Country country { get; set; }

    public Department department { get; set; }
    

}
