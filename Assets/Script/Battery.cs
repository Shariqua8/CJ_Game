using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class Battery : MonoBehaviour
{
    public Animator animateDoorUp;
    public Animator animateDoorDown;

    public AudioSource powerdown;
    public AudioSource lightBuzz;

    private TextMeshProUGUI batteryText;
    public SpriteRenderer imageUfficio;
    public SpriteRenderer imageUfficioSpento;
    public double battery = 100;

    public VideoClip JumpscareCarmineUfficioSpento;
    public VideoClip JumpscareWitheredCarmineUfficioSpento;

    public Image batterySlot;

    public GameObject cameras;
    public GameObject classicCarmine;
    public GameObject witheredCarmine;
    public GameObject phantomCarmine;
    public GameObject moltenCarmine;
    public GameObject puppetCarmine;

    public GameObject pulsanteChiudiPorta;
    public GameObject pulsanteApriPorta;
    public Collider2D pulsanteCollider;

    private bool stato = false;

    [System.Obsolete]
    // Start is called before the first frame update
    void Start()
    {
        imageUfficio.enabled = true;
        imageUfficioSpento.enabled = false;
        batteryText = GetComponent<TextMeshProUGUI>();

        BatteryChange();
    }

    [System.Obsolete]
    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Obsolete]
    public void BatteryChange()
    {
        if (stato == false)
        {
            if (battery > 1)
            {
                battery = battery - 1;

                //cameraBattery();
                doorBattery();
                conductBattery();
                shockBattery();

                batteryText.text = battery.ToString("0") + "%";
                Invoke("BatteryChange", 5f);
            }
            else
            {
                Debug.Log(battery + "Batteria");
                battery = battery - 1;
                stato = true;

                levelBattery();
            }

        }
    }

    [System.Obsolete]
    public void levelBattery()
    {
        if(battery <= 0)
        {
            if (puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA > 0 && puppetCarmine.GetComponent<AIPuppetCarmine>().attacco == true)
            {
                puppetCarmine.GetComponent<AIPuppetCarmine>().RiavviaComputer();
            }
            
            cameras.GetComponent<CameraManager>().CamDown();
            cameras.GetComponent<CameraManager>().CamOff();

            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 0;

            classicCarmine.GetComponent<AIClassicCarmine>().jumpscare.clip = JumpscareCarmineUfficioSpento;
            witheredCarmine.GetComponent<AIWitheredCarmine>().jumpscare.clip = JumpscareWitheredCarmineUfficioSpento;

            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 0;

            batterySlot.GetComponent<Image>().gameObject.SetActive(false);

            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 0;
            puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[0] = false;
            puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[1] = false;
            puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[2] = false;

            batteryText.enabled = false;

            imageUfficio.enabled = false;
            imageUfficioSpento.enabled = true;

            pulsanteChiudiPorta.gameObject.SetActive(false);
            pulsanteApriPorta.gameObject.SetActive(true);
            pulsanteCollider.gameObject.SetActive(false);

            classicCarmine.GetComponent<AIClassicCarmine>().portaChiusa = false;

            witheredCarmine.GetComponent<AIWitheredCarmine>().condottoChiuso = false;

            classicCarmine.GetComponent<AIClassicCarmine>().portaChiusa = false;
            witheredCarmine.GetComponent<AIWitheredCarmine>().condottoChiuso = false;

            lightBuzz.loop = false;
            lightBuzz.Stop();

            powerdown.Play();

        }
    }

    /*void cameraBattery()
    {
        if (cameras.GetComponent<CameraManager>().IsCamera_Office() == false)
        {
            battery = battery - 0.3;
        }
    }*/

    void doorBattery()
    {
        if(classicCarmine.GetComponent<AIClassicCarmine>().portaChiusa == true)
        {
            battery = battery - 0.5;
        }
    }

    void conductBattery()
    {
        if(witheredCarmine.GetComponent<AIWitheredCarmine>().condottoChiuso == true)
        {
            battery = battery - 0.5;
        }
    }
    

    void shockBattery()
    {
        if(moltenCarmine.GetComponent<AIMoltenCarmine>().scossa == true)
        {
            battery = battery - 0.8;
        }
    }
}
