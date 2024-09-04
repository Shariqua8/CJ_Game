using UnityEngine;
using UnityEngine.SceneManagement;

public class AllNightControl : MonoBehaviour
{
    public GameObject dataPlayer;
    public GameObject dataCustomPlayer;

    public void Start()
    {
        Invoke("ControllQuintaNotte", 10f);
        Invoke("ControllSettimaNotte", 10f);
    }

    public void ControllQuintaNotte()
    {
        dataPlayer.GetComponent<PlayerNightData>().ReadFile();
        if(dataPlayer.GetComponent<PlayerNightData>().LevelNight == 6)
        {
            SceneManager.LoadScene("WinAllNight");
        }
    }

    public void ControllSettimaNotte()
    {
        dataPlayer.GetComponent<PlayerNightData>().ReadFile();
        dataCustomPlayer.GetComponent<GetValueNightCustom>().getValue();
        if (dataPlayer.GetComponent<PlayerNightData>().LevelNight == 8 && dataCustomPlayer.GetComponent<GetValueNightCustom>().classicCarmineIAVal == 20 && dataCustomPlayer.GetComponent<GetValueNightCustom>().witheredCarmineIAVal == 20 && dataCustomPlayer.GetComponent<GetValueNightCustom>().moltenCarmineIAVal == 20 && dataCustomPlayer.GetComponent<GetValueNightCustom>().puppetCarmineIAVal == 20 && dataCustomPlayer.GetComponent<GetValueNightCustom>().phantomCarmineIAVal == 20)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
