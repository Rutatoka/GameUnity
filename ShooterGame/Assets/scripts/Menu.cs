using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    [Header("buttons")]
    public InputField inGame;
    public GameObject playButton;
    public GameObject SaveNameButton;
    public GameObject ContinueButton;
    [Header("scenes")]
    public Text PlayerName;
    public Slider slider;
    public GameObject loadingScene; 
    public GameObject[] rules;
    public int levelToLoad;
    [Header("music")]
    public AudioClip mainSound;
    private AudioSource audioSource;
    int saveNameGame = 0;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mainSound;
        audioSource.Play();
        inGame.GetComponent<Text>();
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            ContinueButton.GetComponent<Button>().interactable = true;
        }
        if (inGame.text == "")
        {
            SaveNameButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            SaveNameButton.GetComponent<Button>().interactable = true;
            PlayerPrefs.SetString("playerName", inGame.text.ToString());
            if (saveNameGame == 1)
            {
                playButton.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void SaveName()
    {
        PlayerName.text = PlayerPrefs.GetString("playerName");
        Debug.Log(inGame.text.ToString());
        saveNameGame = 1;
    }

    public void StartGame()
    {
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
    public void NextRules1()
    {
        rules[0].SetActive(true);
    }
    public void NextRules2()
    {
        rules[0].SetActive(false);
        rules[1].SetActive(true);
    }
    public void NextRules3()
    {
        rules[1].SetActive(false);
        rules[2].SetActive(true);
    }
    public void NextRules4()
    {
        rules[2].SetActive(false);
        rules[3].SetActive(true);
    }
    public void NextRules5()
    {
        rules[3].SetActive(false);
        rules[4].SetActive(true);
    }
    public void Exit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
