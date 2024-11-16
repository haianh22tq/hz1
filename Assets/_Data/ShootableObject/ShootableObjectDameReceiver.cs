using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDameReceiver : DameReceiver
{
    [Header("ShootableObject")]
    [SerializeField] public ShootableObjectCtrl shootableObjectCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }


    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.shootableObjectCtrl.Despawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObjectSO.droplist, dropPos, dropRot);//danh sach item can roi, vi tri roi, goc quay roi
    }
    protected virtual void OnDeadFX() //caif them hieu ung su kien die
    {
        string fxName = this.GetOnDeadFXName(); // ten hieu ung minh mong muon
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }

    public override void Reborn()
    {
        this.hpMax = this.shootableObjectCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
}
