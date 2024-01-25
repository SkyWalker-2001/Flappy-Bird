using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // SpriteRender for Animation

    private SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int spriteIndex;


    // movement

    private Vector3 direction;

    public float gravity = -9.8f;

    public float strength = 5f;


    // Awake Function Run First Time

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Start()  to start the Animation or Sprite Chain bla bla
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }


    // RUN every second

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // for mobile touch

        if(Input.touchCount > 0)
        {
            // first Input of Touch
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;

        direction = Vector3.zero;
    }

    private void AnimateSprite()
    {  
        spriteIndex++;

        // loop back to begin
           
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

}
