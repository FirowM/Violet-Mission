using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RightArm : MonoBehaviour
{

    #region Declarations

    private Animator _anim;

    [SerializeField] private static RightArm _instance;

    [SerializeField] private LayerMask _whatIsDamageable;

    //Actions//

   // private bool _isAttacking;

    public static RightArm Instance { get => _instance; set => _instance = value; }

    #endregion

    #region Start and Update

    private void Start()
    {
        Instance = this;

        _anim = GetComponent<Animator>();

        

    }

    private void Update()
    {

      
        //Player Attack Update//
      

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                       

            _anim.SetInteger("Transition", 1);
                        

          
            DetectAttack();

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {

            

            _anim.SetInteger("Transition", 0);

            
        }


        
    }

    #endregion

    /// RIGHT ARM INTERACTIONS ///

    #region Player Attack
    private void DetectAttack()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 4, _whatIsDamageable))
        {

            IDamageable damageable = hit.transform.GetComponent<IDamageable>();

            if (damageable == null)
            {

            }
            else
            {
                damageable.PlayerAttack(this);
            }


            Debug.Log("Hit");


        }
    }

    #endregion


}
