using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotatespeed;
    [SerializeField]
    private GameObject _boomBoom;
    private EnemySpawner _enemySpawner;
    private PowerUpSpawner _powerUpSpawner;

    private void Awake()
    {
        _enemySpawner=GameObject.Find("Enemyspawner").GetComponent<EnemySpawner>();
        _powerUpSpawner=GameObject.Find("BuffSpawner").GetComponent<PowerUpSpawner>();
    }
    private void Update()
    {
        transform.Rotate(0.0f, 0.0f, 1.0f * _rotatespeed, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag=="Player" || collision.tag=="Laser")
        {
            if(collision.tag == "Player")
            {
                Player.Instance.TakeDamage(3);
            }
            
            GameObject bom= Instantiate(_boomBoom,transform.position,Quaternion.identity);
            Destroy(collision.gameObject);            
            gameObject.SetActive(false);
            _enemySpawner.startSpawning();
            _powerUpSpawner._iscanSpawn=true;
            Destroy(this.gameObject,1.1F);


        }

    }


}
