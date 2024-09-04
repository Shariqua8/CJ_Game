using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class AIPuppetCarmine : MonoBehaviour
{
    public AudioSource melodyPuppetCarmine;
    public AudioSource gibberishPuppetCarmine;

    public VideoPlayer statico;
    public RawImage video;

    public SpriteRenderer imagePuppetCarmineCameraPuppetIdle;
    public SpriteRenderer imagePuppetCarmineCameraPuppetBody;
    public SpriteRenderer imagePuppetCarmineCameraPuppetMonitor;
    public SpriteRenderer imageUfficio;

    public Button pulsanteRiavviaComputer;
    public Button pulsanteCam;

    public int num_IA = 0;

    public GameObject cameras;
    public GameObject moltenCarmine;

    public bool[] arrayFase = {true, false, false};

    bool stato = false;
    public bool attacco = false;

    [System.Obsolete]
    // Start is called before the first frame update
    void Start()
    {
        imagePuppetCarmineCameraPuppetIdle.enabled = true;
        imagePuppetCarmineCameraPuppetBody.enabled = false;
        imagePuppetCarmineCameraPuppetMonitor.enabled = false;
        imageUfficio.enabled = true;

        pulsanteRiavviaComputer.gameObject.SetActive(false);

        statico.GetComponent<VideoPlayer>();

        //SOLO PER STATICO//
        // Assegna il target texture del VideoPlayer alla RawImage
        video.texture = statico.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        statico.loopPointReached += OnVideoEnd;

        changeMove();
    }

    [System.Obsolete]
    // Update is called once per frame
    void Update()
    {
        if(moltenCarmine.GetComponent<AIMoltenCarmine>().flagPuppet == true)
        {
            pulsanteCam.gameObject.SetActive(false);

        }  
    }

    [System.Obsolete]
    void changeMove()
    {
        int num_casual;
        num_casual = Random.RandomRange(1, 20);

        Debug.Log(num_IA);
        if(num_IA != 0)
        {
            Debug.Log(num_casual);
            if (num_casual <= num_IA)
            {
                if(attacco == true)
                {
                    Invoke("PuppetCarmineFase", 16f);
                }
                else
                {
                    Invoke("PuppetCarmineFase", 10f);
                }
            
            }
            else
            {
                Invoke("changeMove", 10f);
            }
        }
        else
        {
            Invoke("changeMove", 8f);
        }
        
    }

    [System.Obsolete]
    void PuppetCarmineFase()
    {
        if (arrayFase[0] && cameras.GetComponent<CameraManager>().IsCamera_Office() == true)
        {
            gibberishPuppetCarmine.Stop();
            melodyPuppetCarmine.Play();
            StartCoroutine(PlayVideo());
            video.enabled = true;
            imagePuppetCarmineCameraPuppetIdle.enabled = false;
            imagePuppetCarmineCameraPuppetBody.enabled = true;

            arrayFase[0] = false;
            arrayFase[1] = true;

            stato = false;
            StopCoroutine(PlayVideo());
        }
        if(arrayFase[1] == true && stato == true && cameras.GetComponent<CameraManager>().IsCamera_Office() == true)
        {
            melodyPuppetCarmine.Stop();
            StartCoroutine(PlayVideo());
            video.enabled = true;
            imagePuppetCarmineCameraPuppetBody.enabled = false;
            imageUfficio.enabled = false;
            imagePuppetCarmineCameraPuppetMonitor.enabled = true;

            arrayFase[1] = false;

            pulsanteRiavviaComputer.gameObject.SetActive(true);
            pulsanteCam.gameObject.SetActive(false);

            attacco = true;

            stato = false;

            cameras.GetComponent<CameraManager>().CamOff();

            StopCoroutine(PlayVideo());
        }
        if(arrayFase[2] == true && stato == true)
        {
            gibberishPuppetCarmine.Play();
            StartCoroutine(PlayVideo());
            video.enabled = true;
            pulsanteRiavviaComputer.gameObject.SetActive(false);
            imageUfficio.enabled = true;
            imagePuppetCarmineCameraPuppetMonitor.enabled = false;
            imagePuppetCarmineCameraPuppetIdle.enabled = true;

            moltenCarmine.GetComponent<AIMoltenCarmine>().flagPuppet = false;

            arrayFase[2] = false;
            arrayFase[0] = true;

            attacco = false;

            stato = false;
            StopCoroutine(PlayVideo());
        }

        stato = true;

        Invoke("changeMove", 8f);
    }

    [System.Obsolete]
    public void RiavviaComputer()
    {
        cameras.GetComponent<CameraManager>().CamDown();
        cameras.GetComponent<CameraManager>().CamUpRiavvio();

        arrayFase[2] = true;

        stato = true;

        PuppetCarmineFase();
    }


    private void OnVideoEnd(VideoPlayer vp)
    {
        // Rimuovi il video quando è finito
        video.enabled = false;
    }

    IEnumerator PlayVideo()
    {
        statico.Prepare();

        while (!statico.isPrepared)
        {
            yield return null;
        }

        statico.Play();
    }
}
