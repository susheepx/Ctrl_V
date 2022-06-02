using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public StoryScene lastScene;
    public StoryScene currentScene;
    public StoryScene backstoryLast, endingLast, backstoryFirst;
    public BottomBarController bottomBar;
    public GameObject dialogueBox;
    public  Animator animator, effectsAnim;
    public float WaitSeconds;
    public Image backgroundImage;
    private bool canSkip = true;

    // Start is called before the first frame update
    void Start()
    {
        if (currentScene == backstoryFirst) {
            dialogueBox.SetActive(false);
            StartCoroutine(startStoryline());
        }
        else {
            bottomBar.PlayScene(currentScene);
        }
    }

    IEnumerator startStoryline() {
        canSkip = false;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SwitchScene());
    }


    IEnumerator startLastScene() {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        if (lastScene == backstoryLast)
            SceneManager.LoadScene(sceneBuildIndex: 2);
        else if (lastScene == endingLast) {
            WinScreen.didWin = true;
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
    }


    IEnumerator endScenePlay() {
        effectsAnim.SetTrigger("Scene11");
        yield return new WaitForSeconds(0.65f);
        currentScene = currentScene.nextScene;
        bottomBar.PlayScene(currentScene);
    }
    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && canSkip)
        {
            
            if(bottomBar.IsCompleted())
            {
                
                if(bottomBar.IsLastSentence())
                {
                    if(currentScene == EndingList[0]) {
                        StartCoroutine(endScenePlay());
                    }
                    else if(currentScene == lastScene) {
                        StartCoroutine(startLastScene());
                    }
                    else {
                        currentScene = currentScene.nextScene;
                        StartCoroutine(SwitchScene());
                    }
                } 
                else   
                    bottomBar.PlayNextSentence();
            }
            
                
        }
    }

    public List<StoryScene> backstoryList = new List<StoryScene>();
    public List<StoryScene> EndingList = new List<StoryScene>();

    public IEnumerator SwitchScene()
    {
        canSkip = false;
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(WaitSeconds);
        dialogueBox.SetActive(true);
        animator.SetTrigger("End");
        backgroundImage.sprite = currentScene.background;
        bottomBar.PlayScene(currentScene);
        //certain effects happen on specific backgrounds
        if (currentScene == backstoryList[7]) {
            effectsAnim.SetTrigger("Shake");
        }
        canSkip = true;
        
    }


}
