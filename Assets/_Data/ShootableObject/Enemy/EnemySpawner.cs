using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }
    //public static string mateoriteOne = "Mateorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.Log("Eror Only 1 EnemySpawner  allow to exits");
        EnemySpawner.instance = this;
    }
}
