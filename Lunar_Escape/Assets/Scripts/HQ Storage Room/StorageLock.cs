using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageLock : MonoBehaviour
{
    public bool isCodeSolved;
    public GameObject storageDoor;
    public Animator anim;
    public List<string> lockAlphaList;
    public List<string> lockSlot;
    public List<string> inputCodeList = new List<string>();
    public List<string> secretCodeList = new List<string>();



    private void Start() {
        anim = storageDoor.GetComponent<Animator>();
    }
    public List<string> GetInputList()
    {
        return inputCodeList;
    }


    public BreakerLock breakerLock;
    public void checkSecretCode() {
        for (int i = 0; i < secretCodeList.Count; i++) {
            if (inputCodeList[i] == secretCodeList[i])
                isCodeSolved = true;
            else
            {
                isCodeSolved = false;
                //StartCoroutine(breakerLock.errorMessage());
                break;
            }
        }
        if (isCodeSolved)
            StartCoroutine(UnlockedStorage());
    }
    
    IEnumerator UnlockedStorage() {
        yield return new WaitForSeconds(0.6f);
        gameObject.SetActive(false);
        anim.SetTrigger("InfirmaryDoorSlide");
        Astronaut.canMove = true;
        Timer.hintCount = 9;

    }
        
}