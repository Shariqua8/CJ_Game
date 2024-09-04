using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMonitor : MonoBehaviour
{
    public Animator animateMonitorDown;
    public Animator animateMonitorUp;

    public bool statoUP = false;
    public bool statoDown = false;

    // Start is called before the first frame update
    void Start()
    {
        animateMonitorDown.gameObject.SetActive(false);
        animateMonitorUp.gameObject.SetActive(false);

        animateMonitorUp.enabled = false;
        animateMonitorDown.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonitorUp()
    {
        StartAnimationMonitorUp();
    }
    public void MonitorDown()
    {
        StartAnimationMonitorDown();
        Invoke("Azzera", 0.5f);
    }

    public void StartAnimationMonitorDown()
    {
        animateMonitorDown.enabled = true;

        animateMonitorDown.gameObject.SetActive(true);
        animateMonitorUp.gameObject.SetActive(false);

        statoDown = true;
    }
    public void StartAnimationMonitorUp()
    {
        animateMonitorUp.enabled = true;

        animateMonitorUp.gameObject.SetActive(true);
        animateMonitorDown.gameObject.SetActive(false);

        statoUP = true;
    }

    public void Azzera()
    {
        animateMonitorDown.gameObject.SetActive(false);
        animateMonitorUp.gameObject.SetActive(false);

        animateMonitorDown.enabled = false;
        animateMonitorUp.enabled = false;
    }
}
