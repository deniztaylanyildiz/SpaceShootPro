using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Vector2 _moveDir;
    private Player _player;

    [SerializeField]
    private int _buffID;

    private void Awake()
    {

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_moveDir * _speed * Time.deltaTime);
        if (transform.position.x < -12)
            Dead();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == ("Player"))
        {
            if (_player != null) { 
            switch (_buffID)
            {
                case 0:
                    _player._isTripleShootActive = true;
                    _player.ThripleShootBuff();
                    break;
                case 1:
                    _player._isSpeedBoostActive = true;
                    _player.SpeedBuff();
                    break;
                case 2:
                        _player._isShieldActive = true;
                        _player.ShieldBuff();
                    break;
                default:
                    Debug.Log("def");
                    break;

            }
            }
            Dead();
        }
    }
    void Dead()
    {

        Destroy(gameObject);



    }
}
