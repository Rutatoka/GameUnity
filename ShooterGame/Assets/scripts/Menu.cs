using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
   public InputField inGame;
    public GameObject playButton;
   public GameObject SaveNameButton;
    public Text PlayerName;
    public Slider slider;
    public GameObject loadingScene;
    public int levelToLoad;

    //public Text PlayerID;
    //public Text PlayerNameDont;
    //public Text PlayerIDDont;
    //  public PlayerInfo dataBase;

    //  private string namePlayer;


    int saveNameGame = 0;

    private void Start()
    {
      
        //for (int i = 0; i < dataBase.ItemsBD.Count; i++)
        //{
        //    PlayerName.text =  dataBase.ItemsBD[Random.Range(0, dataBase.ItemsBD.Count)].namePlayer;
        //    PlayerID.text =  dataBase.ItemsBD[Random.Range(0, dataBase.ItemsBD.Count)].id.ToString();
          
        //}
        //var allNamesPlayers = Resources.LoadAll<PlayerInfo>("");
        //foreach(var playerInfo in allNamesPlayers)
        //{
        //    Debug.Log(playerInfo.ItemsBD.);

        //}
      //  PlayerName.text = inGame.text.ToString();
        inGame.GetComponent<Text>();
       // PlayerPrefs.SetString("playerName", inGame.text.ToString());

        //     PlayerPrefs.SetString("playerName", namePlayer);

        //   PlayerPrefs.Save();
    }
    private void Update()
    {
        //PlayerIDDont.text = PlayerID.text;
        //PlayerNameDont.text = PlayerName.text;
      // PlayerName.text = PlayerPrefs.GetString("playerName");
        if (inGame.text == "")
        {
            SaveNameButton.GetComponent<Button>().interactable = false;

        }
        else
        {

            SaveNameButton.GetComponent<Button>().interactable = true;

            PlayerPrefs.SetString("playerName", inGame.text.ToString());// это создает имя перса




            if (saveNameGame == 1)
            {
                playButton.GetComponent<Button>().interactable = true;

            }
        }

    }

    public void SaveName()
   {
        //for (int i = 0; i < dataBase.ItemsBD.Count; i++)
        //{
        //    PlayerName.text =  dataBase.ItemsBD[Random.Range(0, dataBase.ItemsBD.Count)].namePlayer;
        //    PlayerID.text =  dataBase.ItemsBD[Random.Range(0, dataBase.ItemsBD.Count)].id.ToString();
        //}

       PlayerName.text = PlayerPrefs.GetString("playerName");
        Debug.Log(inGame.text.ToString());
          saveNameGame = 1;

    }
    public void StartGame()
    {
        

         //   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Time.timeScale = 1f;
            StartCoroutine(LoadingScreenOnFade());

    }
    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }

    }
    public void OpenRules()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2 );
    }
    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

   
}
