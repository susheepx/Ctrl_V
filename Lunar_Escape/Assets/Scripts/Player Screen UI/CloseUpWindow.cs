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
    public Sprite blueprint;
    
    public Sprite breakernote;
    private void Awake() 
    {
        gameObject.SetActive(false);
        image = closeUpImage.GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()    
    {
        SetCloseupPosition(); 
    }
 

    public void OpenCloseUp() {
        if (IsWindowOpen == false)
        {
            SetCloseupPosition();
            SetCloseupImage();
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
        if (EventSystem.current.currentSelectedGameObject.name != null)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "blueprintIcon")
            {
                image.sprite = blueprint;
            }
            else if (EventSystem.current.currentSelectedGameObject.name == "breakernoteIcon")  
                image.sprite = breakernote;
        }

    }

    public void SetCloseupPosition() {
        //settings popupwindow to always be centered
            tempPos = transform.position;
            tempPos.x = player.position.x;
            tempPos.y = player.position.y;
        
            transform.position = tempPos;
    }
}
