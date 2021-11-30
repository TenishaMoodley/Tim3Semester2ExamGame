using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] rules;
    public float textSpeed;

    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == rules[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = rules[index];
            }
        }
        
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(typeLine());
    }

    public void NextLine()
    {
        if (index < rules.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(typeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator typeLine()
    {
        foreach (char c in rules[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
