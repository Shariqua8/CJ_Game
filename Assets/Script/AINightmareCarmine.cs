using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class AINightmareCarmine : MonoBehaviour
{
    public AudioSource whispersPhantomCarmine;

    public VideoPlayer statico;
    public RawImage video;

    public SpriteRenderer imageNightmareCarmineIngresso;
    public SpriteRenderer imageNightmareCarmineSalone;
    public SpriteRenderer imageNightmareCarmineCorridoioE;
    public SpriteRenderer imageNightmareCarmineCucina;

    public int num_IA = 0;

    public GameObject cameras;
    public GameObject witheredCarmine;
    public GameObject classicCarmine;
    public GameObject moltenCarmine;
    public GameObject puppetCarmine;

    [System.Obsolete]
    // Start is called before the first frame update
    void Start()
    {
        imageNightmareCarmineIngresso.enabled = false;
        imageNightmareCarmineSalone.enabled = false;
        imageNightmareCarmineCucina.enabled = false;
        imageNightmareCarmineCorridoioE.enabled = false;

        statico.GetComponent<VideoPlayer>();

        //SOLO PER STATICO//
        // Assegna il target texture del VideoPlayer alla RawImage
        video.texture = statico.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        statico.loopPointReached += OnVideoEnd;

        video.enabled = false;

        changeMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    void changeMove()
    {
        int num_casual;
        num_casual = Random.RandomRange(1, 20);


        if (!puppetCarmine.GetComponent<AIPuppetCarmine>().attacco)
        {
            if(num_IA != 0)
            {
                Debug.Log(num_casual);
                if (num_casual <= num_IA)
                {
                    Invoke("NightmareCarmineMovement", 20f);
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
    }

    [System.Obsolete]
    void NightmareCarmineMovement()
    {
        int num_casual2 = Random.RandomRange(0, 4);

        if (!puppetCarmine.GetComponent<AIPuppetCarmine>().attacco && moltenCarmine.GetComponent<AIMoltenCarmine>().arrayFase[3] == false)
        {
            if (num_casual2 == 0 && classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineIngresso.enabled == false)
            {
                whispersPhantomCarmine.Play();
                StartCoroutine(PlayVideo());

                video.enabled = true;

                Debug.Log(num_casual2 + "Nightmare");
                imageNightmareCarmineIngresso.enabled = true;
                Invoke("NightmareCarmineCase1", 12f);
            
                StopCoroutine(PlayVideo());
            }
            if (num_casual2 == 1 && classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineSalone.enabled == false && witheredCarmine.GetComponent<AIWitheredCarmine>().imageWitheredCarmineSalone.enabled == false && classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled == false && classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled == false && witheredCarmine.GetComponent<AIWitheredCarmine>().imageWitheredCarmineSalone2 == false)
            {
                whispersPhantomCarmine.Play();

                StartCoroutine(PlayVideo());

                video.enabled = true;

                Debug.Log(num_casual2 + "Nightmare");
                imageNightmareCarmineSalone.enabled = true;
                Invoke("NightmareCarmineCase2", 12f);

                StopCoroutine(PlayVideo());
            }
            if(num_casual2 == 2 && classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineCorridoioE.enabled == false)
            {
                whispersPhantomCarmine.Play();

                StartCoroutine(PlayVideo());

                video.enabled = true;

                Debug.Log(num_casual2 + "Nightmare");
                imageNightmareCarmineCorridoioE.enabled = true;
                Invoke("NightmareCarmineCase3", 12f);

                StopCoroutine(PlayVideo());
            }
            if (num_casual2 == 3 && witheredCarmine.GetComponent<AIWitheredCarmine>().imageWitheredCarmineCucina.enabled == false)
            {
                whispersPhantomCarmine.Play();

                StartCoroutine(PlayVideo());

                video.enabled = true;

                Debug.Log(num_casual2 + "Nightmare");
                imageNightmareCarmineCucina.enabled = true;
                Invoke("NightmareCarmineCase4", 12f);

                StopCoroutine(PlayVideo());
            }
        }

        Invoke("changeMove", 10f);


    }

    void NightmareCarmineCase1()
    {
        StartCoroutine(PlayVideo());

        video.enabled = true;

        if (cameras.GetComponent<CameraManager>().IsCamera1() == true)
        {
            imageNightmareCarmineIngresso.enabled = false;
        }
        else
        {
            imageNightmareCarmineIngresso.enabled = false;
            cameras.GetComponent<CameraManager>().CamDown();
            cameras.GetComponent<CameraManager>().CamUpRiavvio();
        }

        StopCoroutine(PlayVideo());
    }
    void NightmareCarmineCase2()
    {
        StartCoroutine(PlayVideo());

        video.enabled = true;

        if (cameras.GetComponent<CameraManager>().IsCamera2() == true)
        {
            imageNightmareCarmineSalone.enabled = false;
        }
        else
        {
            imageNightmareCarmineSalone.enabled = false;
            cameras.GetComponent<CameraManager>().CamDown();
            cameras.GetComponent<CameraManager>().CamUpRiavvio();
        }

        StopCoroutine(PlayVideo());
    }
    void NightmareCarmineCase3()
    {
        StartCoroutine(PlayVideo());

        video.enabled = true;

        if (cameras.GetComponent<CameraManager>().IsCamera4() == true)
        {
            imageNightmareCarmineCorridoioE.enabled = false;
        }
        else
        {
            imageNightmareCarmineCorridoioE.enabled = false;
            cameras.GetComponent<CameraManager>().CamDown();
            cameras.GetComponent<CameraManager>().CamUpRiavvio();
        }
        
        StopCoroutine(PlayVideo());
    }
    void NightmareCarmineCase4()
    {
        StartCoroutine(PlayVideo());

        video.enabled = true;

        if (cameras.GetComponent<CameraManager>().IsCamera3() == true)
        {
            imageNightmareCarmineCucina.enabled = false;
        }
        else
        {
            imageNightmareCarmineCucina.enabled = false;
            cameras.GetComponent<CameraManager>().CamDown();
            cameras.GetComponent<CameraManager>().CamUpRiavvio();
        }

        StopCoroutine(PlayVideo());
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
