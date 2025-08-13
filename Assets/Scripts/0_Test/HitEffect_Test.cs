using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect_Test : MonoBehaviour
{
    [SerializeField] private float opacity = 1f;
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float fadeSpeed = 1f;
    // Start is called before the first frame update

    [SerializeField] private SpriteRenderer spriteRenderer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (opacity > 0)
        {
            opacity -= fadeSpeed * Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
