using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjects : MonoBehaviour, IDamageable
{
    #region Declarations

    [SerializeField] private int _hp;

   

    [SerializeField] private GameObject _iten;
    

    [SerializeField] private Transform _objectGenerator;

    [SerializeField] private ObjectsGenerator _regenerate;

  

    #endregion


    #region Start and Update
    void Start()
    {
        _hp = 10;
    }

    void Update()
    {
        // World Objects Hp Update //

        if (_hp <= 0)
        {
            

            // Drop Iten When Destroyed //

            GameObject newIten = Instantiate(_iten, _objectGenerator);
            newIten.GetComponent<Rigidbody>().AddForce(_objectGenerator.up * 10);

            

            // Object Regenerator //

            _regenerate.Regenerate();

            // Time To Destroy New Iten //

            Destroy(newIten, 10);

            // Destroy Object //

            Destroy(gameObject);


        }
    }

    #endregion

    /// WORLD OBJECTS INTERACTIONS ///

    #region Receive Damage
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {

        }

    }

    public void PlayerAttack(RightArm interactor)
    {
        Debug.Log("Tentou");

               
        _hp -= 1;

    }

    // Tentar mudar de cor ao ser atingido 
    IEnumerator ChangeColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Renderer>().material.color = Color.clear;
    }

        

    #endregion
}
