using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetValueNightCustom : MonoBehaviour
{
    string PATH = @".\Files\CustomNight.txt";

    public int classicCarmineIAVal = 0;
    public int witheredCarmineIAVal = 0;
    public int puppetCarmineIAVal = 0;
    public int moltenCarmineIAVal = 0;
    public int phantomCarmineIAVal = 0;

    public void getValue()
    {
        StreamReader r = new StreamReader(PATH);

        try
        {
            classicCarmineIAVal = int.Parse(r.ReadLine());
            witheredCarmineIAVal = int.Parse(r.ReadLine());
            puppetCarmineIAVal = int.Parse(r.ReadLine());
            moltenCarmineIAVal = int.Parse(r.ReadLine());
            phantomCarmineIAVal = int.Parse(r.ReadLine());
        }
        catch (FileNotFoundException)
        {
            Debug.Log("Errore, il file non è stato trovato / non esiste. PATH = " + PATH);
        }
        catch (IOException)
        {
            Debug.Log("Errore nell'apertura del file " + PATH);
        }
    }
}
