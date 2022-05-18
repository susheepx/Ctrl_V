using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerButton : MonoBehaviour
{
    //breaker door anim
    public Animator anim;
    private string SLIDINGDOORANIM = "activated";
    //is the item interactable?
    public Astronaut controlPrompt;
    public GameObject popupBox;
    public GameObject breakerBox;
    public GameObject breakerLock;
    public Collider2D breakerCollider;
    private bool isLockShown = false;
    //is close up of breaker box shown
    private bool isCloseup = false;
    //is breaker door opened
    private bool doorOpened = false;

    private void Start() {
        
        breakerBox.SetActive(false);
        breakerLock.SetActive(false);
        controlPrompt.currentItem = GetComponent<Collider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && controlPrompt.interact)
        {
            if (doorOpened == false && GetComponent<Collider2D>() == controlPrompt.currentItem)
            {
                breakerBox.SetActive(true);
                anim.SetTrigger(SLIDINGDOORANIM);
                doorOpened = true;
            }
            else if (breakerCollider == controlPrompt.currentItem)
            {
                if (isCloseup == false)
                {
                    popupBox.SetActive(true);
                    isCloseup = true;
                }
                else
                {
                    popupBox.SetActive(false);
                    isCloseup = false;    
                    breakerLock.SetActive(false);
                    isLockShown = false;               
                }   
            }
            

        }

        if (Input.GetKeyDown(KeyCode.Q) && isCloseup)
            {
                if (isLockShown == false)
                {
                    breakerLock.SetActive(true);
                    isLockShown = true;
                }
                else
                {
                    breakerLock.SetActive(false);
                    isLockShown = false;
                    isCloseup = true;
                }
            }


    }
   
}
