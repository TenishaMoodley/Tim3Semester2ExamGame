using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] textLines;
    public float textSpeed; // rate text is displayed. 

    private int index; // track  conversation. ]

    private void Start()
    {
        
    }

    private void Update()
    {
         
    }

    void startDialogue() 
    {
        index = 0; 
    
    }

    IEnumerator typeLine() 
    {
        foreach (char c in textLines[index].ToCharArray()) 
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    
    }
}
