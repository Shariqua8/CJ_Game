using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DetectionButtonMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Collider2D bottone;
    private TextMeshProUGUI textMeshPro;
    private AudioSource audioSource;
    public string audioSourceoObjectName = "AudioSource";
    public string textMeshProObjectName = "TestoFreccette"; 


    // Start is called before the first frame update
    void Start()
    {
        // Trova l'oggetto con il nome specificato
        GameObject objWithTMP = GameObject.Find(textMeshProObjectName);

        // Trova l'oggetto con il nome specificato 
        GameObject objWithAudio = GameObject.Find(audioSourceoObjectName);

        // Ottieni il riferimento al componente TextMeshProUGUI
        textMeshPro = objWithTMP.GetComponent<TextMeshProUGUI>();

        // Ottieni il riferimento al componente TextMeshProUGUI
        audioSource = objWithAudio.GetComponent<AudioSource>();

        // Ottieni il riferimento del Collider2D
        bottone = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }  

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Imposta il testo
        textMeshPro.text = ">>";

        // Avvia l'audio
        audioSource.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        textMeshPro.text = "";
    }
}
