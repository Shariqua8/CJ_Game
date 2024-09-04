using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumericInputFields : MonoBehaviour
{
    private TextMeshProUGUI num_IA;
    public string textMeshProObjectName = "ClassicCarmineNumberIA";

    public int currentValue = 0;

    private void Start()
    {
        GameObject objWithTMP = GameObject.Find(textMeshProObjectName);

        num_IA = objWithTMP.GetComponent<TextMeshProUGUI>();

        num_IA.text = "0";
    }

    public void IncreaseValue()
    {
        if (currentValue < 20)
        {
            currentValue++;
            num_IA.text = currentValue.ToString();
        }
    }

    public void DecreaseValue()
    {
        if (currentValue > 0)
        {
            currentValue--;
            num_IA.text = currentValue.ToString();
        }
    }
}
