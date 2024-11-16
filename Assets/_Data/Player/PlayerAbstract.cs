using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : HaiMonoBehaviour
{
    [Header("Player Abstract")]
    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl { get => playerCtrl;}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);

    }
}
