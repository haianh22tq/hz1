using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//abstract giup cho class khong duoc su dung truc tiep ra ben ngoai
public abstract class Spawner : HaiMonoBehaviour
{
    //public static Spawner instance;
    [SerializeField] protected Transform holder;

    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObj;
    [SerializeField] private int spawnedCount = 0;

    public int SpawnedCount { get => spawnedCount; }

    /*protected override void Awake()
    {
        base.Awake();
        Spawner.instance = this;
    }*/
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
        this.LoadHolder();
    }


    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
        }
        this.HidePrefabs();

        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ":LoadHolder", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("prefab not found" + prefabName);
            return null;
        }
        return this.Spawn(prefab, spawnPos, rotation);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        //Transform newPrefabs = Instantiate(prefab, spawnPos, rotation);
        Transform newPrefabs = this.GetObjectFromPool(prefab);
        newPrefabs.SetPositionAndRotation(spawnPos, rotation);

        newPrefabs.parent = this.holder;
        this.spawnedCount++;
        return newPrefabs;
    }


    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObj)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObj.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        this.poolObj.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }

    public virtual Transform RandomPrefabs()
    {
        int rand = Random.Range(0, this.prefabs.Count);
        //chon trong danh sach prefabs để trả ra
        return this.prefabs[rand];
    }
}
