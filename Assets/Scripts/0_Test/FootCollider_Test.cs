using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollider_Test : MonoBehaviour
{
    [SerializeField] private List<Collider2D> colliders = new List<Collider2D>();

    [SerializeField] private bool _isGrounded = false;

    public bool IsGrounded
    {
        get { return _isGrounded; }
        set
        {
            if (_isGrounded != value)
            {
                _isGrounded = value;
                // Optionally, you can add additional logic here when IsGrounded changes
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other))
        {
            colliders.Add(other);
            FlagGrounded();
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (colliders.Contains(other))
        {
            colliders.Remove(other);
            FlagGrounded();
        }
    }

    private void FlagGrounded()
    {
        IsGrounded = colliders.Count > 0;
    }



}
