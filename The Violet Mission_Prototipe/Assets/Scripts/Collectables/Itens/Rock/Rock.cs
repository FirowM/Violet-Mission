using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ItensInput
{
    public override void Collect(Player interactor)
    {
        GameObject.FindWithTag("Inventory").GetComponent<InventoryCounter>().Rock += 10;

        Destroy(gameObject);
    }
}
