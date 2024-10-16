﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;
    //[SerializeField] protected Transform bulletPrefabs;

    void Update()
    {
        this.IsShooting();
    }
    void FixedUpdate()
    {
        this.Shooting();
    }


    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        //giai thuat thoi gian ra dan
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        //hàm instantiate để spam nếu if  true
        //Transform newBullet = Instantiate(this.bulletPrefabs, spawnPos, rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        //   ebug.Log("SHoot");

    }
    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}