using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesList : MonoBehaviour
{
    public static TextMeshProUGUI objective1;
    public static TextMeshProUGUI objective2;
    public static TextMeshProUGUI objective3;

    

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isObjectiveOpen = false;
    public void setObjectiveListActive() {
        if (isObjectiveOpen == false) {
            isObjectiveOpen = true;
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
            isObjectiveOpen = false;
        }
    }
}
