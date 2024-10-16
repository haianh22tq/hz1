using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : HaiMonoBehaviour
{
    //singleton
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }

    [SerializeField] private Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) Debug.Log("Only 1 GameManager Allow to extis");
        GameCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + ": LoadCamera", gameObject);
    }

}
