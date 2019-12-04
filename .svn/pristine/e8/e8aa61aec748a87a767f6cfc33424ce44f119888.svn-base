using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public ItemText text;

    public void Start()
    {
        text.name = this.name;
    }
    public void TriggerText(int index)
    {
        FindObjectOfType<TextManager>().StartDialogue(text, index);
    }
}
