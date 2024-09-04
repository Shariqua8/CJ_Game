using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class TimerManager : MonoBehaviour
{
    private TextMeshProUGUI clockText;
    private DateTime customDate = new DateTime(2022, 1, 1, 0, 0, 0);

    public GameObject classicCarmine;
    public GameObject witheredCarmine;
    public GameObject puppetCarmine;
    public GameObject moltenCarmine;
    public GameObject phantomCarmine;

    public GameObject dataPlayer;
    
    public int[] arrayIA = new int[5];

    public AudioSource nottemanager;
    public AudioClip[] notteArray;

    public AudioSource ambiencemanager;
    public AudioClip[] ambienceArray;

    public AudioSource inizializatePhone;

    string PATH = @".\Files\CustomNight.txt";

    public Button pulsante;

    private bool stato = false;
    
    private void Start()
    {
        nottemanager = GetComponent<AudioSource>();
        clockText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //Verifica se l'audio delle notti è ancora attivo, il punto esclamativo simboleggia il not, infatti quando l'audio è ancora in esecuzione restituirà not altrimenti false.
        if (!nottemanager.isPlaying && stato && dataPlayer.GetComponent<PlayerNightData>().LevelNight !=6)
        {
            pulsante.gameObject.SetActive(false);
        }

        //Cambia la notte o richiama le funzioni per cambiare le IA degli animatronici
        Change();

        // Aggiorna la data in base al tempo trascorso
        float deltaTime = Time.deltaTime; // Tempo trascorso dall'ultimo frame

        // Aggiorna la data in base al tempo trascorso
        customDate = customDate.AddMinutes(deltaTime);

        // Imposta il formato dell'ora desiderato
        string formattedTime = customDate.ToString("hh tt");

        // Aggiorna il testo dell'orologio
        clockText.text = formattedTime;

        //Si chiede se sono le sei di mattina e se è vero allora vinci il gioco
        isSixAM();

    }

    private void isSixAM()
    {
        if(customDate.Hour == 6)
        {
            ambiencemanager.Stop();
            stato = false;

            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 0;
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 0;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 0;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 0;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 0;

            if (dataPlayer.GetComponent<PlayerNightData>().LevelNight < 5)
            {
                dataPlayer.GetComponent<PlayerNightData>().ReadFile();
                dataPlayer.GetComponent<PlayerNightData>().NightChange();
                dataPlayer.GetComponent<PlayerNightData>().WriteFile();
            }
            else 
            {
                if (dataPlayer.GetComponent<PlayerNightData>().LevelNight == 5)
                {
                    //Cambia la notte, per la sesta notte
                    dataPlayer.GetComponent<PlayerNightData>().ReadFile();
                    dataPlayer.GetComponent<PlayerNightData>().NightChange();
                    dataPlayer.GetComponent<PlayerNightData>().WriteFile();

                    if(dataPlayer.GetComponent<PlayerNightData>().Unlockable == 0)
                    {
                        //Cambia gli Unlock, perchè abbiamo sbloccato la prima stella
                    
                        dataPlayer.GetComponent<PlayerNightData>().ReadFileUnlockable();
                        dataPlayer.GetComponent<PlayerNightData>().Unlock();
                        dataPlayer.GetComponent<PlayerNightData>().WriteFileUnlockable();
                    }
                }
                else if (dataPlayer.GetComponent<PlayerNightData>().LevelNight == 6)
                {
                    dataPlayer.GetComponent<PlayerNightData>().ReadFile();
                    dataPlayer.GetComponent<PlayerNightData>().NightChange();
                    dataPlayer.GetComponent<PlayerNightData>().WriteFile();

                    if(dataPlayer.GetComponent<PlayerNightData>().Unlockable == 1)
                    {
                        dataPlayer.GetComponent<PlayerNightData>().ReadFileUnlockable();
                        dataPlayer.GetComponent<PlayerNightData>().Unlock();
                        dataPlayer.GetComponent<PlayerNightData>().WriteFileUnlockable();
                    }
                }
                else if (dataPlayer.GetComponent<PlayerNightData>().LevelNight == 7 && (arrayIA[0] == 20 && arrayIA[1] == 20 && arrayIA[2] == 20 && arrayIA[3] == 20 && arrayIA[4] == 20)) //Custom Night 20 20 20 20 20
                {
                    //Creiamo una ottava notte fasulla
                    dataPlayer.GetComponent<PlayerNightData>().ReadFile();
                    dataPlayer.GetComponent<PlayerNightData>().NightChange();
                    dataPlayer.GetComponent<PlayerNightData>().WriteFile();

                    if(dataPlayer.GetComponent<PlayerNightData>().Unlockable == 2){
                        //Cambia gli Unlock, perchè abbiamo sbloccato la terza e ultima stella
                        dataPlayer.GetComponent<PlayerNightData>().ReadFileUnlockable();
                        dataPlayer.GetComponent<PlayerNightData>().Unlock();
                        dataPlayer.GetComponent<PlayerNightData>().WriteFileUnlockable();
                    }
                }
                else
                {
                    dataPlayer.GetComponent<PlayerNightData>().Unlockable = 3;
                    dataPlayer.GetComponent<PlayerNightData>().LevelNight = 7;
                }
            }

            SceneManager.LoadScene("SixAM");
        }
    }

    private void Change()
    {
        ambiencemanager.loop = true;

        switch (dataPlayer.GetComponent<PlayerNightData>().LevelNight)
        {
            case 1:
                FirstNight();
                break;
            case 2:
                SecondNight();
                break;
            case 3:
                ThirdNight();
                break;
            case 4:
                FourthNight();
                break;
            case 5:
                FifthNight();
                break;
            case 6:
                SixthNight();
                break;
            case 7:
                SeventhNight();
                break;
            default:
                Debug.Log("Errore! Questa Notte non esiste.");
                break;
        }
    }

    private void FirstNight()
    {
        /* |COMMENTI|
         *  Prima notte:
         *  Iniziano tutti disattivati, si arriva Carmine alle 2 con un'AI di 3 e si attiva Withered Carmine con un'IA di 2 alle 3
         */

        if (customDate.Hour == 0 && stato == false)
        {
            ambiencemanager.clip = ambienceArray[0];

            ambiencemanager.Play();
            nottemanager.PlayOneShot(notteArray[0]);

            classicCarmine.GetComponent<AIClassicCarmine>().setNum_IA(0);
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 0;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 0;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 0;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 0;

            stato = true;
        }
        else if (customDate.Hour == 02 && stato == true)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 3;
        }
        else if (customDate.Hour == 03){
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 2;
        }
    }

    private void SecondNight()
    {
        /* |COMMENTI|
         *  Notte due
         *  Carmine parte a 3 e sale di 2 lungo la notte, Withered Carmine parte a 2 e sale a 3 lungo la notte, Puppet Carmine si attiva alle 3 con 1 di AI
         */

        if (customDate.Hour == 0 && stato == false)
        {
            ambiencemanager.clip = ambienceArray[1];

            ambiencemanager.Play();
            nottemanager.PlayOneShot(notteArray[1]);

            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 3;
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 0;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 2;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 0;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 0;

            stato = true;
        }
        else if (customDate.Hour == 2)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 4;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 4;
        }
        else if (customDate.Hour == 3) {
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 3;
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 5;
        }
        else if(customDate.Hour == 4)
        {
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 5;
        }
    }

    private void ThirdNight()
    {
        /* |COMMENTI|
         * Notte 3 
         * Carmine parte a 5 e sale di 2 lungo la notte, Withered Carmine è inattivo, Puppet e Molten sono a 4 tutta la notte
         */


        if (customDate.Hour == 0 && stato == false)
        {
            ambiencemanager.clip = ambienceArray[2];

            ambiencemanager.Play();
            nottemanager.PlayOneShot(notteArray[2]);

            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 5;
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 0;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 0;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 4;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 4;

            stato = true;
        }
        else if(customDate.Hour == 2)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 6;
        }
        else if(customDate.Hour == 3)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 7;
        }
    }

    private void FourthNight()
    {
        /* |COMMENTI|
         * Notte quattro 
         * Carmine parte a 6 e finisce a 9, Withered Carmine parte e rimane a 6, Puppet Carmine e Molten Carmine a 4, Phantom Carmine a 8
         */

        
        if (customDate.Hour == 0 && stato == false)
        {
            ambiencemanager.clip = ambienceArray[3];

            ambiencemanager.Play();
            nottemanager.PlayOneShot(notteArray[3]);

            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 6;
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 8;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 6;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 4;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 4;

            stato = true;
        }
        else if(customDate.Hour == 1)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 7;
        }
        else if (customDate.Hour == 3)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 8;
        }
        else if(customDate.Hour == 4)
        {
            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 9;
        }
    }

    private void FifthNight()
    {
        /* |COMMENTI|
         * Notte quinta
         * Carmine a 10, Withered Carmine a 8, Puppet e Molten a 6 e Phantom a 12
         */


        if (customDate.Hour == 0 && stato == false)
        {
            ambiencemanager.clip=ambienceArray[4];

            ambiencemanager.Play();
            nottemanager.PlayOneShot(notteArray[4]);

            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 10;
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 12;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 8;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 6;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 6;

            stato = true;
        }
    }

    private void SixthNight()
    {
        /* |COMMENTI|
         * Notte 6
         * Carmine 12, Withered Carmine 10, Puppet 6, Molten 8, Phantom 14
         */

        if (customDate.Hour == 0 && stato == false)
        {
            nottemanager.mute = true;
            inizializatePhone.Stop();
            pulsante.gameObject.SetActive(false);

            ambiencemanager.Stop();
            ambiencemanager.clip = ambienceArray[5];

            // Precarica il clip con volume 0 per evitare la distorsione
            ambiencemanager.volume = 0;
            ambiencemanager.Play();
            ambiencemanager.Stop();

            // Ora riproduci il clip normalmente
            ambiencemanager.volume = 1.0f;
            ambiencemanager.Play();

            classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 12;
            phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 14;
            witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 10;
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = 6;
            moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 8;

            stato = true;
        }
    }
    
    private void SeventhNight()
    {
        /*  |COMMENTI|
         *  I valori delle IA degli animatronici dipendono dalle scelte dell'utente.
         *  L'utente deciderà nell'apposito menu.
         */

        nottemanager.mute = true;
        ambiencemanager.Stop();
        inizializatePhone.Stop();
        pulsante.gameObject.SetActive(false);

        //Legge il file dove sono salvati i dati del menu della Custom Night//
        StreamReader f = new StreamReader(PATH);

        arrayIA[0] = int.Parse(f.ReadLine());
        arrayIA[1] = int.Parse(f.ReadLine());
        arrayIA[2] = int.Parse(f.ReadLine());
        arrayIA[3] = int.Parse(f.ReadLine());
        arrayIA[4] = int.Parse(f.ReadLine());


        if (customDate.Hour == 0)
        {
            //Classic Carmine CAP//
            if(arrayIA[0]<= 16)
                classicCarmine.GetComponent<AIClassicCarmine>().num_IA = arrayIA[0];
            else
                classicCarmine.GetComponent<AIClassicCarmine>().num_IA = 16;
            //------------------//


            //Withered Carmine CAP//
            if(arrayIA[1] <= 14)
                witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = arrayIA[1];
            else
                witheredCarmine.GetComponent<AIWitheredCarmine>().num_IAW = 14;
            //-------------------//


            //Puppet Carmine CAP//
            puppetCarmine.GetComponent<AIPuppetCarmine>().num_IA = arrayIA[2];
            //------------------//


            //Molten Carmine CAP//
            if (arrayIA[3] <= 16)
                moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = arrayIA[3];
            else
                moltenCarmine.GetComponent<AIMoltenCarmine>().num_IA = 16;
            //------------------//


            //Phantom Carmine CAP//
            if (arrayIA[4] <= 16)
                phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = arrayIA[4];
            else
                phantomCarmine.GetComponent<AINightmareCarmine>().num_IA = 16;
            //------------------//
        }

        f.Close();
    }

    public void MuteCall()
    {
        pulsante.gameObject.SetActive(false);
        nottemanager.Stop();
    }
}

