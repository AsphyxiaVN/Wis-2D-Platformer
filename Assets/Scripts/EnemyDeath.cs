using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private Text scoresText;

    [SerializeField] private ScoreSystem scores;

    [SerializeField] private AudioSource collectedSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collectedSFX.Play();
            Destroy(collision.gameObject);
            scores.Value++;
            scoresText.text = "Score:" + scores.Value + "";
        }
    }
}
