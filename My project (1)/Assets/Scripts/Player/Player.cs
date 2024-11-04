using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] 
    private float _speed;
    void Start()
    {
        
       // transform.position = new Vector3(1, 2, 3);//basic transform
    }

    void Update()
    {


        transform.Translate(Vector3.right* _speed*Time.deltaTime);

    }
}
