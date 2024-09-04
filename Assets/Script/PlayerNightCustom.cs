using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerNightCustom : MonoBehaviour
{
    public GameObject classicCarmineIA;
    public GameObject witheredCarmineIA;
    public GameObject puppetCarmineIA;
    public GameObject moltenCarmineIA;
    public GameObject phantomCarmineIA;

    public GameObject figureClassicCarmine;
    public GameObject figureWitheredCarmine;
    public GameObject figurePuppetCarmine;
    public GameObject figureMoltenCarmine;
    public GameObject figurePhantomCarmine;

    public Button ready;
    public Button goback;

    public RawImage rawVideoCarminePelato;
    public VideoPlayer videoCarminePelato;
    bool flag = false;

    string PATH = @".\Files\CustomNight.txt";

    public void Start()
    {
        rawVideoCarminePelato.enabled = false;

        //SOLO PER CARMINE PELATO//
        // Assegna il target texture del VideoPlayer alla RawImage
        rawVideoCarminePelato.texture = videoCarminePelato.targetTexture;

        // Aggiungi un listener per l'evento loopPointReached
        videoCarminePelato.loopPointReached += OnVideoEnd;
    }

    public void CreateFile()
    {
        if(classicCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue == 6 && witheredCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue == 1 && puppetCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue == 0 && moltenCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue == 2 && phantomCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue == 3)
        {
            figureClassicCarmine.gameObject.SetActive(false);
            figureMoltenCarmine.gameObject.SetActive(false);
            figurePhantomCarmine.gameObject.SetActive(false);
            figurePuppetCarmine.gameObject.SetActive(false);
            figureWitheredCarmine.gameObject.SetActive(false);

            ready.gameObject.SetActive(false);
            goback.gameObject.SetActive(false);

            StartCoroutine(PlayVideo());

            rawVideoCarminePelato.enabled = true;

            StopCoroutine(PlayVideo());
        }
        else
        {
            StreamWriter f = new StreamWriter(PATH);
            try
            {
                f.Write(classicCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue.ToString() + "\n");
                f.Write(witheredCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue.ToString() + "\n");
                f.Write(puppetCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue.ToString() + "\n");
                f.Write(moltenCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue.ToString() + "\n");
                f.Write(phantomCarmineIA.gameObject.GetComponent<NumericInputFields>().currentValue.ToString() + "\n");

                flag = true;

            }
            catch (IOException)
            {
                flag = false;
                Debug.Log("Non riesco a creare il file!");
            }
            f.Close();

            if (flag)
            {
                SceneManager.LoadScene("12AM");
            }
        }
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
