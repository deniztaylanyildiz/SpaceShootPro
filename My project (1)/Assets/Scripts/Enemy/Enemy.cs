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
        DieInTime();



    }
    void Moving()
    {
        transform.Translate(_enemyMoveVector * _enemySpeed * Time.deltaTime);


    }

    private void DieInTime()
    {
        Destroy(gameObject, _enemyLiveTime);
     

    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetValuesOnHit();


            Player player =other.GetComponent<Player>();
            Destroy(gameObject,1F);
            if (player != null)
                player.TakeDamage(_enemyDamage);

          


        }
        if (other.tag == "Laser")
        {
            GetValuesOnHit();

            Destroy(gameObject,1.1F);
            Destroy(other.gameObject);
            _player.AddScore(10);

           
        }
       
    }


    private void GetValuesOnHit()
    {

        _enemySpeed *= 0.6F;
        Animator enemyAnim = gameObject.GetComponent<Animator>();
        Collider2D enemycollider = gameObject.GetComponent<Collider2D>();
        if (enemycollider != null || enemyAnim != null)
        {
            enemycollider.enabled = false;
            enemyAnim.SetTrigger("Isdead");
        }
        else
            Debug.Log("Some Prolems");
    }


}
