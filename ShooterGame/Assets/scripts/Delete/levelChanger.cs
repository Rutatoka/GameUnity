//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;



//public class levelChanger : MonoBehaviour
//{
//    private Animator anim;
//    public int levelToLoad;
//    public Slider slider;
//    public GameObject loadingScene;
   
//    // public Vector3 position;
//    private void Start()
//    {
//        anim = GetComponent<Animator>();
//    }
//    public void FadeToLevel()
//    {
//        anim.SetTrigger("fade");
//    }
//    public void OnFadeComplete()
//    {
//        SceneManager.LoadSceneAsync(levelToLoad);
//        StartCoroutine(LoadingScreenOnFade());
//    }
//    IEnumerator LoadingScreenOnFade()
//    {
//        AsyncOperation operation = SceneManager.LoadSceneAsync(levelToLoad);
//        loadingScene.SetActive(true);
//        while (!operation.isDone)
//        {
//            float progress = Mathf.Clamp01(operation.progress / 0.9f);
//            slider.value = progress;
//            yield return null;
//        }

//    }
//}
