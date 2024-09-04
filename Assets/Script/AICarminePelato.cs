using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AICarminePelato : MonoBehaviour
{
    public AudioSource gibberishmanager;
    public AudioClip[] gibberishs;

    public GameObject PlayerData;
    public GameObject cameras;

    public RawImage rawVideoCarminePelato;
    public VideoPlayer videoCarminePelato;

    public SpriteRenderer imageCarminePelatoUfficio;
    public SpriteRenderer imageUfficio;


    // Start is called before the first frame update
    void Start()
    {
        imageCarminePelatoUfficio.enabled = false;
        rawVideoCarminePelato.enabled = false;

        //SOLO PER CARMINE PELATO//
        // Assegna il target texture del VideoPlayer alla RawImage
        rawVideoCarminePelato.texture = videoCarminePelato.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        videoCarminePelato.loopPointReached += OnVideoEnd;

        Invoke("WaitNumCasualCarminePelato", 3f);
    }

    [System.Obsolete]
    void WaitNumCasualCarminePelato()
    {

        if (PlayerData.gameObject.GetComponent<PlayerNightData>().LevelNight == 5 || PlayerData.gameObject.GetComponent<PlayerNightData>().LevelNight == 6)
        {
            int num = Random.RandomRange(0, 730); 
            int casualGibberish = Random.RandomRange(0, 4);

            num += 1;   //Per via dei numeri dispari incrementiamo di 1
            Debug.Log("Numero Casuale Carmine Pelato: " + num);

            if (num == 666 || num == 710 || num == 111 || num == 5 || num == 1 || num == 11 || num == 6 || num == 13 || num == 17 || num == 191 || num == 39 || num == 9)
            {
                imageUfficio.enabled = false;
                imageCarminePelatoUfficio.enabled = true;

                if (casualGibberish == 1)
                    gibberishmanager.PlayOneShot(gibberishs[0]);
                else if (casualGibberish == 2)
                    gibberishmanager.PlayOneShot(gibberishs[1]);
                else
                    gibberishmanager.PlayOneShot(gibberishs[2]);

                cameras.gameObject.GetComponent<CameraManager>().CamDown();
                cameras.gameObject.GetComponent<CameraManager>().CamOff();

                Invoke("Jumpscare", 2f);

            }
        }
    }

    void Jumpscare()
    {
        videoCarminePelato.enabled = true;
        StartCoroutine(PlayVideo());
        rawVideoCarminePelato.enabled = true;


        StopCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoCarminePelato.Prepare();

        while (!videoCarminePelato.isPrepared)
        {
            yield return null;
        }

        videoCarminePelato.Play();
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        // Rimuovi il video quando è finito
        videoCarminePelato.enabled = false;

        // Esci dall'applicazione
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
