using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstract, IObjAppearObservers
{
    [Header("Obj AppearWithoutShoot")]
    [SerializeField] protected ObjAppearing objAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ReisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }
    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": LoadObjAppearing", gameObject);
    }

    protected virtual void ReisterAppearEvent()
    {
        this.objAppearing.ObserversAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true); 
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.Spawner.Hold(transform.parent);

    }
}
