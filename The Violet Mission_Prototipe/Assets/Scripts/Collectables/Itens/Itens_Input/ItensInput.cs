using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensInput : MonoBehaviour, ICollectable
{
    #region Declarations

    //Collect Itens//

    [SerializeField] private Transform _hand;

    //Instance//

    [SerializeField] private static ItensInput _instance;

   

    public static ItensInput Instance { get => _instance; set => _instance = value; }

    #endregion

    #region Start and Update
    private void Start()
    {
        Instance = this;

        
    }

    private void Update()
    {
       
            

        
    }

    #endregion

    /// ITENS INTERACTIONS ///

    #region Itens Collector
    public virtual void Collect(Player interactor)
    {
        Debug.Log("Tentou");

        
        // Destroy(gameObject);

        gameObject.GetComponent<Rigidbody>().isKinematic = true;
       // gameObject.GetComponent<BoxCollider>().enabled = false;

        transform.position = _hand.position;
        transform.rotation = _hand.rotation;

        transform.SetParent(_hand);

    }

    #endregion

}
