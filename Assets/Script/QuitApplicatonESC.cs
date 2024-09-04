using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplicatonESC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Chiamata alla funzione di uscita dall'applicazione
            QuitApplication();
        }
    }

    void QuitApplication()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
