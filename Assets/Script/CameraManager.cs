using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private TextMeshProUGUI TextCondotto;
    private TextMeshProUGUI TextCondotto2;
    private TextMeshProUGUI TextisFull;
    private TextMeshProUGUI TextSiNO;

    public TextMeshProUGUI TextShock;

    public SpriteRenderer monitorUp;
    public SpriteRenderer monitorDown;

    public Image map;
    public Image border;

    public string TextMeshCondotto;
    public string TextMeshCondotto2;
    public string TextMeshCondotto3;
    public string TextMeshCondotto4;

    public string TextMeshShock;

    public RawImage video;
    public RawImage video2;
    public Camera office;
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam6;
    public Camera cam7;

    public Button camUP;
    public Button camDOWN;
    public Button pulsanteCam3;
    public Button pulsanteCam7;

    private bool cam1_state = false;
    private bool cam2_state = false;
    private bool cam3_state = false;
    private bool cam4_state = false;
    private bool cam5_state = false;
    private bool cam6_state = false;
    private bool cam7_state = false;
    private bool cam_office = false;

    private int cam_state = 1;

    public GameObject camUp;
    public GameObject camDown;
    public GameObject managerAnimationMonitor;

    // Start is called before the first frame update
    void Start()
    {
        // Trova l'oggetto con il nome specificato
        GameObject objWithTMP = GameObject.Find(TextMeshCondotto);
        
        // Trova l'oggetto con il nome specificato
        GameObject objWithTMP2 = GameObject.Find(TextMeshCondotto2);

        // Trova l'oggetto con il nome specificato
        GameObject objWithTMP3 = GameObject.Find(TextMeshCondotto3);

        GameObject objWithTMP4 = GameObject.Find(TextMeshCondotto4);

        GameObject objWithTMP5 = GameObject.Find(TextMeshShock);


        TextCondotto = objWithTMP.GetComponent<TextMeshProUGUI>();
        TextCondotto2 = objWithTMP2.GetComponent<TextMeshProUGUI>();
        TextisFull = objWithTMP3.GetComponent<TextMeshProUGUI>();
        TextSiNO = objWithTMP4.GetComponent<TextMeshProUGUI>();

        TextShock = objWithTMP5.GetComponent<TextMeshProUGUI>();

        office.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        border.gameObject.SetActive(false);
        map.gameObject.SetActive(false);

        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);

        video2.enabled = false;

        video.enabled = false;

        cam_office = true;

        camUp.SetActive(true);
        camDown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CamUpRiavvio()
    {
        camUp.SetActive(false);
        camDown.SetActive(false);

        video2.enabled = false;

        if(IsCamera7())
            TextShock.gameObject.SetActive(true);

        if (IsCamera3())
        {
            TextCondotto.gameObject.SetActive(true);
            TextCondotto2.gameObject.SetActive(true);
            TextisFull.gameObject.SetActive(true);
            TextSiNO.gameObject.SetActive(true);
        }

        monitorDown.gameObject.SetActive(false);
        monitorUp.gameObject.SetActive(false);

        Invoke("CamUp", 7f);
    }

    public void CamOff()
    {
        CamDown();
        office.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        video.gameObject.SetActive(false);
        video.GetComponent<RawImage>().enabled = false;

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        video2.enabled = false;

        TextisFull.gameObject.SetActive(false);
       

        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);


        border.gameObject.SetActive(false);
        map.gameObject.SetActive(false);

        monitorUp.gameObject.SetActive(false);
        monitorDown.gameObject.SetActive(false);

        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        camUp.SetActive(false);
        camDown.SetActive(false);
    }

    public void CamUpDelay()
    {
        Invoke("CamUp", 0.25f);
        DisableTemporarlyCamDOWN();
        Invoke("EnableTemporarlyCamDOWN", 1f);
    }

    public void CamDownDelay()
    {
        Invoke("CamDownRivisited", 0.25f);
        
    }

    public void DisableTemporarlyCamUP()
    {
        camUP.gameObject.SetActive(false);
    }
    public void DisableTemporarlyCamDOWN()
    {
        camDOWN.gameObject.SetActive(false);
    }
    public void EnableTemporarlyCamUP()
    {
        camUP.gameObject.SetActive(true);

    }
    public void EnableTemporarlyCamDOWN()
    {
        camDOWN.gameObject.SetActive(true);

    }

    //CAM UP & CAM DOWN//

    public void CamState(int x)
    {
        switch (x)
        {
            case 1:
                cam1.gameObject.SetActive(true);
                cam2.gameObject.SetActive(false);
                cam3.gameObject.SetActive(false);
                cam4.gameObject.SetActive(false);
                cam5.gameObject.SetActive(false);
                cam6.gameObject.SetActive(false);
                cam7.gameObject.SetActive(false);

                pulsanteCam3.gameObject.SetActive(false);
                pulsanteCam7.gameObject.SetActive(false);

                TextCondotto.gameObject.SetActive(false);
                TextCondotto2.gameObject.SetActive(false);
                TextisFull.gameObject.SetActive(false);
                TextSiNO.gameObject.SetActive(false);

                TextShock.gameObject.SetActive(false);


                cam1_state = true;
                cam2_state = false;
                cam3_state = false;
                cam4_state = false;
                cam5_state = false;
                cam6_state = false;
                cam7_state = false;
                break;
            case 2:
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(true);
                cam3.gameObject.SetActive(false);
                cam4.gameObject.SetActive(false);
                cam5.gameObject.SetActive(false);
                cam6.gameObject.SetActive(false);
                cam7.gameObject.SetActive(false);

                pulsanteCam3.gameObject.SetActive(false);
                pulsanteCam7.gameObject.SetActive(false);

                TextCondotto.gameObject.SetActive(false);
                TextCondotto2.gameObject.SetActive(false);
                TextisFull.gameObject.SetActive(false);
                TextSiNO.gameObject.SetActive(false);

                TextShock.gameObject.SetActive(false);


                cam1_state = false;
                cam2_state = true;
                cam3_state = false;
                cam4_state = false;
                cam5_state = false;
                cam6_state = false;
                cam7_state = false;
                break;
            case 3:
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                cam3.gameObject.SetActive(true);
                cam4.gameObject.SetActive(false);
                cam5.gameObject.SetActive(false);
                cam6.gameObject.SetActive(false);
                cam7.gameObject.SetActive(false);

                pulsanteCam3.gameObject.SetActive(true);
                pulsanteCam7.gameObject.SetActive(false);

                TextCondotto.gameObject.SetActive(true);
                TextCondotto2.gameObject.SetActive(true);
                TextisFull.gameObject.SetActive(true);
                TextSiNO.gameObject.SetActive(true);
                
                TextShock.gameObject.SetActive(false);


                cam1_state = false;
                cam2_state = false;
                cam3_state = true;
                cam4_state = false;
                cam5_state = false;
                cam6_state = false;
                cam7_state = false;
                break;
            case 4:
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                cam3.gameObject.SetActive(false);
                cam4.gameObject.SetActive(true);
                cam5.gameObject.SetActive(false);
                cam6.gameObject.SetActive(false);
                cam7.gameObject.SetActive(false);

                pulsanteCam3.gameObject.SetActive(false);
                pulsanteCam7.gameObject.SetActive(false);

                TextCondotto.gameObject.SetActive(false);
                TextCondotto2.gameObject.SetActive(false);
                TextisFull.gameObject.SetActive(false);
                TextSiNO.gameObject.SetActive(false);

                TextShock.gameObject.SetActive(false);


                cam1_state = false;
                cam2_state = false;
                cam3_state = false;
                cam4_state = true;
                cam5_state = false;
                cam6_state = false;
                cam7_state = false;
                break;
            case 5:
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                cam3.gameObject.SetActive(false);
                cam4.gameObject.SetActive(false);
                cam5.gameObject.SetActive(true);
                cam6.gameObject.SetActive(false);
                cam7.gameObject.SetActive(false);

                pulsanteCam3.gameObject.SetActive(false);
                pulsanteCam7.gameObject.SetActive(false);

                TextCondotto.gameObject.SetActive(false);
                TextCondotto2.gameObject.SetActive(false);
                TextisFull.gameObject.SetActive(false);
                TextSiNO.gameObject.SetActive(false);

                TextShock.gameObject.SetActive(false);


                cam1_state = false;
                cam2_state = false;
                cam3_state = false;
                cam4_state = false;
                cam5_state = true;
                cam6_state = false;
                cam7_state = false;
                break;
            case 6:
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                cam3.gameObject.SetActive(false);
                cam4.gameObject.SetActive(false);
                cam5.gameObject.SetActive(false);
                cam6.gameObject.SetActive(true);
                cam7.gameObject.SetActive(false);

                pulsanteCam3.gameObject.SetActive(false);
                pulsanteCam7.gameObject.SetActive(false);

                TextCondotto.gameObject.SetActive(false);
                TextCondotto2.gameObject.SetActive(false);
                TextisFull.gameObject.SetActive(false);
                TextSiNO.gameObject.SetActive(false);

                TextShock.gameObject.SetActive(false);


                cam1_state = false;
                cam2_state = false;
                cam3_state = false;
                cam4_state = false;
                cam5_state = false;
                cam6_state = true;
                cam7_state = false;
                break;
            case 7:
                cam1.gameObject.SetActive(false);
                cam2.gameObject.SetActive(false);
                cam3.gameObject.SetActive(false);
                cam4.gameObject.SetActive(false);
                cam5.gameObject.SetActive(false);
                cam6.gameObject.SetActive(false);
                cam7.gameObject.SetActive(true);

                pulsanteCam3.gameObject.SetActive(false);
                pulsanteCam7.gameObject.SetActive(true);

                TextCondotto.gameObject.SetActive(false);
                TextCondotto2.gameObject.SetActive(false);
                TextisFull.gameObject.SetActive(false);
                TextSiNO.gameObject.SetActive(false);

                TextShock.gameObject.SetActive(true);


                cam1_state = false;
                cam2_state = false;
                cam3_state = false;
                cam4_state = false;
                cam5_state = false;
                cam6_state = false;
                cam7_state = true;
                break;
            default:
                Debug.Log("Non esiste la telecamera!");

                cam1_state = false;
                cam2_state = false;
                cam3_state = false;
                cam4_state = false;
                cam5_state = false;
                cam6_state = false;
                cam7_state = false;
                break;
        }
    }

    public void CamUp()
    {
        monitorDown.gameObject.SetActive(false);
        monitorUp.gameObject.SetActive(true);

        office.gameObject.SetActive(false);
        CamState(cam_state);

        border.gameObject.SetActive(true);
        map.gameObject.SetActive(true);


        video2.enabled = true;


        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam_office = false;
    }

    public void CamDownRivisited()
    {
        DisableTemporarlyCamUP();

        office.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        video.gameObject.SetActive(false);
        video.enabled = false;

        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);


        border.gameObject.SetActive(false);
        map.gameObject.SetActive(false);
        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);


        video2.enabled = false;


        camUp.SetActive(true);
        camDown.SetActive(false);


        cam_office = true;
        cam1_state = false;
        cam2_state = false;
        cam3_state = false;
        cam4_state = false;
        cam5_state = false;
        cam6_state = false;
        cam7_state = false;
    }

    public void CamDown()
    {
        office.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        video.gameObject.SetActive(false);
        video.enabled = false;

        border.gameObject.SetActive(false);
        map.gameObject.SetActive(false);

        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);


        video2.enabled = false;


        camUp.SetActive(true);
        camDown.SetActive(false);

        cam_office = true;
        cam1_state = false;
        cam2_state = false;
        cam3_state = false;
        cam4_state = false;
        cam5_state = false;
        cam6_state = false;
        cam7_state = false;
    }

    //CAMERAS//

    public void Camera1()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(true);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        cam_state = 1;

        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);

        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam1_state = true;
        cam2_state = false;
        cam3_state = false;
        cam4_state = false;
        cam5_state = false;
        cam6_state = false;
        cam7_state = false;
    }
    public void Camera2()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(true);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        cam_state = 2;


        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);

        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam2_state = true;
        cam1_state = false;
        cam3_state = false;
        cam4_state = false;
        cam5_state = false;
        cam6_state = false;
        cam7_state = false;
    }


    public void Camera3()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(true);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        cam_state = 3;


        pulsanteCam3.gameObject.SetActive(true);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(true);
        TextCondotto2.gameObject.SetActive(true);
        TextisFull.gameObject.SetActive(true);
        TextSiNO.gameObject.SetActive(true);

        TextShock.gameObject.SetActive(false);

        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam3_state = true;
        cam1_state = false;
        cam2_state = false;
        cam4_state = false;
        cam5_state = false;
        cam6_state = false;
        cam7_state = false;
    }

    public void Camera4()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(true);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        cam_state = 4;


        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);

        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam4_state = true;
        cam1_state = false;
        cam2_state = false;
        cam3_state = false;
        cam5_state = false;
        cam6_state = false;
        cam7_state = false;
    }

    public void Camera5()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(true);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(false);

        cam_state = 5;


        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(false);

        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam5_state = true;
        cam1_state = false;
        cam2_state = false;
        cam3_state = false;
        cam4_state = false;
        cam6_state = false;
        cam7_state = false;
    }

    public void Camera6()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(true);
        cam7.gameObject.SetActive(false);

        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(false);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);
        TextShock.gameObject.SetActive(false);


        cam_state = 6;


        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam6_state = true;
        cam1_state = false;
        cam2_state = false;
        cam3_state = false;
        cam5_state = false;
        cam4_state = false;
        cam7_state = false;
    }

    public void Camera7()
    {
        office.gameObject.SetActive(false);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam3.gameObject.SetActive(false);
        cam4.gameObject.SetActive(false);
        cam5.gameObject.SetActive(false);
        cam6.gameObject.SetActive(false);
        cam7.gameObject.SetActive(true);

        cam_state = 7;


        pulsanteCam3.gameObject.SetActive(false);
        pulsanteCam7.gameObject.SetActive(true);

        TextCondotto.gameObject.SetActive(false);
        TextCondotto2.gameObject.SetActive(false);
        TextisFull.gameObject.SetActive(false);
        TextSiNO.gameObject.SetActive(false);

        TextShock.gameObject.SetActive(true);

        video.gameObject.SetActive(true);

        camUp.SetActive(false);
        camDown.SetActive(true);

        cam7_state = true;
        cam1_state = false;
        cam2_state = false;
        cam3_state = false;
        cam5_state = false;
        cam6_state = false;
        cam4_state = false;
    }


    //IsCameras//
    public bool IsCamera_Office()
    {
        return cam_office;
    }


    public bool IsCamera1()
    {
        return cam1_state;
    }

    public bool IsCamera2()
    {
        return cam2_state;
    }
    public bool IsCamera3()
    {
        return cam3_state;
    }
    public bool IsCamera4()
    {
        return cam4_state;
    }
    public bool IsCamera5()
    {
        return cam5_state;
    }
    public bool IsCamera6()
    {
        return cam6_state;
    }
    public bool IsCamera7()
    {
        return cam7_state;
    }
}
