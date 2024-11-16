using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : HaiMonoBehaviour
{

    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown()
    {
        //Debug.Log("sence new");
        this.LoadGalaxy();
    }
    protected virtual void LoadGalaxy()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}
