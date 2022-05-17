using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodInput : MonoBehaviour, ICollectable
{
    
      
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            
        }
    }

    //Collect, Get from inventory...//


    public virtual void Collect(Player interactor)
    {
                   
      
    }
}
