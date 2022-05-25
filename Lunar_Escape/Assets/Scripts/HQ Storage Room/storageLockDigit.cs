using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class storageLockDigit : MonoBehaviour
{
    private TextMeshProUGUI alphaChange;
    public StorageLock Code;
    private int x = 1;

    // Start is called before the first frame update
    void Start()
    {
        alphaChange = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCode() {
        x += 1;
        if (x>3)
            x = 0;
        Debug.Log(alphaChange.text);
        Debug.Log(Code.lockAlphaList[x]);
        alphaChange.text = Code.lockAlphaList[x];
        Code.inputCodeList[Code.lockSlot.IndexOf(EventSystem.current.currentSelectedGameObject.name)] = Code.lockAlphaList[x];
        Code.checkSecretCode();
    }
}
