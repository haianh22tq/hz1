using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ShipMovement
{
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }
    protected virtual void GetMousePosition()
    {
        //lay vi tri con tro chuot
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }
}
