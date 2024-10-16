using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
   // [SerializeField] protected Despawn despawn;
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
