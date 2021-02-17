using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptypickUp : MonoBehaviour
{
    private const int respawnRate = 3;
    private float respawnTimer = respawnRate;
    public GameObject consummable;
    private GameObject temp;
    public bool isActivated = true;
    private Quaternion noRotation;

    
    void Start()
    {
        temp = consummable;
        noRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(temp, transform.position, noRotation);
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //  //Debug.Log(temp.gameObject is null);
    //    if (temp.onDestroy )
    //    {
    //        if (respawnTimer <= 0)
    //        {
    //            Debug.Log("Respawn Timer : " + respawnTimer);
    //            temp = consummable;
    //            Instantiate(temp, transform.position,noRotation);
    //            respawnTimer = respawnRate;
    //
    //        }
    //        else
    //            respawnTimer -= Time.deltaTime;
    //    }
    //
    //
    //
    //
    //}
}
