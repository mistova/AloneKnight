using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    public float upForce = 500f;
    private bool isFloor = true;
    private Animator anim;     
    private Rigidbody2D rb2d;
    private int holdAtt = 0;
    private int holdIdle = 0;
    private int holdBack = 0;
    private int hold = 0;
    public float speed = 0.0f;
    public static CharacterController ch = new CharacterController();
    private Joystick joyStick;
    private JoyButton joyButton;
    private bool isAnimate = true;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        joyStick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<JoyButton>();
    }
    void Update()
    {
        isAnimate = isFloor && (holdAtt > 82);
        if (GameControl.instance.IsAlive())
        {
            if ((joyStick.Vertical > 0.6 /*|| Input.GetKey(KeyCode.UpArrow)*/) && isAnimate){
                isFloor = false;
                anim.SetTrigger("Jump");
                rb2d.AddForce(new Vector2(0, upForce));
            }
            else if ((joyButton.Pressed /*|| Input.GetKey(KeyCode.Space)*/) && isAnimate)
            {
                holdAtt = 0;
                anim.SetTrigger("Attack");
            }
            if (joyStick.Horizontal > 0.4 /*|| Input.GetKey(KeyCode.RightArrow)*/)
            {
                rb2d.velocity = new Vector2(joyStick.Horizontal * speed, rb2d.velocity.y);
                if(holdIdle > 32 && isAnimate)
                {
                    holdIdle = 0;
                    anim.SetTrigger("Idle");
                }
            }
            else if ((joyStick.Horizontal < -0.4 && transform.position.x > -5) /*|| Input.GetKey(KeyCode.LeftArrow)*/)
            {
                rb2d.velocity = new Vector2((joyStick.Horizontal * speed * 3) / 5, rb2d.velocity.y);
                if (holdBack > 82 && isAnimate)
                {
                    holdBack = 0;
                    anim.SetTrigger("Back");
                }
            }
            else
            {
                if(hold > 45 && holdBack > 82 && isAnimate)
                {
                    hold = 0;
                    //anim.SetTrigger("Hold");
                }
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
            hold++;
            holdAtt++;
            holdBack++;
            holdIdle++;
        }
        GameControl.instance.Attack(holdAtt);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isFloor = true;
    }/*
    private void tRigger()
    {

        if (((ky1.transform.position.x - transform.position.x) > 2.4 && (ky1.transform.position.x - transform.position.x) < 2.6) ||
            ((ky2.transform.position.x - transform.position.x) > 2.4 && (ky2.transform.position.x - transform.position.x) < 2.6)   )
        {
            GameControl.instance.isWallTrue();
        }
        else
            GameControl.instance.isWallFalse();
    }*/
}