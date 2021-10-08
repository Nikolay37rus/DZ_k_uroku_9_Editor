using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Art : MonoBehaviour
{
    [Header("Характеристики")]
    public int HP;
    public int Armor;
    [Space(10)]
    public int Mana;
    public int Money;
    public int Gold;
    [Space(40)]
    public int Wood;
    [HideInInspector]
    public GameObject Object_;
    public string Text_;
    public int Old;
}
