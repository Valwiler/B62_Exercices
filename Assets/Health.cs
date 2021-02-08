using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Hp ;

    public Health(int Vie)
    {
        this.Hp = Vie;
    }

    public void substractHealth()
    {
        this.Hp -= 1;
        if (this.Hp <= 0)
        {   
            
            Destroy(gameObject);
        }
    }
}
