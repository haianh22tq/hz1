using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : HaiMonoBehaviour
{
    [SerializeField] private Transform model;
    public Transform Model => model;

    [SerializeField] private Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] private ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO => shootableObjectSO;


    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadShootableObjectSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    protected virtual void LoadShootableObjectSO()
    {
        if (this.shootableObjectSO != null) return;
        //tạo đường dẫn tới JunkSO
        string resPath = "ShootableObject/" + this.GetObjectTypeString() + "/" + transform.name;
        // Récoures>load dùng để tạo liên kết
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadShootableObjectSO" + resPath, gameObject);
    }

    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadObjAppearWithoutShoot", gameObject);
    }
    protected virtual void LoadObjMovement()
    {
        if (this.objMovement != null) return;
        this.objMovement = GetComponentInChildren<ObjMovement>();
        Debug.Log(transform.name + ": LoadObjMovement", gameObject);
    }
    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.Log(transform.name + ": LoadObjLookAtTarget", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
