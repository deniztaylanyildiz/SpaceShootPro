using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 _enemySpawnPoint;
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private float _enemySpawnTimer=1.1F;
    [SerializeField]
    private GameObject _myContain;
    public bool _stopSpawning;
    public static EnemySpawner Instance;

    private void Awake()
    {
        Instance = this;
        _enemySpawnPoint= new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    // Update is called once per frame
    void Update()
    {
        
            

    }
    void Spawn()
    {
       

       GameObject newEnemy= Instantiate(_enemy, new Vector3(_enemySpawnPoint.x+5F, Random.Range(-5f, 5f), _enemySpawnPoint.z), Quaternion.identity);
        newEnemy.transform.parent = _myContain.transform;

        
    }
    IEnumerator SpawnRoutine()
    {
       
        while (_stopSpawning==false ){
            Spawn();
            yield return new WaitForSeconds(_enemySpawnTimer);
        }
        
    }

    public void OnplayerDead()
    {

        _stopSpawning=true;


    }
}
