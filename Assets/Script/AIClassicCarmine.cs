using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIClassicCarmine : MonoBehaviour
{
    public VideoClip videoJumpscareUfficio;
    public AudioSource doorClose;
    public AudioClip doorcloseclip;

    public int casual;

    public AudioSource walkClassicCarmine;
    public AudioSource waterClassicCarmine;
    public AudioSource talkClassicCarmine;
    public AudioSource walkreverseClassicCarmine;

    public Animator animateDoorDown;
    public Animator animateDoorUp;

    public VideoPlayer statico;
    public RawImage video;

    public VideoPlayer jumpscare;
    public RawImage videoJumpscare;

    public GameObject cameras;
    public GameObject puppetCarmine;

    public SpriteRenderer imageClassicCarmineIngresso;
    public SpriteRenderer imageClassicCarmineSalone;
    public SpriteRenderer imageClassicCarmineCorridoioE;
    public SpriteRenderer imageClassicCarmineCorridoioI2;
    public SpriteRenderer imageClassicCarmineCorridoioI;

    public SpriteRenderer imageBottoneAperto;
    public SpriteRenderer imageBottoneChiuso;

    public SpriteRenderer imageClassicCarmineWhiteredCarmine;
    public SpriteRenderer imageClassicCarmineWhiteredCarmine2;

    public int num_IA = 0;

    //Inizialmente il Classic Carmine parte dall'ingresso e segniamo quindi il suo stato
    public bool[] arrayRoom = {true, false, false, false, false, false, false};

    public bool stato = false;
    bool flag = false;

    public bool portaChiusa = false;

    public GameObject whiteredCarmine;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        jumpscare.clip = videoJumpscareUfficio;

        animateDoorUp.gameObject.SetActive(true);
        animateDoorUp.enabled = false;

        animateDoorDown.gameObject.SetActive(false);
        animateDoorDown.enabled = false;

        imageClassicCarmineIngresso.enabled = true;
        imageClassicCarmineSalone.enabled = false;
        imageClassicCarmineCorridoioI2.enabled = false;
        imageClassicCarmineCorridoioE.enabled = false;
        imageClassicCarmineCorridoioI.enabled = false;
        imageClassicCarmineWhiteredCarmine.enabled = false;
        imageClassicCarmineWhiteredCarmine2.enabled = false;
        imageBottoneAperto.enabled = true;
        imageBottoneChiuso.enabled = false;

        arrayRoom[0] = true;

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

        imageClassicCarmineWhiteredCarmine.enabled = false;
        imageClassicCarmineWhiteredCarmine2.enabled = false;

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
        int num_casual;
        num_casual = Random.RandomRange(1, 20);
        
        Debug.Log(num_IA + " Numero IA  " + num_casual + " num casual");

        if(num_IA != 0)
        {
            if(num_casual <= num_IA)
            {
                
                Invoke("CarmineMovement", 11f);
            }
            else
            {
                Invoke("changeMove", 8f);
            }
        }
        else
        {
            Invoke("changeMove", 8f);
        }

    }


    [System.Obsolete]
    void CarmineMovement()
    {
        
        if (flag == true)
        {
            arrayRoom[0] = true;
            flag = false;
            
        }
            
        if (arrayRoom[0] == true)
        {
            walkClassicCarmine.Play();
            video.enabled = true;
            StartCoroutine(PlayVideo());

            flag = false;

            imageClassicCarmineCorridoioI.enabled = false;
            imageClassicCarmineCorridoioE.enabled = false;
            imageClassicCarmineIngresso.enabled = false;
            imageClassicCarmineSalone.enabled = false;
            imageClassicCarmineWhiteredCarmine.enabled = false;
            imageClassicCarmineWhiteredCarmine2.enabled = false;
            imageClassicCarmineSalone.enabled = true;

            if(whiteredCarmine.GetComponent<AIWitheredCarmine>().arrayRoom[0] == true && whiteredCarmine.GetComponent<AIWitheredCarmine>().num_IAW > 0)
            {
                CaseWitheredCarmineClassicCarmine();       
            }
            else if(whiteredCarmine.GetComponent<AIWitheredCarmine>().arrayRoom[1] == true && whiteredCarmine.GetComponent<AIWitheredCarmine>().num_IAW > 0)
            {
                whiteredCarmine.GetComponent<AIWitheredCarmine>().CaseWitheredCarmineClassicCarmine2();
            }
            else if(whiteredCarmine.GetComponent<AIWitheredCarmine>().arrayRoom[2] == true && whiteredCarmine.GetComponent<AIWitheredCarmine>().num_IAW > 0)
            {
                whiteredCarmine.GetComponent<AIWitheredCarmine>().imageWitheredCarmineSalone2.enabled = false;
                whiteredCarmine.GetComponent<AIWitheredCarmine>().CaseWitheredCarmineClassicCarmine2();

            }
            else
            {
                if (whiteredCarmine.GetComponent<AIWitheredCarmine>().num_IAW == 0)
                {
                    CaseWitheredCarmineClassicCarmineWithIA0();
                }
                else
                {
                    imageClassicCarmineCorridoioI.enabled = false;
                    imageClassicCarmineCorridoioE.enabled = false;
                    imageClassicCarmineIngresso.enabled = false;
                    imageClassicCarmineWhiteredCarmine.enabled = false;
                    imageClassicCarmineWhiteredCarmine2.enabled = false;
                    imageClassicCarmineSalone.enabled = true;

                    arrayRoom[0] = false;
                    arrayRoom[1] = true;
                }

            }

            StopCoroutine(PlayVideo());
            
            stato = false ;       
        }
        if (arrayRoom[1] == true && stato == true)
        {
            casual = Random.RandomRange(0,2);

            Debug.Log(casual + " Numero Casuale per andare in bagno");

            walkClassicCarmine.Play();

            video.enabled = true;
            StartCoroutine(PlayVideo());

            if (whiteredCarmine.GetComponent<AIWitheredCarmine>().arrayRoom[2])
            {
                whiteredCarmine.GetComponent<AIWitheredCarmine>().imageWitheredCarmineSalone2.enabled = true;
            }
            imageClassicCarmineCorridoioI.enabled = false;
            imageClassicCarmineIngresso.enabled = false;
            imageClassicCarmineSalone.enabled = false;
            imageClassicCarmineWhiteredCarmine.enabled = false;
            imageClassicCarmineWhiteredCarmine2.enabled = false;
            imageClassicCarmineCorridoioE.enabled = true;

            if(casual == 1)
            {

                imageClassicCarmineCorridoioE.enabled = false;

                waterClassicCarmine.Play();

                arrayRoom[5] = true;
                arrayRoom[1] = false;   
            }
            else
            {
                arrayRoom[1] = false;
                arrayRoom[2] = true;
            }

            stato = false;
            StopCoroutine(PlayVideo()); 
        }
        if (arrayRoom[2] == true && stato == true)
        {
            imageClassicCarmineCorridoioI2.enabled = false;

            imageClassicCarmineCorridoioI.enabled = false;

            walkClassicCarmine.Play();
            StartCoroutine(PlayVideo());
            video.enabled = true;

            imageClassicCarmineIngresso.enabled = false;
            imageClassicCarmineSalone.enabled = false;
            imageClassicCarmineWhiteredCarmine.enabled = false;
            imageClassicCarmineWhiteredCarmine2.enabled = false;
            imageClassicCarmineCorridoioE.enabled = false;
            imageClassicCarmineCorridoioI.enabled = true;

            arrayRoom[2] = false;
            arrayRoom[3] = true;

            stato = false;
            StopCoroutine(PlayVideo());

            
        }
        if (arrayRoom[3] == true && stato == true)
        {
            walkClassicCarmine.Play();
            StartCoroutine(PlayVideo());
            video.enabled = true;

            imageClassicCarmineCorridoioE.enabled = false;
            imageClassicCarmineIngresso.enabled = false;
            imageClassicCarmineSalone.enabled = false;
            imageClassicCarmineWhiteredCarmine.enabled = false;
            imageClassicCarmineWhiteredCarmine2.enabled = false;
            imageClassicCarmineCorridoioI.enabled = false;
            imageClassicCarmineCorridoioI2.enabled = true;

            arrayRoom[3] = false;
            arrayRoom[4] = true;

            stato = false;
            
            StopCoroutine(PlayVideo());
            
        }
        if (arrayRoom[4] == true && stato == true)
        {
            walkClassicCarmine.Play();
            int num_c1 = 0;

            imageClassicCarmineCorridoioI2.enabled = true;

            video.enabled = true;
            StartCoroutine(PlayVideo());

            //ci sta una variazione, qui il CarmineAnimatronico lancia tre volte una moneta, a seconda di cosa gli esce o avanza verso la camera del puppet o verso l'ufficio

            if (portaChiusa == false)
            {
                if (puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA > 0 && puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[1] == true && puppetCarmine.GetComponent<AIPuppetCarmine>().attacco == true)
                {
                    puppetCarmine.GetComponent<AIPuppetCarmine>().RiavviaComputer();
                }
                walkClassicCarmine.Stop();
                arrayRoom[4] = false;
                arrayRoom[5] = true;

                imageClassicCarmineCorridoioI.enabled = false;
                imageClassicCarmineCorridoioE.enabled = false;
                imageClassicCarmineIngresso.enabled = false;
                imageClassicCarmineSalone.enabled = false;
                imageClassicCarmineWhiteredCarmine.enabled = false;
                imageClassicCarmineWhiteredCarmine2.enabled = false;
                imageClassicCarmineCorridoioI2.enabled = false;

                stato = false;
                talkClassicCarmine.Play();
                cameras.GetComponent<CameraManager>().CamDown();
                cameras.GetComponent<CameraManager>().CamOff();
                Invoke("JumpscareClassicCarmine", 0.5f);
            }
            else
            {
                num_c1 = Random.RandomRange(0, 3);

                if (num_c1 == 0)
                {
                    walkreverseClassicCarmine.Play();

                    imageClassicCarmineCorridoioI.enabled = false;
                    imageClassicCarmineCorridoioE.enabled = false;
                    imageClassicCarmineIngresso.enabled = false;
                    imageClassicCarmineSalone.enabled = false;
                    imageClassicCarmineWhiteredCarmine.enabled = false;
                    imageClassicCarmineWhiteredCarmine2.enabled = false;
                    imageClassicCarmineCorridoioI2.enabled = true;

                    arrayRoom[4] = false;
                    arrayRoom[3] = true;

                    stato = false;
                }
                else if (num_c1 == 1)
                {
                    walkreverseClassicCarmine.Play();

                    imageClassicCarmineCorridoioI.enabled = false;
                    imageClassicCarmineCorridoioE.enabled = false;
                    imageClassicCarmineIngresso.enabled = false;
                    imageClassicCarmineSalone.enabled = false;
                    imageClassicCarmineWhiteredCarmine.enabled = false;
                    imageClassicCarmineWhiteredCarmine2.enabled = false;
                    imageClassicCarmineCorridoioI2.enabled = false;

                    arrayRoom[4] = false;
                    arrayRoom[0] = true;

                    stato = true;

                    CarmineMovement();
                }
                else
                {
                    walkreverseClassicCarmine.Play();

                    imageClassicCarmineCorridoioI.enabled = false;
                    imageClassicCarmineIngresso.enabled = false;
                    imageClassicCarmineSalone.enabled = false;
                    imageClassicCarmineWhiteredCarmine.enabled = false;
                    imageClassicCarmineWhiteredCarmine2.enabled = false;
                    imageClassicCarmineCorridoioI2.enabled = false;
                    imageClassicCarmineCorridoioE.enabled = true;

                    arrayRoom[4] = false;
                    arrayRoom[2] = true;
                }
            }
            stato = false;
            StopCoroutine(PlayVideo());
            

        }
        if(arrayRoom[5] == true && stato == true)
        {
            //walkClassicCarmine.Play();

            arrayRoom[5] = false;
            arrayRoom[2] = true;

            imageClassicCarmineCorridoioE.enabled = false;
            imageClassicCarmineIngresso.enabled = false;
            imageClassicCarmineSalone.enabled = false;
            imageClassicCarmineWhiteredCarmine.enabled = false;
            imageClassicCarmineWhiteredCarmine2.enabled = false;
            imageClassicCarmineCorridoioI.enabled = false;

            stato = false;
        }
        
        stato = true;
        Invoke("changeMove", 12f);
    }

    public void JumpscareClassicCarmine()
    {
        talkClassicCarmine.Stop();
        jumpscare.enabled = true;
        StartCoroutine(PlayJumpscare());
        videoJumpscare.enabled = true;


        StopCoroutine(PlayJumpscare());

    }

    public void chiudiPorta()
    {
        // Inverti lo stato della porta
        portaChiusa = !portaChiusa;

        // Avvia l'animazione corrispondente in base allo stato della porta
        if (portaChiusa)
        {
            doorClose.PlayOneShot(doorcloseclip);
            StartAnimationDoorDown();
        }
        else
        {

            doorClose.PlayOneShot(doorcloseclip);
            StartAnimationDoorUp();
        }

        animateDoorUp.enabled = false;
        animateDoorDown.enabled = false;
    }

    public void CaseWitheredCarmineClassicCarmine()
    {
        imageClassicCarmineIngresso.enabled = false;
        imageClassicCarmineWhiteredCarmine.enabled = true;
        
        whiteredCarmine.GetComponent<AIWitheredCarmine>().imageWitheredCarmineSalone.enabled = false;
        

        whiteredCarmine.GetComponent<AIWitheredCarmine>().arrayRoom[0] = false;
        whiteredCarmine.GetComponent<AIWitheredCarmine>().arrayRoom[1] = true;
    }

    void CaseWitheredCarmineClassicCarmineWithIA0()
    { 
        imageClassicCarmineIngresso.enabled = false;
        imageClassicCarmineWhiteredCarmine.enabled = true;
        
        arrayRoom[0] = false;
        arrayRoom[1] = true;

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

    public void StartAnimationDoorDown()
    {
        animateDoorDown.enabled = true;

        animateDoorDown.gameObject.SetActive(true);
        animateDoorUp.gameObject.SetActive(false);

        imageBottoneAperto.enabled = false;
        imageBottoneChiuso.enabled = true;
    }
    public void StartAnimationDoorUp()
    {
        animateDoorUp.enabled = true;

        animateDoorDown.gameObject.SetActive(false);
        animateDoorUp.gameObject.SetActive(true);

        imageBottoneAperto.enabled = true;
        imageBottoneChiuso.enabled = false;
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

    public void setNum_IA(int val)
    {
        num_IA = val;
    }
}
