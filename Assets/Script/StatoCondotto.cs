using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatoCondotto : MonoBehaviour
{
    private TextMeshProUGUI condottoText;

    public GameObject witheredCarmine;
    public GameObject cameras;

    // Start is called before the first frame update
    void Start()
    {
        condottoText = GetComponent<TextMeshProUGUI>();

        condottoText.color = Color.red;
        condottoText.text = "Aperto";
    }

    // Update is called once per frame
    void Update()
    {
        if(witheredCarmine.GetComponent<AIWitheredCarmine>().condottoChiuso == true && cameras.GetComponent<CameraManager>().IsCamera3())
        {
            condottoText.color = Color.green;
            condottoText.text = "Chiuso";
        }
        else if(witheredCarmine.GetComponent<AIWitheredCarmine>().condottoChiuso == false && cameras.GetComponent<CameraManager>().IsCamera3())
        {
            condottoText.color = Color.red;
            condottoText.text = "Aperto";
        }
    }
}
