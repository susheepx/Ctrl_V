using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseUpWindow : MonoBehaviour
{
    private SpriteRenderer image;
    public GameObject closeUpImage;
    private Transform player;
    private Vector3 tempPos;
    private bool IsWindowOpen = false;
    private string buttonName;
    public Sprite blueprint;
    
    public Sprite breakernote;
    public Sprite poem;
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
            gameObject.SetActive(false);
            IsWindowOpen = false;
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
            else if (buttonName == "poemIcon")
                image.sprite = poem;  
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
