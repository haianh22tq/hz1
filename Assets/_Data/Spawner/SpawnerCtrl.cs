using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : HaiMonoBehaviour
{
    [SerializeField] private Spawner spawner;

    public Spawner Spawner { get => spawner; }


    [SerializeField] private SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => spawnPoint;



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoint();

    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        //Transform.Find ( quet qua tat ca cac object trong game luon )
        this.spawnPoint = Transform.FindObjectOfType<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
    


}
