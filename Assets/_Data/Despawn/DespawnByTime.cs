using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected float timer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer(); // khi obect dduowjc bat len thi reset timer
    }

    protected virtual void ResetTimer()
    {
        this.timer = 0f;
    }

    protected override bool CanDespawn() // toi gio thi duoc phep Despawn va nguoc lai
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }
}
