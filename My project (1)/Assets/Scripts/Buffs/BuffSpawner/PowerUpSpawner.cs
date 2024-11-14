using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] powerUps;   
    [SerializeField]
    private float _spawnTimer;
    [SerializeField]
    private bool _isCanSpawn = true;
    [SerializeField]
    private float _helper = 0;
    [SerializeField]
    private GameObject _myContain;
    public  bool _iscanSpawn=false;
    


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     if (_iscanSpawn) { 
        Spawn();
       
        SpawnTimer();
        }
    }
    void SpawnTimer()
    {
        if (_isCanSpawn == false)
        {


            if (_helper <= _spawnTimer)
            {

                _helper += Time.deltaTime;

            }
            else
            {
                _helper = 0;
                _isCanSpawn = true;


            }


        }
    }
    void Spawn()
    {



        if (_isCanSpawn == true)
        {

            int randomSpawner = Random.Range(0, powerUps.Length);
            float c = UnityEngine.Random.Range(4, -4);
            Vector3 alpha = transform.position + new Vector3(0, c, 0);
          
            GameObject newBuff = Instantiate(powerUps[randomSpawner], alpha, Quaternion.identity);
            newBuff.transform.parent = _myContain.transform;
            _isCanSpawn = false;




        }


    }
    public void NowCanSpawn()
    {

        _isCanSpawn = true;

    }
}

