using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : ItensInput
{
      
    public override void Collect(Player interactor)
    {
        GameObject.FindWithTag("Inventory").GetComponent<InventoryCounter>().Wood += 10;

        Destroy(gameObject);
    }
}
