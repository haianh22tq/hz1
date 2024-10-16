using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentFly : HaiMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    //direction = hướng
    [SerializeField] protected Vector3 direction = Vector3.right;

    private void Update()
    {
        // hàm bay( Translate)
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);

    }
}
