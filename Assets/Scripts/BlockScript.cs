using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    public GameObject textObject; 
    public int hitsToDestroy;
    public int points;
    PlayerScript playerScript;

    Text textComponent;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
        }
    }

    // И замените метод OnCollisionEnter2D:
    void OnCollisionEnter2D(Collision2D collision)
    {
        hitsToDestroy--;
        if (hitsToDestroy <= 0)
        {
            if (playerScript != null) playerScript.BlockDestroyed(points); // Сообщаем игроку
            Destroy(gameObject);
        }
        else if (textComponent != null)
        {
            textComponent.text = hitsToDestroy.ToString();
        }
    }
}