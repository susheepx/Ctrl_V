using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintList : MonoBehaviour
{

    public GameObject HintButton, CanvasHintList;
    public TMP_Text TextHint1, TextHint2, TextHint3, TextHint4;
    private int HintCount=0;
    private int PuzzleCount=1;

    public void TurnOnFuncHintList()
    {
        CanvasHintList.SetActive(true);
        HintButton.SetActive(false);
    }
    public void TurnOffFuncHintList()
    {
        CanvasHintList.SetActive(false);
        HintButton.SetActive(true);
    }

    public void ActivateHint()
    {
        HintCount+=1;
        if (HintCount==1)
        {
            
            TextHint1.text="I think Scientist James had something in his hands before he…had his fall.";
        }
        else if (HintCount==2)
        {
            
            TextHint2.text="There are three letters from C to F.  What three letters would connect to the letters J, L, and K if the letters moved three forward?";
        }
        else if (HintCount==3)
        {
            
            TextHint3.text="There’s a little scribble on the bottom of that security note…maybe the letters mean something to the wire?";
        }
        else if (HintCount==4)
        {
            
            TextHint4.text="Connect the Pink to Red wire, Yellow to Blue, and Orange to Green wire to unlock the doors.";
        }
        if (HintCount==5)
        {
            
            TextHint1.text="A is the first letter of the alphabet, and L is the 12th. What about the rest?";
        }
        if (HintCount==6)
        {
            
            TextHint2.text="What supplies does the medical pamphlet want you to get?";
        }
        if (HintCount==7)
        {
            
            TextHint3.text="The colors of the letters might tell you the words, and the order they go in is the color of their suit";
        }
        if (HintCount==8)
        {
            
            TextHint4.text="Reach high for the stars (Gabriel says “reach”, Erica says “high”, Justin says “for”,  Genesis says “the”, and the user says “stars” ";
        }
        if (HintCount==9)
        {
            
            TextHint1.text="Instead of going three letters forward, try going three letters backward in the word, “MOON.  Then check inside…maybe there’s something useful.";
        }
        if (HintCount==10)
        {
            
            TextHint2.text="The chemicals’  color looks similar to the periodic table.";
        }
        if (HintCount==11)
        {
            
            TextHint3.text="D to F...One letter forward from JLLK";
        }
        if (HintCount==12)
        {
            
            TextHint4.text="Mix {lime + yellow + red} chemicals together to form the adhesive.";
        }

    }
    public void NextPuzzle()
    {
        TextHint1.text = "";
        TextHint2.text = "";
        TextHint3.text = "";
        TextHint4.text = "";
        PuzzleCount+=1;
    }
}
