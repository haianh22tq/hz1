using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : HaiMonoBehaviour
{
    [Header("Junk Random")]
    [SerializeField] private JunkSpawnerCtrl junkSpawnerCtrl;
    public JunkSpawnerCtrl JunkSpawnerCtrl { get => junkSpawnerCtrl; }

    [SerializeField] protected float randomDelay = 1f; // sau bao nhieu s spawn obj ra 1 lan
    [SerializeField] protected float randomTimer = 0f; // dem xem da duoc bao nhieu s roi
    [SerializeField] protected float randomLimit = 9f; // gioi han spawn

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();

    }


    protected virtual void LoadJunkCtrl()
    {
        if (this.JunkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkSpawner", gameObject);
    }

    protected override void Start()
    {
        //this.JunkSpawning();
    }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();    
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;


        Transform randPos = this.JunkSpawnerCtrl.SpawnPoint.GetRandom();
        Vector3 pos = randPos.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefabs();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
        //spawn obj sau moi 1s
        //Invoke(nameof(this.JunkSpawning), 1f);
    }

    protected virtual bool RandomReachLimit() // kiem tra xem da spawn ra du limit chua
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }


}
