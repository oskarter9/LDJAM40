using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingEffect : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    public float GrowByHit;
    private Vector3 growSpeed;

	// Use this for initialization
	void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        growSpeed = new Vector3(1, 1 + GrowByHit, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grow()
    {
        boxCollider.size = new Vector2(boxCollider.size.x, boxCollider.size.y + GrowByHit);
        spriteRenderer.transform.Translate(new Vector3(0, GrowByHit/5f, 0));
        
        
    }
}
