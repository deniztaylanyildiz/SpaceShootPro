using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speedLaser = 8F;
    public float Timer =10F ;
    
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * _speedLaser * Time.deltaTime);
        LaserDestroy();
    }


    private void LaserDestroy()
    {
        
            Destroy(gameObject,Timer);
           
        
       
    }

}
