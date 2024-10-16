using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    //vitri toa do con tro chuot
    [SerializeField] protected Vector3 TargetPosition;

    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }
    protected virtual void GetTargetPosition()
    {
        //lay vi tri con tro chuot
        this.TargetPosition = InputManager.Instance.MouseWorldPos;
        this.TargetPosition.z = 0;
    }
    //nhin theo con tro chuot
    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.TargetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected virtual void Moving()
    {
        //lerp la tinh trung diem lam cho chuyen dong muot ma hon
        //vi tri hien tai, vi tri con tau di chuyen den, toc do
        Vector3 newPos = Vector3.Lerp(transform.position, TargetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
