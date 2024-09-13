using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    SpriteRenderer spritRenderer;
    public float minDistance;
    public Transform player;
    [TextArea]
    public string chat;

    private void Awake()
    {
        spritRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < minDistance)
        {
            spritRenderer.color = Color.black;
        }
        else
        {
            spritRenderer.color = Color.cyan;
        }
    }
}
