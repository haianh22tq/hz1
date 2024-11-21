using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : HaiMonoBehaviour
{
    //vitri toa do con tro chuot
    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;
    protected virtual void FixedUpdate()
    {
        //this.GetTargetPosition();
        this.Moving();
    }
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    //nhin theo con tro chuot
    

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;
        //lerp la tinh trung diem lam cho chuyen dong muot ma hon
        //vi tri hien tai, vi tri con tau di chuyen den, toc do
        Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
