using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    [SerializeField] protected Despawn despawn;
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
