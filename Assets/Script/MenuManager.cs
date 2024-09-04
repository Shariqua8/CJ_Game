using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image star;
    public Image star2;
    public Image star3;

    public Button CustomNight;
    public Button SixNight;

    public GameObject SceneManager;
    public GameObject dataPlayer;

    // Start is called before the first frame update
    void Start()
    {
        CustomNight.gameObject.SetActive(false);
        SixNight.gameObject.SetActive(false);

        star.enabled = false;
        star2.enabled = false;
        star3.enabled = false;

        dataPlayer.GetComponent<PlayerNightData>().ReadFile();
    }

    // Update is called once per frame
    void Update()
    {


        if (dataPlayer.GetComponent<PlayerNightData>().Unlockable == 1)
        {
            star.enabled = true;
            SixNight.gameObject.SetActive(true);
        }
        else if(dataPlayer.GetComponent<PlayerNightData>().Unlockable == 2)
        {
            star.enabled = true;
            star2.enabled = true;

            SixNight.gameObject.SetActive(true);
            CustomNight.gameObject.SetActive(true);
        }
        else if (dataPlayer.GetComponent<PlayerNightData>().Unlockable == 3)
        {
            star.enabled = true;
            star2.enabled = true;
            star3.enabled = true;

            SixNight.gameObject.SetActive(true);
            CustomNight.gameObject.SetActive(true);
        }
    }

    public void ContinueNightButtonPress()
    {
        if(dataPlayer.GetComponent<PlayerNightData>().LevelNight <= 5)
        {
            SceneManager.GetComponent<ChangeScene>().PlayScene("12AM");
        }
        else
        {
            dataPlayer.GetComponent<PlayerNightData>().LevelNight = 5;
            dataPlayer.GetComponent<PlayerNightData>().WriteFile();
            SceneManager.GetComponent<ChangeScene>().PlayScene("12AM");
        }
    }

    public void SixNightButtonPress()
    {
        if(dataPlayer.GetComponent<PlayerNightData>().LevelNight == 6)
        {
            SceneManager.GetComponent<ChangeScene>().PlayScene("12AM");
        }
        else
        {
            dataPlayer.GetComponent<PlayerNightData>().LevelNight = 6;
            dataPlayer.GetComponent<PlayerNightData>().WriteFile();
            SceneManager.GetComponent<ChangeScene>().PlayScene("12AM");
        }
    }

    public void CustomNightButtonPress()
    {
        if (dataPlayer.GetComponent<PlayerNightData>().LevelNight == 7)
        {
            SceneManager.GetComponent<ChangeScene>().PlayScene("MenuCustomNight");
        }
        else
        {
            dataPlayer.GetComponent<PlayerNightData>().LevelNight = 7;
            dataPlayer.GetComponent<PlayerNightData>().WriteFile();
            SceneManager.GetComponent<ChangeScene>().PlayScene("MenuCustomNight");
        }
    }
}
