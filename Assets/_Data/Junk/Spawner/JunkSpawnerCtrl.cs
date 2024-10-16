using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : HaiMonoBehaviour
{
    [SerializeField] private JunkSpawner junkSpawner;

    public JunkSpawner JunkSpawner { get => junkSpawner;}


    [SerializeField] private SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint { get => spawnPoint; }



    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoint();

    }
    protected virtual void LoadJunkSpawner()
    {
        if (this.JunkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoint()
    {
        if (this.spawnPoint != null) return;
        //Transform.Find ( quet qua tat ca cac object trong game luon )
        this.spawnPoint = Transform.FindObjectOfType<SpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint", gameObject);
    }
    


}
