using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CloseUpWindow : MonoBehaviour
{
    public SpriteRenderer image;
    public GameObject closeUpImage;
    private Transform player;
    private Vector3 tempPos;
    public bool IsWindowOpen = false;
    private string buttonName;
    public GameObject controlPrompt;
    public TextMeshProUGUI controlText;

    
    public Sprite blueprint, breakernote, breakerwirenote, poem, folder;
    private void Awake() 
    {
        image = closeUpImage.GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").transform;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()    
    {
        SetCloseupPosition(); 
    }
 

    public void OpenCloseUp() {
        buttonName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(buttonName);
        if (IsWindowOpen == false)
        {
            SetCloseupPosition();
            SetCloseupImage();            
            if (image.sprite == null) {
                gameObject.SetActive(false);
                IsWindowOpen = false;
                return;
            }
            gameObject.SetActive(true);
            IsWindowOpen = true;
  
        }   
        else
        {
            if(buttonName == "folderIcon") {
                controlPrompt.SetActive(true);
                controlText.text = "- Insert Keycard -";
                controlPrompt.SetActive(false);
                
            }
            gameObject.SetActive(false);
            IsWindowOpen = false;
            image.sprite = null;
        } 

    }

    public void SetCloseupImage() {
        if (buttonName != null)
        {
            if (buttonName == "blueprintIcon")
            {
                image.sprite = blueprint;
            }
            else if (buttonName == "breakernoteIcon")  
            {
                image.sprite = breakernote;
            }
            else if (buttonName == "breakerwirenoteIcon")  
            {
                image.sprite = breakerwirenote;
            }
            else if (buttonName == "poemIcon")
            {
                image.sprite = poem;  
            }
            else if (buttonName == "folderIcon")
            {
                image.sprite = folder;
            }
        }

    }

    public void SetCloseupPosition() 
    {

        //settings popupwindow to always be centered
        tempPos = transform.position;
        tempPos.x = player.position.x;
        tempPos.y = player.position.y;
    
        transform.position = tempPos;
    }

}
