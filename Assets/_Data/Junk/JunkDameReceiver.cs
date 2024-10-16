using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDameReceiver : DameReceiver
{
    [SerializeField] public JunkCtrl junkCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }


    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.junkCtrl.JunkDespawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.JunkSO.droplist, dropPos, dropRot);//danh sach item can roi, vi tri roi, goc quay roi
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
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
}
