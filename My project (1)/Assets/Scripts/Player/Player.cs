using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    private bool _isITHot = false;
    [SerializeField]
    private float _coolDownTimer;
    [SerializeField]
    private float _timerHelper = 0;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private GameObject _myContain;
    [SerializeField]
    private float _tripleBufftimer = 5;
    [SerializeField]
    private float _speedBuffTimer = 3;
    [SerializeField]
    private float _shieldBuffTimer = 200;
    [SerializeField]
    private GameObject _shield;
    [SerializeField]
    private int _score = 0;

    public bool _isShieldActive = false;
    public bool _isSpeedBoostActive = false;
    public bool _isTripleShootActive = false;
    [SerializeField]
    private GameObject _tripleShoot;
    [SerializeField]
    private GameObject _hp2;
    [SerializeField]
    private GameObject _hp1;

    [SerializeField] private AudioSource _laserSound;
    

    public static Player Instance { get; private set; }

    private void Awake()
    {
        _laserSound= GetComponent<AudioSource>();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }
    private void Start()
    {


    }
    void Update()
    {





        CalculateMovement();
        BounchVers1();
        LaserShoot();
        HpCheck();

    }


    void CalculateMovement()
    {

        _verticallInput = Input.GetAxis("Vertical");
        _horizontallInput = Input.GetAxis("Horizontal");
        _direction = new Vector3(-_verticallInput, _horizontallInput, 0);
        if (_isSpeedBoostActive == true)
            transform.Translate(_direction * (_speed * 2) * Time.deltaTime);
        else if (_isSpeedBoostActive == false)
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
    void BounchVers2()
    {//sýkýþtýrmak için//
        if (transform.position.y >= _maxDistanceY)

            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -_maxDistanceY, _maxDistanceY), transform.position.z);

    }

    void LaserShoot()
    {



        if (Input.GetKeyDown(KeyCode.Space) && _isITHot == false)
        {
            _isITHot = true;
            if (_isTripleShootActive == false)
            {
                GameObject newLaser = Instantiate(_laser, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                newLaser.transform.parent = _myContain.transform;
                _laserSound.Play();
            }
            else
            {
                GameObject newLaser = Instantiate(_tripleShoot, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
                newLaser.transform.parent = _myContain.transform;
                _laserSound.Play();

            }


        }

        else if (_isITHot == true)
        {
            if (_coolDownTimer >= _timerHelper)
            {

                _timerHelper += Time.deltaTime;
            }
            else
            {
                _isITHot = false;
                _timerHelper = 0;
            }
        }

    }

    public void HpCheck()
    {

        if(_lives<=2)
            _hp2.SetActive(true);
        else
            _hp2.SetActive(false);
        if(_lives<=1)
            _hp1.SetActive(true);
        else
            _hp1.SetActive(false);


    }

    public void TakeDamage(int damage)
    {
        if (_isShieldActive == false)
        {
            _lives -= damage;
            UIManager.Instance.UpdateHP(_lives);
        }
        else
        {
            _isShieldActive = false;
            _shield.SetActive(false);
        }
        if (_lives <= 0)
        {
            GameManager.Instance.GameOver();
            EnemySpawner.Instance.OnplayerDead();
            Destroy(gameObject, 0.2F);


        }

    }


    public void ThripleShootBuff()
    {

       
        if (_isTripleShootActive == true)
            StartCoroutine(TripleShootBufferDownRoutine());




    }
    public void SpeedBuff()
    {

        StartCoroutine(SpeedBufferDownRoutine());
       
    }

    public void ShieldBuff()
    {
       
        StartCoroutine(ShieldBufferRoutine());
    }
    IEnumerator TripleShootBufferDownRoutine()
    {


        yield return new WaitForSeconds(_tripleBufftimer);
        _isTripleShootActive = false;


    }
    IEnumerator SpeedBufferDownRoutine()
    {


        yield return new WaitForSeconds(_speedBuffTimer);
        _isSpeedBoostActive = false;


    }

    IEnumerator ShieldBufferRoutine()
    {
        _shield.SetActive(true);
        yield return new WaitForSeconds(_shieldBuffTimer);
        _isShieldActive = false;
        _shield.SetActive(false);


    }
    public void AddScore(int a)
    {

        _score = a + _score;
        UIManager.Instance.UpDateScoreText(_score);


    }
}


