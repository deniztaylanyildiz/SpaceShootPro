using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShootLaser : MonoBehaviour
{
    [SerializeField]
    private float _speedLaser = 8F;
    public float Timer = 10F;




    void Update()
    {
        transform.Translate(new Vector3(1, 0, 0) * _speedLaser * Time.deltaTime);
        TripleShootDied();
    }


    private void TripleShootDied()
    {

        Destroy(gameObject, Timer);



    }

}