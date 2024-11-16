using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : HaiMonoBehaviour
{
    [SerializeField] private JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn;}

    [SerializeField] private Transform model;
    public Transform Model { get => model; }
    [SerializeField] private ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO { get => shootableObjectSO;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        // this.LoadJunkSO();
        this.LoadShootableObjectSO();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadJunkDespawn()
    {
        if (this.junkDespawn != null) return;
        this.junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn", gameObject);
    }
    /* protected virtual void LoadJunkSO()
     {
         if (this.shootableObjectSO != null) return;
         //tạo đường dẫn tới JunkSO
         string resPath = "Junk/" + transform.name;
         // Récoures>load dùng để tạo liên kết
         this.shootableObjectSO = Resources.Load<JunkSO>(resPath);
         Debug.LogWarning(transform.name + ": LoadJunkSO" + resPath, gameObject);
     }*/
    protected virtual void LoadShootableObjectSO()
    {
        if (this.shootableObjectSO != null) return;
        //tạo đường dẫn tới JunkSO
        string resPath = "ShootableObject/Junk/" + transform.name;
        // Récoures>load dùng để tạo liên kết
        this.shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadShootableObjectSO" + resPath, gameObject);
    }
}
