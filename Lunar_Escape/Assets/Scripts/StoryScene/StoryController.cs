using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public StoryScene lastScene;
    public StoryScene currentScene;
    public StoryScene backstoryLast, endingLast;
    public BottomBarController bottomBar;
    public GameObject dialogueBox;
    public  Animator animator;
    public float WaitSeconds;
    public Image backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        dialogueBox.SetActive(false);
        StartCoroutine(startStoryline());
    }

    IEnumerator startStoryline() {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(SwitchScene());
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(bottomBar.IsCompleted())
            {
                if(bottomBar.IsLastSentence())
                {
                    currentScene = currentScene.nextScene;
                    StartCoroutine(SwitchScene());
                } 
                else   
                    bottomBar.PlayNextSentence();
            }
            if(currentScene == lastScene) {
                animator.SetTrigger("Start");
                if (lastScene == backstoryLast)
                    SceneManager.LoadScene(sceneBuildIndex: 2);
                else if (lastScene == endingLast)
                    SceneManager.LoadScene(sceneBuildIndex: 4);
            }
                
        }
    }

    public IEnumerator SwitchScene()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(WaitSeconds);
        dialogueBox.SetActive(true);
        animator.SetTrigger("End");
        backgroundImage.sprite = currentScene.background;
        bottomBar.PlayScene(currentScene);
        
    }


}
