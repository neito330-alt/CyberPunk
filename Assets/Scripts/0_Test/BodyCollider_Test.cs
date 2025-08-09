using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider_Test : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private List<Collider2D> colliders;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Collider2D collider in colliders)
        {
            if (collider == null)
            {
            }
            else
            {
                if (collider.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    rb.AddForce(new Vector2(-0.5f, 0), ForceMode2D.Impulse);
                }
                else
                {
                    rb.AddForce(new Vector2(0.5f, 0), ForceMode2D.Impulse);
                }
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log(gameObject.name + "-OnTriggerEnter2D: " + other.name);
        colliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other){
        Debug.Log(gameObject.name + "-OnTriggerExit2D: " + other.name);
        colliders.Remove(other);
    }
}
