using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : HaiMonoBehaviour
{
    [SerializeField] public DameSender dameSender;
    public DameSender DameSender { get => dameSender; }

    [SerializeField] private BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    [SerializeField] private Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDameSender()
    {
        if (this.dameSender != null) return;
        this.dameSender = GetComponentInChildren<DameSender>();
        Debug.Log(transform.name + ": LoadDameSender", gameObject);

    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);

    }

    public virtual void SetShooter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
