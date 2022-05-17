using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCounter : MonoBehaviour
{
    #region Declarations

    //Test//
    [SerializeField] private int _fruit;
    [SerializeField] private Text _fruitQuantity;

    [SerializeField] private int _giantEgg;
    [SerializeField] private Text _giantEggQuantity;

    [SerializeField] private int _wood;
    [SerializeField] private Text _woodQuantity;

    [SerializeField] private int _rock;
    [SerializeField] private Text _rockQuantity;



    //[SerializeField] private GameObject _iconFruit;

    public int Fruit { get => _fruit; set => _fruit = value; }
    public int GiantEgg { get => _giantEgg; set => _giantEgg = value; }
    public int Wood { get => _wood; set => _wood = value; }
    public int Rock { get => _rock; set => _rock = value; }



    #endregion

    #region Start and Update
    void Start()
    {
        Fruit = 0;
      //  _iconFruit.SetActive(false);


    }

    
    void FixedUpdate()
    {

        FruitInput();
        WoodInput();
        RockInput();
        GiantEggInput();


    }

    #endregion


    public void FruitInput()
    {
        if (Fruit >= 1 && (Input.GetKey(KeyCode.P)))
        {
            Fruit--;
            GameObject.FindWithTag("Player").GetComponent<Player>().Food.value += 10f;
        }

        if (Fruit == 0)
        {
            //_iconFruit.SetActive(false);
        }
        else
        {
           // _iconFruit.SetActive(true);
        }

        _fruitQuantity.text = "" + _fruit; 
    }

    public void WoodInput()
    {
        _woodQuantity.text = "" + _wood;
    }

    public void RockInput()
    {
        _rockQuantity.text = "" + _rock;
    }
    public void GiantEggInput()
    {
        _giantEggQuantity.text = "" + _giantEgg;

    }
}
