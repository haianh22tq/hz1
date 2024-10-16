using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbtract : HaiMonoBehaviour
{
    [Header("Bullet Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDameReceiver();
    }
    protected virtual void LoadDameReceiver()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadDameReceiver", gameObject);
    }
}
