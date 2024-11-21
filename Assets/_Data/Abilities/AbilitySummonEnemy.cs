using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    /*[SerializeField] private Spawner spawner;
    public Spawner Spawner => spawner;*/
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


}
