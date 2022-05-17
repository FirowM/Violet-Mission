using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour, IDenemies
{
    #region Declarations

    //Physics//

    private Rigidbody _rb;

    //Movement//

    private int _speed;
    private int _normalSpeed;
    private int _runSpeed;
    private int _slowSpeed;


    private bool _canRun;
    private bool _isRunning;

    

    //Status//

    [SerializeField] private Slider _hp, _stamina, _food;

    //Interactions//

    [SerializeField] private LayerMask _whatIsColectable;

    //Instance//

    [SerializeField] private static Player _playerInstance;



    public Slider Hp { get => _hp; set => _hp = value; }
    public Slider Stamina { get => _stamina; set => _stamina = value; }
    public Slider Food { get => _food; set => _food = value; }
    public static Player PlayerInstance { get => _playerInstance; set => _playerInstance = value; }


    #endregion

    #region Start and Update
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();

        _normalSpeed = 20;
        _runSpeed = 50;
        _slowSpeed = 10;
        _speed = _normalSpeed;

        PlayerInstance = this;

        _isRunning = false;
        _canRun = true;

        Hp.value = 100f;
        Stamina.value = 100f;
        Food.value = 100f;
    }

    private void Update()
    {
        //Interactor//

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryToCollect();
        }
    }
    private void FixedUpdate()
    {
        //Movement Update//

        MovementInput();


        //Stamina Update//

        if (Input.GetAxis("Horizontal") != 0 && Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            Stamina.value -= Time.deltaTime * 5;
        }
        else
        {
            Stamina.value += Time.deltaTime;
        }

        if(Stamina.value < 0.1f)
        {
            StartCoroutine(SlowSpeed());
            
        }
        if(Stamina.value > 10f)
        {
            _canRun = true;            
        }

        //Food Update//

        Hungry();

        

    }

    #endregion

    /// PLAYER INPUT ///
    
    #region Movement
    public void MovementInput()
    {

        MoveInDirection(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        if (_canRun)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = _runSpeed;
                _isRunning = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _speed = _normalSpeed;
                _isRunning = false;
            }
        }
    }
    private void MoveInDirection(Vector2 direction)
    {
        Vector3 finalVelocity = (direction.x * transform.right + direction.y * transform.forward).normalized * _speed;
        finalVelocity.y = _rb.velocity.y;
        _rb.velocity = finalVelocity;
    }

    IEnumerator SlowSpeed()
    {
        _canRun = false;
        _speed = _slowSpeed;
        yield return new WaitForSeconds(10f);
        _speed = _normalSpeed;
        
    }

    #endregion

    #region Status
    private void Hungry()
    {
        if (_isRunning == true)
        {
            Food.value -= Time.deltaTime / 5;
        }
        else
        {
            Food.value -= Time.deltaTime / 10;
        }

        if(Food.value == 0)
        {
            Hp.value -= Time.deltaTime;
        }

        
        
    }

    #endregion

    /// PLAYER INTERACTIONS ///

    #region Collect
    private void TryToCollect()
    {

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100, _whatIsColectable))
        {

            ICollectable collectable = hit.transform.GetComponent<ICollectable>();

            if( collectable == null)
            {

            }

            else
            {
                collectable.Collect(this);
            }

            
             Debug.Log("Hit");
            

               
                        
        }
    }

    #endregion

    #region Receive Damage

    public void EnemyAttack(EnemiesInput interactor)
    {
        Debug.Log("EnemyTentou");


        Hp.value -= 20;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Enemy"))
        {
           // Hp.value -= 1;
        }
    }

    #endregion





}
