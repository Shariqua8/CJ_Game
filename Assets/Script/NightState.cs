using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NightState : MonoBehaviour
{
    public GameObject dataPlayer;
    private TextMeshProUGUI TextState;
    public string textMeshProObjectName = "StatoNotte";

    // Start is called before the first frame update
    void Start()
    {
        GameObject objWithTMP = GameObject.Find(textMeshProObjectName);

        TextState = objWithTMP.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(textMeshProObjectName == "StatoNotte")
        {
            ControllaNotteStato();
        }
        else
        {
            ControllaNotteStato12AM();
        }
    }
    
    void ControllaNotteStato()
    {
        dataPlayer.GetComponent<PlayerNightData>().ReadFile();

        switch (dataPlayer.GetComponent<PlayerNightData>().LevelNight)
        {
            case 1:
                TextState.text = "Night 1";
                break;
            case 2:
                TextState.text = "Night 2";
                break;
            case 3:
                TextState.text = "Night 3";
                break;
            case 4:
                TextState.text = "Night 4";
                break;
            case 5:
                TextState.text = "Night 5";
                break;
            default:
                TextState.text = "Night 5";
                break;
        }
    }

    void ControllaNotteStato12AM()
    {
        dataPlayer.GetComponent<PlayerNightData>().ReadFile();

        switch (dataPlayer.GetComponent<PlayerNightData>().LevelNight)
        {
            case 1:
                TextState.text = "Night 1";
                break;
            case 2:
                TextState.text = "Night 2";
                break;
            case 3:
                TextState.text = "Night 3";
                break;
            case 4:
                TextState.text = "Night 4";
                break;
            case 5:
                TextState.text = "Night 5";
                break;
            case 6:
                TextState.text = "Night 6";
                break;
            case 7:
                TextState.text = "Night 7";
                break;
            default:
                TextState.text = "Night";
                break;
        }
    }
}
