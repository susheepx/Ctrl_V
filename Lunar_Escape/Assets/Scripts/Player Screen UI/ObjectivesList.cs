using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectivesList : MonoBehaviour
{
    public static TextMeshProUGUI objective1;
    public static TextMeshProUGUI objective2;
    public static TextMeshProUGUI objective3;

    public TextMeshProUGUI objective1Container;
    public TextMeshProUGUI objective2Container;
    public TextMeshProUGUI objective3Container;

    // Start is called before the first frame update
    void Start()
    {
        objective1 = objective1Container;
        objective2 = objective2Container;
        objective3 = objective3Container;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isObjectiveOpen = true;
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
