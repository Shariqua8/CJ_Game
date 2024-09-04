using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class AIWitheredCarmine : MonoBehaviour
{
    public VideoClip videoCarmineWitheredJumpscare;
    public AudioSource walkWitheredCarmine;
    public AudioSource talkWitheredCarmine;
    public AudioSource strisciaWitheredCarmine;

    public VideoPlayer statico;
    public RawImage video;

    public VideoPlayer jumpscare;
    public RawImage videoJumpscare;

    public GameObject cameras;
    public GameObject puppetCarmine;

    public SpriteRenderer imageWitheredCarmineSalone;
    public SpriteRenderer imageWitheredCarmineSalone2;
    public SpriteRenderer imageWitheredCarmineSaloneBonus;
    public SpriteRenderer imageWitheredCarmineCucina;

    public int num_IAW = 0;

    //Inizialmente il Withered Carmine parte dal salone e segniamo quindi il suo stato
    public bool[] arrayRoom = {true, false, false, false, false , false};

    bool stato = false;
    public bool witheredCondotto = false;
    public bool condottoChiuso = false;

    public GameObject classicCarmine;

    [System.Obsolete]
    // Start is called before the first frame update
    void Start()
    {
        jumpscare.clip = videoCarmineWitheredJumpscare;

        imageWitheredCarmineSalone.enabled = true;
        imageWitheredCarmineSalone2.enabled = false;
        imageWitheredCarmineSaloneBonus.enabled = false;
        imageWitheredCarmineCucina.enabled = false;

        statico.GetComponent<VideoPlayer>();
        jumpscare.GetComponent<VideoPlayer>();

        //SOLO PER STATICO//
        // Assegna il target texture del VideoPlayer alla RawImage
        video.texture = statico.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        statico.loopPointReached += OnVideoEnd;


        //SOLO PER JUMPSCARE//
        // Assegna il target texture del VideoPlayer alla RawImage
        videoJumpscare.texture = jumpscare.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        jumpscare.loopPointReached += OnVideoEndJumpscare;

        videoJumpscare.enabled = false;
        video.enabled = false;

        video.gameObject.SetActive(true);
        video.enabled = false;

        changeMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameras.GetComponent<CameraManager>().IsCamera_Office())
        {
            video.gameObject.SetActive(false);
            statico.SetDirectAudioMute(0, true);
        }
        else
        {
            statico.SetDirectAudioMute(0, false);
        }
    }       

    [System.Obsolete]
    void changeMove()
    {
        int num_casual = 0;
        num_casual = Random.RandomRange(1, 20);

        if(num_IAW != 0)
        {
            Debug.Log(num_casual);
            if (num_casual <= num_IAW)
            {
                Invoke("WhiteredCarmineMovement", 14f);
            }
            else
            {
                Invoke("changeMove", 11f);
            }
        }
        else
        {
            Invoke("changeMove", 8f);
        }

    }

    [System.Obsolete]
    void WhiteredCarmineMovement()
    {
        
        if (arrayRoom[0] == true)
        {
            walkWitheredCarmine.Play();
            video.enabled = true;
            StartCoroutine(PlayVideo());
            if (classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[0] == true && classicCarmine.GetComponent<AIClassicCarmine>().num_IA > 0)
            {
                classicCarmine.GetComponent<AIClassicCarmine>().CaseWitheredCarmineClassicCarmine();
            }
            else
            {
                imageWitheredCarmineCucina.enabled = false;
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = false;
                imageWitheredCarmineSalone.enabled = false;
                imageWitheredCarmineSalone2.enabled = true;
                arrayRoom[0] = false;
                arrayRoom[1] = true;
            }

            StopCoroutine(PlayVideo());
            stato = false;
        }
        if(arrayRoom[1] == true && stato == true)
        {
            walkWitheredCarmine.Play();

            imageWitheredCarmineSalone.enabled = false;


            video.enabled = true;
            StartCoroutine(PlayVideo());

            if (classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[0] == true && classicCarmine.GetComponent<AIClassicCarmine>().num_IA > 0)
            {
                imageWitheredCarmineCucina.enabled = false;
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = false;
                imageWitheredCarmineSalone.enabled = false;
                imageWitheredCarmineSalone2.enabled = false;
                CaseWitheredCarmineClassicCarmine2();
            }
            else
            {
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = false;
                imageWitheredCarmineSalone.enabled = false;
                imageWitheredCarmineSalone2.enabled = false;
                imageWitheredCarmineCucina.enabled = true;

                arrayRoom[1] = false;
                arrayRoom[3] = true;

                stato = false;
            }



            StopCoroutine(PlayVideo());

            
        }
        if (arrayRoom[2] == true && stato == true)      //In questa parte arriva quando si avvera qualcosa di particolare e deve passare alla cucina, viene saltata se è già nella cucina
        {
            walkWitheredCarmine.Play();

            video.enabled = true;
            StartCoroutine(PlayVideo());
            classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
            imageWitheredCarmineSalone.enabled = false;
            classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = false;
            imageWitheredCarmineSalone2.enabled = false;
            imageWitheredCarmineCucina.enabled = true;
            arrayRoom[2] = false;
            arrayRoom[3] = true;

            StopCoroutine(PlayVideo());

            stato = false;
        }
        if(arrayRoom[3] == true && stato == true)
        {
            
            video.enabled = true;

            if (condottoChiuso == false)
            {
                strisciaWitheredCarmine.Play();

                StartCoroutine(PlayVideo());
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
                classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = false;
                if(classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[0] == true || (classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[1] == true && classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineCorridoioE.enabled == false && classicCarmine.GetComponent<AIClassicCarmine>().casual != 1))
                {
                    classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineSalone.enabled = true;
                }
                imageWitheredCarmineSalone.enabled = false;
                imageWitheredCarmineSalone2.enabled = false;
                imageWitheredCarmineCucina.enabled = false;

                arrayRoom[3] = false;
                arrayRoom[4] = true;

                witheredCondotto = true;

                stato = false;
                StopCoroutine(PlayVideo());
            }
            else
            {
                walkWitheredCarmine.Play();

                StartCoroutine(PlayVideo());
                witheredCondotto = false;
                
                if(classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[0] == true && classicCarmine.GetComponent<AIClassicCarmine>().num_IA > 0)
                {
                    if (classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineSalone.enabled == true)
                    {
                        classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineSalone.enabled = false;
                        CaseWitheredCarmineClassicCarmine2();
                    }
                }
                else
                {
                    imageWitheredCarmineCucina.enabled = false;
                    imageWitheredCarmineSalone2.enabled = true;
                    classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
                    classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = false;
                    imageWitheredCarmineSalone.enabled = false;

                    arrayRoom[0] = true;
                    arrayRoom[3] = false;
                }

                stato = true;
                WhiteredCarmineMovement();
                StopCoroutine(PlayVideo());
            }

        }
        if (arrayRoom[4] ==true && stato == true)
        {
            strisciaWitheredCarmine.Play();

            if (condottoChiuso == false)
            {
                arrayRoom[4] = false;
                arrayRoom[5] = true;

                witheredCondotto = true;
            }
            else
            {
                video.enabled = true;
                StartCoroutine(PlayVideo());

                witheredCondotto = false;

                imageWitheredCarmineCucina.enabled = true;

                arrayRoom[1] = true;
                arrayRoom[4] = false;

                StopCoroutine(PlayVideo());

            }
                stato = false;
        }
        if(arrayRoom[5] == true && stato == true)
        {
            strisciaWitheredCarmine.Play();

            arrayRoom[5] = false;
            arrayRoom[6] = true;

            stato = false;
        }
        if(arrayRoom[6] == true && stato == true)
        {
            talkWitheredCarmine.Play();
            if (puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA > 0  && puppetCarmine.GetComponent<AIPuppetCarmine>().attacco == true)
            {
                puppetCarmine.GetComponent<AIPuppetCarmine>().RiavviaComputer();
            }

            JumpscareWitheredCarmine();
        }

        stato = true;

        Invoke("changeMove", 10f);

    }

    public void JumpscareWitheredCarmine()
    {
        talkWitheredCarmine.Stop();
        videoJumpscare.enabled = true;
        StartCoroutine(PlayJumpscare());
        video.enabled = true;

        cameras.GetComponent<CameraManager>().CamDown();
        cameras.GetComponent<CameraManager>().CamOff();

        StopCoroutine(PlayJumpscare());
    }

    public void chiudiCondotto()
    {
        condottoChiuso = !condottoChiuso;
        Debug.Log(condottoChiuso);
    }

    public void CaseWitheredCarmineClassicCarmine2()
    {
        imageWitheredCarmineCucina.enabled = false;

        classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine.enabled = false;
        classicCarmine.GetComponent<AIClassicCarmine>().imageClassicCarmineWhiteredCarmine2.enabled = true;
        imageWitheredCarmineSalone.enabled = false;
        imageWitheredCarmineSalone2.enabled = false;
        imageWitheredCarmineCucina.enabled = false;

        classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[0] = false;
        classicCarmine.GetComponent<AIClassicCarmine>().arrayRoom[1] = true;

        arrayRoom[1] = false;
        arrayRoom[2] = true;

        stato = false;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Rimuovi il video quando è finito
        video.enabled = false;
    }

    private void OnVideoEndJumpscare(VideoPlayer vp)
    {
        // Rimuovi il video quando è finito
        videoJumpscare.enabled = false;
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator PlayJumpscare()
    {
        jumpscare.Prepare();

        while (!jumpscare.isPrepared)
        {
            yield return null;
        }

        jumpscare.Play();
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
