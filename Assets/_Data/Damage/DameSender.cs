using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DameSender : HaiMonoBehaviour
{
    [SerializeField] public int damage = 1;

    //ham gui dame cho 1 obj nao do
    public virtual void Send(Transform obj)
    {
        DameReceiver dameReceiver = obj.GetComponentInChildren<DameReceiver>();
        if (dameReceiver == null) return;
        this.Send(dameReceiver);
        this.CreateImpactFX();

    }

    //gui dame sang ham nay
    public virtual void Send(DameReceiver dameReceiver)
    {
        dameReceiver.Deduct(this.damage);
        //this.DestroyObject();
    }

    /*protected virtual void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }*/

    protected virtual void CreateImpactFX() //caif them hieu ung su kien die
    {
        string fxName = this.GetImpactFXName(); // ten hieu ung minh mong muon

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFXName()
    {
        return FXSpawner.impact1;
    }
}
