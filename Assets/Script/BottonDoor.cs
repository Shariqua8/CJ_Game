using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BottonDoor :  MonoBehaviour, IPointerClickHandler
{
    public GameObject classicCarmine;
    public Collider2D bottoneAperto;

    // Start is called before the first frame update
    void Start()
    {
        bottoneAperto = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        classicCarmine.GetComponent<AIClassicCarmine>().chiudiPorta();
    }
}
