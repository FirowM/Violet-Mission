using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer 
{
    bool ContainsItem(ItemAmount item);
    bool RemoveItem(ItemAmount item);
    bool AddItem(ItemAmount item);
    bool IsFull();
}
