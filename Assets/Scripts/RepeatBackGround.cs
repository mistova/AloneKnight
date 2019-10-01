using UnityEngine;

public class RepeatBackGround : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength = 0.0f;
    private float y;
    public float speed = 0.0f;
    public float scale = 1.8f;
    private Rigidbody2D rb2d;
    private Rigidbody2D rb2dCharacter;
    public GameObject character;
    public GameObject other;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2dCharacter = character.GetComponent<Rigidbody2D>();
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        y = transform.position.y;
    }
    private void Update()
    {
        if (GameControl.instance.wall() == false)
        {
            if (rb2dCharacter.velocity.x > 0)
                rb2d.velocity = new Vector2((rb2dCharacter.velocity.x * speed) / 5, 0);
            else
                rb2d.velocity = new Vector2((rb2dCharacter.velocity.x * ((3 * speed) / 5)) / 3, 0);
        }
        else
            rb2d.velocity = new Vector2(0, 0);
        if (transform.position.x < character.transform.position.x - (groundHorizontalLength * scale))
            moveFlr();
        else if (transform.position.x > character.transform.position.x + (groundHorizontalLength * scale))
            moveFlr2();
    }
    private void moveFlr()
    {
        transform.position = new Vector2(groundHorizontalLength * scale + other.transform.position.x, transform.position.y);
    }

    private void moveFlr2()
    {
        transform.position = new Vector2(other.transform.position.x - (groundHorizontalLength * scale), transform.position.y);
    }
}