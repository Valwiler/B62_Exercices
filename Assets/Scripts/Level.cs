using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Niveau
//    • Votre niveau doit ajouter un nouveau vaisseau à une position aléatoire à l’intérieur du niveau :
//        ◦ Monstre vert au 3 secondes
//        ◦ Baril au 10 secondes
//        ◦ Spawner au 20 secondes
//        ◦ Trousseau de vie ou de bombes au hasard (un des 2) au 10 secondes
//


[System.Serializable]
public class LevelSpawnObject
{
    public GameObject GameObject;
    public float SpawnTime = 3;
}
public class Level : MonoBehaviour
{
    public BoxCollider2D LevelCollider;
    public List<LevelSpawnObject> LevelSpawnObjects;
    
    public GameObject MonsterGameObjet;
    public float MonsterTimer = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var levelSpawnObject in LevelSpawnObjects)
        {
            
        }
        MonsterTimer -= Time.deltaTime;
        if (MonsterTimer <= 0)
        {
            var x = Random.Range(LevelCollider.bounds.min.x, LevelCollider.bounds.max.x);
            var y = Random.Range(LevelCollider.bounds.min.y, LevelCollider.bounds.max.y);

            Instantiate(MonsterGameObjet, new Vector3(x,y, 0), Quaternion.identity);
            MonsterTimer = 3;
        }
    }
}
