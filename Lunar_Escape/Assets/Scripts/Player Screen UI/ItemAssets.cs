using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set;}

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        blueprintPopup();
    }
    public Transform pfItemWorld;
    public Sprite blueprintSprite;
    public Sprite breakerNoteSprite;
    public Sprite manaPotionSprite;
    public Sprite coinSprite;
    public  Sprite medKitSprite;


    public GameObject gameDialogue;
    public GameDialogueBox setCurrentScene;
    public List<StoryScene> currentSceneList = new List<StoryScene>();
    public void blueprintPopup() {
        gameDialogue.SetActive(true);
        Debug.Log("blueprint dialogue activated show up");
        setCurrentScene.PlayScene(currentSceneList[0]);
    }

}
