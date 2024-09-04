using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerNightData : MonoBehaviour
{
    string PATH = @".\Files\Night.txt";
    string PATH_UNLOCKABLE = @".\Files\Unlockable.txt";
    public int LevelNight;
    public int Unlockable;

    private void Start()
    {
        if (!File.Exists(PATH)){
            StreamWriter f = new StreamWriter(PATH);
            f.Write(1);
            f.Close();
        }
        else
        {
            ReadFile();
        }

        if (!File.Exists(PATH_UNLOCKABLE))
        {
            StreamWriter f = new StreamWriter(PATH_UNLOCKABLE);
            f.Write(0);
            f.Close();
        }
        else
        {
            ReadFileUnlockable();
        }

        if (LevelNight == 6 && Unlockable == 0)
        {
            Debug.Log(Unlockable);
            ReadFileUnlockable();
            Unlock();
            WriteFileUnlockable();
        }
        else if (LevelNight == 7 && Unlockable == 1)
        {
            ReadFileUnlockable();
            Unlock();
            WriteFileUnlockable();
        }
    }

    private void Update()
    {

    }

    public void CreateFile()
    {
        StreamWriter f = new StreamWriter(PATH);
        f.Write(1);
        f.Close();
    }

    public void CreateFileUnlockable()
    {
        StreamWriter f = new StreamWriter(PATH_UNLOCKABLE);
        f.Write(0);
        f.Close();
    }

    public void ReadFileUnlockable()
    {
        StreamReader r = new StreamReader(PATH_UNLOCKABLE);
        try
        {
            Unlockable = int.Parse(r.ReadLine());
        }
        catch (FileNotFoundException)
        {
            CreateFileUnlockable();
        }
        catch (IOException)
        {
            Debug.Log("Errore nell'apertura del file "+PATH_UNLOCKABLE);
        }
        r.Close();
    }
    public void WriteFileUnlockable()
    {
        StreamWriter f = new StreamWriter(PATH_UNLOCKABLE);
        try
        {
            f.Write(Unlockable);
        }
        catch (FileNotFoundException)
        {
            CreateFileUnlockable();
        }
        catch (IOException)
        {
            Debug.Log("Errore nell'apertura del file "+PATH_UNLOCKABLE);
        }
        f.Close();
    }
    
    public void ReadFile()
    {
        StreamReader r = new StreamReader(PATH);
        try
        {
            LevelNight = int.Parse(r.ReadLine());   
        }
        catch (FileNotFoundException)
        {
            CreateFile();
        }
        catch (IOException)
        {
            Debug.Log("Errore nell'apertura del file "+PATH);
        }
        r.Close();
    }
    public void WriteFile()
    {
        StreamWriter f = new StreamWriter(PATH);
        try
        {
            f.Write(LevelNight);
        }
        catch (FileNotFoundException)
        {
            CreateFile();
        }
        catch (IOException)
        {
            Debug.Log("Errore nell'apertura del file "+PATH);
        }
        f.Close();
    }


    public void NightChange()
    {
        if(LevelNight < 8)
        {
            LevelNight++;
        }
        else
        {
            LevelNight = 1;
        }
    }

    public void Unlock()
    {
        if (Unlockable < 3)
        {
            Unlockable++;
        }
    }
}
