using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class pause : MonoBehaviour
{
   // public PlayerInfo dataBase;

    public GameObject PanelPause;
    public GameObject PanelDeath;
    public GameObject PanelLvl;

    // private Player player;
    public Text textScore;
    public Text textName;
    //public AudioClip[] mainSoundAndMenu;
    public AudioClip mainSound;

    private AudioSource audioSource;
    public Slider slider;
    public GameObject loadingScene;

    public int levelToLoad;
    //public Text textID;
    //private Text NameOfPlayer;
    //private Text IdOfPlayer;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mainSound;
        audioSource.Play();
       // Time.timeScale = 1f;
    }


    private void Update()
    {
        if (!PlayerPrefs.HasKey("playerName")&& !PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetString("playerName", "NoName");
        }
        else
        {
            textName.text = PlayerPrefs.GetString("playerName");
            textScore.text = PlayerPrefs.GetInt("Score").ToString();
        }
        if (Input.GetKey(KeyCode.Space)&& !PanelDeath.activeInHierarchy)
        {
            PauseGame();
        }
    }
    public void ExitGamePanel()
    { 
        PanelPause.SetActive(false);
        Time.timeScale = 0f;
        PanelDeath.SetActive(true);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ChoiseLvl()
    {
        PanelLvl.SetActive(true);
        Time.timeScale = 0f;

        PanelPause.SetActive(false);
    }

    public void ChoiseLvl1()
    {
       // SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        StartCoroutine(LoadingScreenOnFade());
    }
    IEnumerator LoadingScreenOnFade()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
        Time.timeScale = 1f;
        loadingScene.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void ChoiseLvl2()
    {
        StartCoroutine(LoadingScreenOnFade());
        Time.timeScale = 1f;
    }
    public void PauseGame()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResetGame()
    {

        PanelPause.SetActive(false);
        Time.timeScale = 1f;
    }
}
