using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    DialogeBox dbox;
    public GameObject panel;
    public void HelpClick()
    {
            panel.gameObject.SetActive(true);
            panel.gameObject.GetComponent<DialogeBox>().textComponent.text = string.Empty;
            panel.gameObject.GetComponent<DialogeBox>().StartDialogue();
    }
}
