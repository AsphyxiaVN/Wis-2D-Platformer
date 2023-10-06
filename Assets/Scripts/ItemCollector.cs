using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text applesText;

    [SerializeField] private ScoreSystem scores;

    [SerializeField] private AudioSource collectedSFX;

    private void Start()
    {
        applesText.text = "Score:" + scores.Value + "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectedSFX.Play();
            Destroy(collision.gameObject);
            scores.Value++;
            applesText.text = "Score:" + scores.Value + "";
        }
    }
}
