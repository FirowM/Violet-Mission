using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct ItemAmount
{
    [SerializeField] private  GameObject _item;
    [Range(1f, 999f)]
    [SerializeField] private int _amount;
}

[CreateAssetMenu]
public class CraftingRecipes: ScriptableObject
{
    [SerializeField] private List<ItemAmount> _materials;
    [SerializeField] private List<ItemAmount> _restuls;

    private bool _canCraft(ItenCreator inventory)
    {
        return false;
    }

    public void _craft(ItenCreator inventory)
    {

    }
}
