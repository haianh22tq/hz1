using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 5f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }
    protected virtual void Following()
    {
        if (this.target == null) return;
        {
            transform.position = Vector3.Lerp(transform.position,this.target.position, this.speed * Time.fixedDeltaTime);
        }
    }
}
