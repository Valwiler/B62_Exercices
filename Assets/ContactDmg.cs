using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDmg : MonoBehaviour
{
    private BoxCollider2D OGBounds;

    private BoxCollider2D FloorZone;

    private BoxCollider2D ContactZone;
    // Start is called before the first frame update
    void Start()
    {
        OGBounds = GetComponent<BoxCollider2D>();
        FloorZone = new BoxCollider2D();
        ContactZone = new BoxCollider2D();
        
        FloorZone.size = OGBounds.size;
        FloorZone.
        ContactZone.size = OGBounds.size;
        ContactZone.isTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
