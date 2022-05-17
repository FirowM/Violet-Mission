using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Input : MonoBehaviour, IDamageable
{
    #region Declarations

    [SerializeField] private int _hp;

    #endregion


    #region Start and Update
    void Start()
    {
        _hp = 10;
    }

    void Update()
    {
        //Obstacle Hp Update//

        if(_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    /// OBSTACLE INTERACTIONS ///

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
               
        _hp-=1;

    }

    #endregion
}
