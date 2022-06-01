using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerButton : MonoBehaviour
{
    //breaker door anim
    public Animator anim;
    private string SLIDINGDOORANIM = "activated";
    //is the item interactable?
    public GameObject popupBox;
    public GameObject breakerBox;
    public GameObject breakerLock;
    public GameObject controlPrompt;
    public Collider2D breakerCollider;
    private bool isLockShown = false;
    //is close up of breaker box shown
    private bool isCloseup = false;
    //is breaker door opened
    private bool doorOpened = false;

    private void Start() {
        
        breakerBox.SetActive(false);
        breakerLock.SetActive(false);
        Astronaut.currentItem = GetComponent<Collider2D>();

        
    }

    public static bool isBlueprintPicked = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Astronaut.interact && isBlueprintPicked)
        {
            if (doorOpened == false && GetComponent<Collider2D>() == Astronaut.currentItem)
            {
                breakerBox.SetActive(true);
                anim.SetTrigger(SLIDINGDOORANIM);
                doorOpened = true;
            }
            else if (breakerCollider == Astronaut.currentItem)
            {
                if (isCloseup == false)
                {
                    Astronaut.canMove = false;
                    popupBox.SetActive(true);
                    isCloseup = true;
                }
                else
                {
                    Astronaut.canMove = true;
                    popupBox.SetActive(false);
                    isCloseup = false;    
                    breakerLock.SetActive(false);
                    isLockShown = false;               
                }   
            }
            

        }
        else if(GetComponent<Collider2D>() == Astronaut.currentItem && Astronaut.interact && isBlueprintPicked == false) {
            controlPrompt.SetActive(false);
        }
        
    }
    public void openBreakerLock() {
            if (isCloseup)
            {
                if (isLockShown == false)
                {
                    breakerLock.SetActive(true);
                    isLockShown = true;
                    Astronaut.canMove = false;
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
