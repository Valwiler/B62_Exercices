using UnityEngine;

public class Health_tym : MonoBehaviour
{
    public int Hp;

    //public Health(int Vie)
    //{
    //    this.Hp = Vie;
    //}

    public void substractHealth()
    {
        Hp -= 1;
    }

    public void addHealth()
    {
        Hp += 1;
    }
}