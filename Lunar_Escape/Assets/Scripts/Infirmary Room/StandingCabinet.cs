using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCabinet : MonoBehaviour
{
    public GameCanvasController prompts;
    private bool isFirstTimeOpen = true;
    public Sprite openStandingCabinet;
    public Sprite closedStandingCabinet;
    public GameObject openPamphlet;
    private bool isPamphletOpen = false;
    private SpriteRenderer currentSprite;
    // Start is called before the first frame update
    private void Start() {
        currentSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && GetComponent<Collider2D>() == Astronaut.currentItem) {
            if (currentSprite.sprite == closedStandingCabinet)
                currentSprite.sprite = openStandingCabinet;
            else {
                if (isPamphletOpen == false) {
                    openPamphlet.SetActive(true);
                    isPamphletOpen = true;
                }
                else {
                    openPamphlet.SetActive(false);
                    isPamphletOpen = false;
                    if (isFirstTimeOpen) {
                        prompts.openDialogueBox(4, prompts.ActII);
                        isFirstTimeOpen = false;
                    }
                }

            }
        }
    }
}
