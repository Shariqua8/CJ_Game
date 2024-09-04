using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatoRoom : MonoBehaviour
{
    private TextMeshProUGUI textStato;
    public GameObject cameras;

    // Start is called before the first frame update
    void Start()
    {
        textStato = GetComponent<TextMeshProUGUI>();

        textStato.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameras.GetComponent<CameraManager>().IsCamera_Office())
        {
            textStato.enabled = false;
        }
        if (cameras.GetComponent<CameraManager>().IsCamera1())
        {
            textStato.enabled = true;
            textStato.fontSize = 60;
            textStato.text = "Ingresso";
        }
        if (cameras.GetComponent<CameraManager>().IsCamera2())
        {
            textStato.enabled = true;
            textStato.fontSize = 60;
            textStato.text = "Salone";
        }
        if (cameras.GetComponent<CameraManager>().IsCamera3())
        {
            textStato.enabled = true;
            textStato.fontSize = 60;
            textStato.text = "Cucina";
        }
        if (cameras.GetComponent<CameraManager>().IsCamera4())
        {
            textStato.enabled = true;
            textStato.fontSize = 45;
            textStato.text = "Corridoio Esterno";
        }
        if (cameras.GetComponent<CameraManager>().IsCamera5())
        {
            textStato.enabled = true;
            textStato.fontSize = 45;
            textStato.text = "Corridoio Interno";
        }
        if (cameras.GetComponent<CameraManager>().IsCamera6())
        {
            textStato.enabled = true;
            textStato.fontSize = 45;
            textStato.text = "Stanza del Puppet";
        }
        if (cameras.GetComponent<CameraManager>().IsCamera7())
        {
            textStato.enabled = true;
            textStato.fontSize = 60;
            textStato.text = "Garage";
        }

    }
}
