using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class AIMoltenCarmine : MonoBehaviour
{
    public AudioSource audioElectricSound;
    public AudioSource audio1;
    public AudioSource audio2;

    public VideoPlayer statico;
    public RawImage video;

    public SpriteRenderer imageMoltenCarmineGarageIdle;
    public SpriteRenderer imageMoltenCarmineGarageFase1;
    public SpriteRenderer imageMoltenCarmineGarageFase2;
    public SpriteRenderer imageMoltenCarmineGarageFase3;
    public SpriteRenderer imageUfficio;
    public SpriteRenderer imageUfficioSpento;
    public SpriteRenderer PortaChiusa;
    public SpriteRenderer PortaAperta;

    public Image batterySlot;

    public int num_IA = 0;

    public GameObject cameras;
    public GameObject batterys;
    public GameObject phantomCarmines;
    public GameObject puppetCarmine;
    public GameObject classicCarmine;
    public GameObject witheredCarmine;

    public Collider2D colliderpulsante;

    public GameObject pulsanteChiudiPorta;
    public GameObject pulsanteApriPorta;

    public bool[] arrayFase = { true, false, false, false};

    bool stato = false;
    public bool flagPuppet = false;
    public bool scossa = false;

    public int i_scossa = 0;

    public int limite;


    [System.Obsolete]
    // Start is called before the first frame update
    void Start()
    {
        limite = Random.RandomRange(3, 7);

        imageMoltenCarmineGarageIdle.enabled = true;
        imageMoltenCarmineGarageFase1.enabled = false;
        imageMoltenCarmineGarageFase2.enabled = false;
        imageMoltenCarmineGarageFase3.enabled = false;
        imageUfficio.enabled = true;
        imageUfficioSpento.enabled = false;


        statico.GetComponent<VideoPlayer>();

        //SOLO PER STATICO//
        // Assegna il target texture del VideoPlayer alla RawImage
        video.texture = statico.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        statico.loopPointReached += OnVideoEnd;

        video.enabled = false;

        changeMove();
    }

    [System.Obsolete]
    // Update is called once per frame
    void Update()
    {
        if(i_scossa == limite)
        {
            updatePuppetCarmineScossa();
            
            if(puppetCarmine.GetComponent<AIPuppetCarmine>().attacco == false || puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA == 0)
            {
                flagPuppet = true;
                azzeraRiavvio();
                flagPuppet = false;
            }
            
        }
        else
        {
            if(puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA > 0)
            {
                updatePuppetCarmineScossa();
            }
            
        }
    }

    [System.Obsolete]
    void changeMove()
    {
        int num_casual = 0;
        num_casual = Random.RandomRange(1, 20);

        if(num_IA != 0)
        {
            Debug.Log(num_casual);
            if (num_casual <= num_IA)
            {
                Invoke("MoltenCarmineFase", 24f);
            }
            else
            {
                Invoke("changeMove", 13f);
            }
        }
        else
        {
            Invoke("changeMove", 13f);
        }      
    }

    [System.Obsolete]
    void MoltenCarmineFase()
    {
        if(arrayFase[0] == true)
        {
            audio1.Play();
            StartCoroutine(PlayVideo());

            video.enabled = true;

            imageMoltenCarmineGarageIdle.enabled = false;
            imageMoltenCarmineGarageFase1.enabled = true;

            arrayFase[0] = false;
            arrayFase[1] = true;
                
            stato = false;

            StopCoroutine(PlayVideo());
        }
        if(arrayFase[1] == true && stato == true)
        {
            audio1.Play();
            StartCoroutine(PlayVideo());

            video.enabled = true;

            imageMoltenCarmineGarageFase1.enabled = false;
            imageMoltenCarmineGarageFase2.enabled = true;

            arrayFase[1] = false;
            arrayFase[2] = true;

            stato = false;

            StopCoroutine(PlayVideo());
        }
        if(arrayFase[2] == true && stato == true)
        {
            audio2.Play();
            StartCoroutine(PlayVideo());

            video.enabled = true;

            imageMoltenCarmineGarageFase2.enabled = false;
            imageMoltenCarmineGarageFase3.enabled = true;

            arrayFase[2] = false;
            arrayFase[3] = true;

            stato = false;

            StopCoroutine(PlayVideo());
        }
        if(arrayFase[3] == true && stato == true)
        {
            StartCoroutine(PlayVideo());

            video.enabled = true;

            imageMoltenCarmineGarageIdle.enabled = true;
            imageUfficio.enabled = false;
            imageUfficioSpento.enabled = true;

            PortaAperta.gameObject.SetActive(false);
            PortaChiusa.gameObject.SetActive(false);

            PortaAperta.enabled = false;
            PortaChiusa.enabled = false;

            classicCarmine.GetComponent<AIClassicCarmine>().portaChiusa = false;

            witheredCarmine.GetComponent<AIWitheredCarmine>().condottoChiuso = false;

            cameras.GetComponent<CameraManager>().CamDown();
            cameras.GetComponent<CameraManager>().CamOff();

            batterys.GetComponent<Battery>().battery = 0;

            batterySlot.GetComponent<Image>().gameObject.SetActive(false);

            pulsanteChiudiPorta.gameObject.SetActive(false);
            pulsanteApriPorta.gameObject.SetActive(true);
            colliderpulsante.gameObject.SetActive(false);

            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 0;
            puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[0] = false;
            puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[1] = false;
            puppetCarmine.GetComponent<AIPuppetCarmine>().arrayFase[2] = false;

            phantomCarmines.GetComponent<AINightmareCarmine>().num_IA = 0;

            arrayFase[3] = false;
            StopCoroutine(PlayVideo());

            batterys.GetComponent<Battery>().levelBattery();
            
        }
        stato = true;

        Invoke("changeMove", 13f);

    }

    void updatePuppetCarmineScossa()
    {
        if (arrayFase[0] == true)
        {
            audio1.Play();

            if (scossa == true)
            {
                StartCoroutine(PlayVideo());

                video.enabled = true;
                imageMoltenCarmineGarageIdle.enabled = true;

                arrayFase[0] = true;

                stato = false;
                StopCoroutine(PlayVideo());
            }

        }

        if (arrayFase[1] == true && stato == true)
        {
            audio1.Play();

            if (scossa == true)
            {
                StartCoroutine(PlayVideo());

                video.enabled = true;
                imageMoltenCarmineGarageFase1.enabled = false;
                imageMoltenCarmineGarageIdle.enabled = true;

                arrayFase[0] = true;
                arrayFase[1] = false;

                stato = false;

                scossa = false;

                StopCoroutine(PlayVideo());
            }

        }

        if (arrayFase[2] == true && stato == true)
        {
            audio2.Play();

            if (scossa == true)
            {
                StartCoroutine(PlayVideo());

                video.enabled = true;
                imageMoltenCarmineGarageFase2.enabled = false;
                imageMoltenCarmineGarageIdle.enabled = true;

                arrayFase[0] = true;
                arrayFase[2] = false;

                stato = false;

                scossa = false;

                StopCoroutine(PlayVideo());
            }

        }

        if (arrayFase[3] == true && stato == true)
        {
            audio2.Play();

            if (scossa == true)
            {
                StartCoroutine(PlayVideo());

                video.enabled = true;
                i_scossa = limite - 1;

                imageMoltenCarmineGarageFase3.enabled = false;
                imageMoltenCarmineGarageIdle.enabled = true;

                arrayFase[0] = true;
                arrayFase[3] = false;

                stato = false;

                scossa = false;
                StopCoroutine(PlayVideo());
            }

        }
    }

    void azzeraRiavvio()
    {
        flagPuppet = true;
        cameras.GetComponent<CameraManager>().CamDown();
        cameras.GetComponent<CameraManager>().CamUpRiavvio();
        cameras.GetComponent<CameraManager>().CamOff();
        i_scossa = 0;
        scossa = false;
        
    }

    public void Scossa()
    {
        audioElectricSound.Play();
        scossa = !scossa;

        if (scossa == true)
        {
            updatePuppetCarmineScossa();
            scossa = false;
            i_scossa++;
        }

        Debug.Log(scossa);
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
