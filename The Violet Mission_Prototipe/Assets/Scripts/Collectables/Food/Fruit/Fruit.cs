using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : FoodInput
{
   
    public override void Collect(Player interactor)
    {
        GameObject.FindWithTag("Inventory").GetComponent<InventoryCounter>().Fruit += 5;

        Destroy(gameObject);
    }

}
