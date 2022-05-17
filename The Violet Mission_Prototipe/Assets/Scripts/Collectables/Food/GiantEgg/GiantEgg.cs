using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantEgg : FoodInput
{
    public override void Collect(Player interactor)
    {
        GameObject.FindWithTag("Inventory").GetComponent<InventoryCounter>().GiantEgg += 1;

        Destroy(gameObject);
    }
}
