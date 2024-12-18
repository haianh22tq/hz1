using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // 1 trong những design partten(singleton)
    private static InputManager instance;
    public static InputManager Instance { get => instance; }

    //vitri toa do con tro chuot
    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }
    ///
    [SerializeField] private float onFiring = 0;
    public float OnFiring { get => onFiring;}

    public virtual void Awake()
    {
        if (InputManager.instance != null) Debug.Log("Eror Only 1 Inputmanager  allow to exits");
        InputManager.instance = this;
    }
    private void Update()
    {
        this.GetMouseDown();
    }
    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
