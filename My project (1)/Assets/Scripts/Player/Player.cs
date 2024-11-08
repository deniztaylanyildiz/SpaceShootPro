using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _verticallInput;
    [SerializeField]
    private float _horizontallInput;
    [SerializeField]
    private Vector3 _direction;
    public float _maxDistanceY = 5F;
    [SerializeField]
    public float _maxDistanceX = 9F;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private bool _isITHot=false;
    [SerializeField]
    private float _coolDownTimer;
    [SerializeField]
    private float _timerHelper = 0;
    [SerializeField]
    private int _lives=3;
    [SerializeField]
    private GameObject _myContain;


    

    void Update()
    {
        
        CalculateMovement();

        BounchVers1();
        LaserShoot();
    }
   
    
    void CalculateMovement()
    {

        _verticallInput = Input.GetAxis("Vertical");
        _horizontallInput = Input.GetAxis("Horizontal");
        _direction = new Vector3(_horizontallInput, _verticallInput, 0);
        transform.Translate(_direction * _speed * Time.deltaTime);


    }
    void BounchVers1()
    {
        if (transform.position.y >= _maxDistanceY)

            transform.position = new Vector3(transform.position.x, -_maxDistanceY, transform.position.z);



        else if (transform.position.y <= -_maxDistanceY)
            transform.position = new Vector3(transform.position.x, _maxDistanceY, transform.position.z);



        if (transform.position.x >= _maxDistanceX)
        {
            transform.position = new Vector3(-_maxDistanceX, transform.position.y, transform.position.z);

        }
        else if (transform.position.x <= -_maxDistanceX)
            transform.position = new Vector3(_maxDistanceX, transform.position.y, transform.position.z);
    }
    void BounchVers2() {//s�k��t�rmak i�in//
        if (transform.position.y >= _maxDistanceY)

            transform.position=new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-_maxDistanceY,_maxDistanceY),transform.position.z);
    
    }

    void LaserShoot()
    {
        


            if (Input.GetKeyDown(KeyCode.Space)&&_isITHot==false) {
                _isITHot = true;
             GameObject newLaser= Instantiate(_laser, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            newLaser.transform.parent = _myContain.transform;
            }
        
        else if(_isITHot==true) {
            if (_coolDownTimer >= _timerHelper)
            {

              _timerHelper += Time.deltaTime;
            }
            else { 
            _isITHot= false;
                _timerHelper= 0;
            }
        }
    }
    


    public void TakeDamage(int damage)
    {
        _lives-=damage;
        Debug.Log(_lives);
        if (_lives <= 0)
        {
            Debug.Log("Die");

        }
    }

    }
