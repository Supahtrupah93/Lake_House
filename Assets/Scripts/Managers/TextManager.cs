using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text objectName;
    public Text displayText;
    //public Queue<string> sentences;
    public List<string> sentences;
    public Animator anim;
    public float writeTime = 1f;


    private void Start()
    {
        
        sentences = new List<string>();
    }

    public void StartDialogue (ItemText text, int index)
    {
        objectName.text = text.name;
        sentences.Clear();
        anim.SetBool("isOpen", true);
        foreach (string sentence in text.sentences)
        {
            
            sentences.Add(sentence);
        }

        DisplayNextSentence(index);
    }

    public void DisplayNextSentence(int index)
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }
        string sentence = sentences[index]; 
        StopAllCoroutines();
        StartCoroutine("TypeSentence", sentence);
    } // visualy represents next line in the text file, maybe can be manipulated by ManageText to show non linear progression through given text

    public void EndDialogue()
    {
        anim.SetBool("isOpen", false);
    }

    IEnumerator TypeSentence (string sentence)
    {
        int sentenceLenght = sentence.Length;
        float writeIncr = writeTime / sentenceLenght;
        displayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(writeTime / sentence.Length);
        }
    }

    

}
