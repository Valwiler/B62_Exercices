using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptypickUp : MonoBehaviour
{
    private const int respawnRate = 20;
    private float respawnTimer = respawnRate;
    public GameObject consummable;
    

    
    void Start()
    {
        gameObject.SetActive(true);
        var noRotation = Quaternion.Euler(0, 0, 0);
        Instantiate(consummable, transform.position, noRotation);
        respawnTimer = respawnRate;
    }

    // Update is called once per frame
    void Update()
    {
                   
            
         if (consummable.activeSelf == false)
        {
            if (respawnTimer <= 0)
            {
                consummable.SetActive(true);
                respawnTimer = respawnRate;
            }
            else
                respawnTimer -= Time.deltaTime;    
        }

        

        
    }
}
