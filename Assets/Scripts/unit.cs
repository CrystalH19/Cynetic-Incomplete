using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public bool TakeDamage()
    {
        int maxDmg = damage + 10;
        int dmg = Random.Range(damage, maxDmg);
        currentHP -= dmg;
        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void heal()
    {
        int amount = Random.Range(1, 10);
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
