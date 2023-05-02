using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyValue : MonoBehaviour
{
    public int cashValue = 1;

    public void getMoney()
    {
        IInventory inventory = GetComponent<IInventory>();

        if (inventory != null)
        {
            inventory.Money = inventory.Money + cashValue;
            print("Player inventory has " + inventory.Money + " money in it.");
            //gameObject.SetActive(false);
        }
    }
}
