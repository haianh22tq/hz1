using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    /*[SerializeField] private Spawner spawner;
    public Spawner Spawner => spawner;*/
    [Header("Summon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 2;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearDeadMinions();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": LoadEnemySpawner", gameObject);
    }
    protected override void Summoning()
    {
        if (this.minions.Count >= minionLimit) return;
        base.Summoning();
    }
    protected override Transform Summon() // sau khi spawn enemy thi override lai ham nay
    {
        Transform minion = base.Summon();
        minion.parent = this.Abilities.AbilityObjectCtrl.transform;// thay doi parent thanh enemy
        this.minions.Add(minion);
        return minion;
    }

    protected virtual void ClearDeadMinions()
    {
        foreach(Transform minion in this.minions)
        {
            if(minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
}
