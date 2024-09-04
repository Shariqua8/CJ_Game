using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneNameDelay;
    public bool stato= false;
    private void Start()
    {
    }
    public void Update()
    {
        PlaySceneDelayedInvoke();
        PlaySceneMoreDelayedInvoke();
    }

    public void PlayScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySceneDelayedInvoke()
    {
        if(SceneNameDelay != "Null" && stato == false)
        {
            Invoke("PlaySceneDelayed", 1.5f);
        }
    }
    public void PlaySceneMoreDelayedInvoke()
    {
        if (SceneNameDelay != "Null" && stato)
        {
            Invoke("PlaySceneDelayed", 10f);
        }
    }

    public void PlaySceneDelayed()
    {
        if(SceneNameDelay != "Null")
            SceneManager.LoadScene(SceneNameDelay);
    }
}
