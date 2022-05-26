using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set;}

    private void Awake() {
        Instance = this;
    }
    public Transform pfItemWorld;
    public Sprite blueprintSprite;
    public Sprite breakerNoteSprite;
    public Sprite breakerWireNoteSprite;
    public Sprite bottle1Sprite;
    public Sprite bottle2Sprite;
    public Sprite bottle3Sprite;
    public Sprite poemSprite;
    public Sprite folderSprite;
    public Sprite keycardSprite;
    public Sprite adhesiveSprite;
}
