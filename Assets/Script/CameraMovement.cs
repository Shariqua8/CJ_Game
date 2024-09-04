using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float cameraSpeed = 15f;
    public float borderSize = 30f;
    private float minX; // Posizione X minima consentita
    private float maxX; // Posizione X massima consentita

    // Start is called before the first frame update
    void Start()
    {

        minX = -4.5f;
        maxX = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorScreenPosition = Input.mousePosition;
        Vector3 nextPosition = transform.position;

        if (cursorScreenPosition.x < borderSize && transform.position.x > minX)
        {
            nextPosition += Vector3.left * cameraSpeed * Time.deltaTime;
        }
        else if (cursorScreenPosition.x > Screen.width - borderSize && transform.position.x < maxX)
        {
            nextPosition += Vector3.right * cameraSpeed * Time.deltaTime;
        }

        // Aggiorna la posizione della telecamera se il prossimo movimento è consentito
        if (nextPosition != transform.position)
        {
            transform.position = nextPosition;
        }
    }
}
