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
    void Start()
    {
        image = closeUpImage.GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player").transform;
    }

 

    public void OpenCloseUp() {
        if (IsWindowOpen == false)
        {
            SetCloseupImage();
            //settings popupwindow to always be centered
            tempPos = transform.position;
            tempPos.x = player.position.x;
            tempPos.y = player.position.y;
        
            transform.position = tempPos;


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
        if (EventSystem.current.currentSelectedGameObject.name == "blueprintIcon")
        {
            image.sprite = blueprint;
        }
        else if (EventSystem.current.currentSelectedGameObject.name == "breakernoteIcon")  
            image.sprite = breakernote;

    }
}
