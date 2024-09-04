using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatoShock : MonoBehaviour
{
    private TextMeshProUGUI shockText;

    public GameObject moltenCarmine;
    public GameObject cameras;

    // Start is called before the first frame update
    void Start()
    {
        shockText = GetComponent<TextMeshProUGUI>();

        shockText.fontStyle = FontStyles.Bold;
        shockText.color = Color.yellow;
        shockText.text = "Scosse: " + "0/" + moltenCarmine.GetComponent<AIMoltenCarmine>().limite.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(cameras.GetComponent<CameraManager>().IsCamera7())
        {
            shockText.fontStyle = FontStyles.Bold;
            shockText.text = "Scosse: " + moltenCarmine.GetComponent<AIMoltenCarmine>().i_scossa.ToString() + "/" + moltenCarmine.GetComponent<AIMoltenCarmine>().limite.ToString();
        }
    }
}
