using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    #region Declarations



    // Inventory //

    [SerializeField] private GameObject _inventory;

    [SerializeField] private bool _inventoryIsOpen;

    [SerializeField] private InventoryCounter _inventoryCounter;

    // Inventory Icons //

    [SerializeField] private GameObject _fruitIcon, _woodIcon, _rockIcon, _giantEggIcon;

    // Iten To Be Holded //

    [SerializeField] private GameObject _iten; // passar para outro script(ItensInput)?
    private bool _holdingIten;


    // Iten Position //

    [SerializeField] private Transform _hand;

    #endregion


    #region Start and Update

    void Start()
    {
        _inventory.SetActive(false);
        _inventoryIsOpen = false;
        
        _holdingIten = false;  
        


    }
             
    private void Update()
    {
        // Inventory Update //

        OpenInventory();
        

       if(_inventoryIsOpen == true)
       {
            Cursor.lockState = CursorLockMode.None; //*Incrementar cursorlockmode na pausa*//

            CheckItens();
       }
       else
       {
            Cursor.lockState = CursorLockMode.Locked;
       }

       _inventory.SetActive(_inventoryIsOpen);

       Cursor.visible = _inventoryIsOpen;




        if (Input.GetKeyDown(KeyCode.Alpha1)) // passar para outro script(ItensInput)? e mudar lógica para ativação por Iten Slot //
        {
           
            PickUpItens();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            UseItens();
        }


    }


    #endregion


    #region Open and Close Inventory
    public void OpenInventory()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {

            _inventoryIsOpen = !_inventoryIsOpen;

        }
            
    }

    #endregion

    #region Activate Itens When Collected

    void CheckItens()
    {

        // Fruit //

        if(_inventoryCounter.Fruit>0)
        {
            _fruitIcon.SetActive(true);
        }
        else
        {
            _fruitIcon.SetActive(false);
        } 

        // Wood //
        
        if(_inventoryCounter.Wood>0)
        {
            _woodIcon.SetActive(true);
        }
        else
        {
            _woodIcon.SetActive(false);
        }

        // Rock //


        if (_inventoryCounter.Rock > 0)
        {
            _rockIcon.SetActive(true);
        }
        else
        {
            _rockIcon.SetActive(false);
        }

        // Giant Egg //

        if (_inventoryCounter.GiantEgg > 0)
        {
            _giantEggIcon.SetActive(true);
        }
        else
        {
            _giantEggIcon.SetActive(false);
        }

    }

    void PickUpItens() // Passar pra outro script (ItensInput, ItensManager)? // Ajeitar A Faca //
    {
        
        if (_inventoryCounter.Fruit > 0 && _holdingIten == false)
        {
            
            GameObject newIten = Instantiate(_iten, _hand);
            newIten.GetComponent<Rigidbody>().isKinematic = true;

            _holdingIten = true;

            if(Input.GetKeyDown(KeyCode.Mouse1)) // Arranjar um jeito de destruir o iten quando consumido // como será quando iten for arrastado pros slots 1,2,3,4
            {
                Destroy(newIten);

                Debug.Log("destruido");
            }

            
        }
       
        

    }

    void UseItens()
    {

        if(_holdingIten == true)
        {
            _inventoryCounter.Fruit--;
            GameObject.FindWithTag("Player").GetComponent<Player>().Food.value += 10f;

            
        }
        
    }


    #endregion

}
