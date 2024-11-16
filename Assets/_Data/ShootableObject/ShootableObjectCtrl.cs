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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadShootableObjectSO();
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

    protected abstract string GetObjectTypeString();
}
