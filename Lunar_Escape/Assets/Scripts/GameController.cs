using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public  Animator animator;
    public float WaitSeconds;
    public Image backgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        bottomBar.PlayScene(currentScene);
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
                
        }
    }

    public IEnumerator SwitchScene()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(WaitSeconds);
        animator.SetTrigger("End");
        backgroundImage.sprite = currentScene.background;
        bottomBar.PlayScene(currentScene);
        
    }


}
