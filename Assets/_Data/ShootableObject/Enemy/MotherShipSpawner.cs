using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance { get => instance; }
    //public static string mateoriteOne = "Mateorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null) Debug.Log("Eror Only 1 MotherShipSpawner allow to exits");
        MotherShipSpawner.instance = this;
    }
}
