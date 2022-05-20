using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCabinet : MonoBehaviour
{
    public Sprite openStandingCabinet;
    public Sprite closedStandingCabinet;
    private SpriteRenderer currentSprite;
    // Start is called before the first frame update
    private void Start() {
        currentSprite = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            if (currentSprite.sprite == closedStandingCabinet)
                currentSprite.sprite = openStandingCabinet;
            else   
                currentSprite.sprite = closedStandingCabinet;
        }
    }
}
