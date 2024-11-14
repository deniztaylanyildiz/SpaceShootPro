using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Vector2 _moveDir;
   

    [SerializeField]
    private int _buffID;

  

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
            if (Player.Instance != null) { 
            switch (_buffID)
            {
                case 0:
                    Player.Instance._isTripleShootActive = true;
                    Player.Instance.ThripleShootBuff();
                      
                    break;
                case 1:
                    Player.Instance._isSpeedBoostActive = true;
                    Player.Instance.SpeedBuff();
                     
                        break;
                case 2:
                        Player.Instance._isShieldActive = true;
                        Player.Instance.ShieldBuff();
                     
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
