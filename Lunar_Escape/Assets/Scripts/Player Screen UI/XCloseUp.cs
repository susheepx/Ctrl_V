using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XCloseUp : MonoBehaviour
{
    public GameObject inventoryPopUp;
    public CloseUpWindow closeUpWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp() {
        inventoryPopUp.SetActive(false);
        closeUpWindow.IsWindowOpen = false;
        closeUpWindow.image.sprite = null;
    }
}
