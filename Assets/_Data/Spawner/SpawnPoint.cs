using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : HaiMonoBehaviour
{
    [SerializeField] protected List<Transform> points;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
        
    }

    protected virtual void LoadPoints()
    {
        // neu nhu da co point thi khong lam gi ca
        if (this.points.Count > 0) return;
        //neu khong co thi tim tat ca point co trong transform, chinh la trong parent
        foreach(Transform point in transform)
        {
            //add point da tim duoc vao trong list point
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }
}
