using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerLock : MonoBehaviour
{
    public bool isCodeSolved;
    public GameObject breakerBox;
    public GameObject wireBackground;
    public Animator anim;
    public List<string> lockAlphaList;
    public List<string> lockSlot;
    public List<string> inputCodeList = new List<string>();
    public List<string> secretCodeList = new List<string>();



    private void Start() {
    }
    public List<string> GetInputList()
    {
        return inputCodeList;
    }




    public void checkSecretCode() {
        for (int i = 0; i < secretCodeList.Count; i++) {
            if (inputCodeList[i] == secretCodeList[i])
                isCodeSolved = true;
            else
            {
                isCodeSolved = false;
                StartCoroutine(errorMessage());
                break;
            }
        }
        if (isCodeSolved)
            StartCoroutine(UnlockedBreaker());
    }
    
    public GameObject error;

    public void setErrorFalse() {
        error.SetActive(false);
    }
    public IEnumerator errorMessage() {
        
        for (int i = 0; i < 5; i ++) {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
        }
    }
    IEnumerator UnlockedBreaker() {
        yield return new WaitForSeconds(0.6f);
        gameObject.SetActive(false);
        breakerBox.SetActive(false);
        wireBackground.SetActive(true);
        ObjectivesList.objective2.text = "Open the door!";
        Astronaut.canMove = true;
        Timer.hintCount = 2;
    }
        
}
