using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider_Test : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private List<Collider2D> colliders;

    [SerializeField] private float factor = 5f;

    [SerializeField] public Vector2 speed = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = Vector2.zero;
        foreach (Collider2D collider in colliders)
        {
            if (collider == null)
            {
            }
            else
            {
                if (collider.gameObject.transform.position.x > gameObject.transform.position.x)
                {
                    speed = new Vector2(-factor, 0);
                }
                else
                {
                    speed = new Vector2(factor, 0);
                }
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "BodyInnerCollider")
        {
            colliders.Add(other.transform.GetComponent<BodyInnerCollider_Test>().col);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "BodyOuterCollider" && colliders.Contains(other))
        {
            colliders.Remove(other);
        }
    }
}
