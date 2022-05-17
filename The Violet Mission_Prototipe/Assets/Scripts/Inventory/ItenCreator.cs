using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Iten", menuName = "Inventory/CreateIten", order = 1)]
public class ItenCreator : ScriptableObject
{
    #region Declarations

    //Itens Properties//

    [SerializeField] private string _itenName;
    [SerializeField] private Texture2D _icon;
    [SerializeField] private int _quantity;

   

    public int Quantity { get => _quantity; set => _quantity = value; }
    public Texture2D Icon { get => _icon; set => _icon = value; }
    public string ItenName { get => _itenName; set => _itenName = value; }

    #endregion

    #region Start and Update


    void Start()
    {
       


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
    }

    #endregion
   
}
