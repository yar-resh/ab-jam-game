using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyPath Path;
    public GameObject SpawnPosition;
    public float Speed = 2f;
    public float Delta = 0.2f;

    private Vector3 direction = Vector3.right;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Path != null)
        {
            var currentPosition = transform.localPosition;
            if (Mathf.Abs((Path.EndPosition.x - currentPosition.x)) <= Delta && direction.Equals(Vector3.right))
            {
                direction = Vector3.left;
                sprite.flipX = true;
            } 
            else if (Mathf.Abs((Path.StartPosition.x - currentPosition.x)) <= Delta && direction.Equals(Vector3.left))
            {
                direction = Vector3.right;
                sprite.flipX = false;
            }

            transform.Translate(direction * Speed * Time.deltaTime);
            
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = SpawnPosition.transform.position;
        }

    }
}
