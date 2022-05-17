using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesInput : MonoBehaviour, IDamageable
{

    [SerializeField] private Transform _playerPosition;

    [SerializeField] private LayerMask _playerLayer;

    private NavMeshAgent _navMesh;

    private float _playerDistance;

    [SerializeField] private float _followDistance, _attackDistance;

    [SerializeField] private float _runningSpeed;

   // [SerializeField] private float _damage;

    [SerializeField] private int _maxLife;

    [SerializeField] private int _currentLife;

    [SerializeField] private bool _canAttack = false;
       
    [SerializeField] private GameObject _impact;

    private bool _isBeenAttacked;

    private Rigidbody _rb;

    public bool CanAttack { get => _canAttack; set => _canAttack = value; }

    // Start is called before the first frame update
    void Start()
    {
        _navMesh = transform.GetComponent<NavMeshAgent>();

        _currentLife = _maxLife;

        _rb = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        _playerDistance = Vector3.Distance(_playerPosition.transform.position, transform.position);

        Vector3 iniPlace = transform.position;
        Vector3 finPlace = _playerPosition.transform.position;
        Vector3 direction = finPlace - iniPlace;

        

        if (_playerDistance < _followDistance && _playerDistance > _attackDistance)
        {
            Follow();
        }
        
        if(_playerDistance < _attackDistance)
        {
            EnemyDamageAttack();


        }
        if (_currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void EnemyDamageAttack()
    {
        if(CanAttack == false)
        {
            StartCoroutine(TryToAttack());

        }
    }
    public IEnumerator TryToAttack()
    {
        
        

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50, _playerLayer))
        {
            CanAttack = true;

            IDenemies enemyAttack = hit.transform.GetComponent<IDenemies>();

            _navMesh.speed = 0;
            _navMesh.acceleration = 0;

            yield return new WaitForSecondsRealtime(1);

            if (enemyAttack == null)
            {

            }

            else
            {
                if(_playerDistance < _attackDistance)
                {
                    

                    for (int i = 0; i < 1; i++)
                    {
                        // enemyAttack.EnemyAttack(_damage);
                        if(_isBeenAttacked == false)
                        {
                            

                            enemyAttack.EnemyAttack(this);

                            yield return new WaitForSecondsRealtime(1);

                            
                        }
                        

                        
                    }
                }
                
                
            }

            

            Debug.Log("Hit");

        }

        CanAttack = false;
    }

    public void PlayerAttack(RightArm interactor)
    {
        Debug.Log("Tentou");

        _isBeenAttacked = true;

        _navMesh.acceleration = 100;
        _navMesh.speed = _runningSpeed;
        _navMesh.destination = _impact.transform.position;

        //_rb.AddForce(Vector3.forward * _playerHitImpact);

        _currentLife -= 1;

    }

    void Follow()
    {
        _navMesh.acceleration = 5;
        _navMesh.speed = _runningSpeed;
        _navMesh.destination = _playerPosition.position;

        _isBeenAttacked = false;


    }

    

}
