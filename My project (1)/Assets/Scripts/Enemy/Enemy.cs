using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _enemyLiveTime;
    [SerializeField]
    private float _enemySpeed;
    [SerializeField]
    private Vector3 _enemyMoveVector;
    [SerializeField]
    private int _enemyDamage = 1;
    private Player _player;
    private void Awake()
    {
        transform.Rotate(new Vector3(0, 0, 270), Space.World);
        _player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {

        Moving();
        Die();



    }
    void Moving()
    {
        transform.Translate(_enemyMoveVector * _enemySpeed * Time.deltaTime);


    }

    private void Die()
    {
        Destroy(gameObject, _enemyLiveTime);


    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player=other.GetComponent<Player>();
            Destroy(gameObject);
            if (player != null)
                player.TakeDamage(_enemyDamage);
           




        }
        if (other.tag == "Laser")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            _player.AddScore(10);

            
        }
    }

}
