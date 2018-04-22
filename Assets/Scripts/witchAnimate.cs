using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchAnimate : MonoBehaviour {

    public enum Direction { down = 0, up = 8, side = 16 }
    public Direction dir = Direction.down;
    public enum Element { fire = 0, ice = 24, wind = 48 }
    public Element el = Element.fire;
    public enum Deed { idle = 0, walk = 1, shoot = 5 }
    public Deed current = Deed.walk;

    Sprite[] animationSet;
    SpriteRenderer spr;

    public int frame = 0;

	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        animationSet = Resources.LoadAll<Sprite>("Candy");
	}

    float frAccum = 0;
    public float walkingFrameRate = 0.02f;
    public float shootingFrameRate = 0.01f;

    bool justSwitched = false;

    // Update is called once per frame
    void Update () {

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var wasShooting = current == Deed.shoot;

        if (v < 0)
        {
            dir = Direction.down;
            spr.flipX = false;
            current = Deed.walk;
        }
        else if (v > 0)
        {
            dir = Direction.up;
            spr.flipX = false;
            current = Deed.walk;
        }
        else if (h > 0)
        {
            dir = Direction.side;
            spr.flipX = false;
            current = Deed.walk;
        }
        else if (h < 0)
        {
            dir = Direction.side;
            spr.flipX = true;
            current = Deed.walk;
        }
        else current = Deed.idle;
        if (wasShooting) current = Deed.shoot;

        if (Input.GetButtonDown("Switch"))
            el = (el == Element.fire) ? Element.ice : ((el == Element.ice) ? Element.wind : Element.fire);
        if (Input.GetButtonDown("Attack"))
        {
            frame = 0;
            frAccum = 0;
            current = Deed.shoot;
        }

        frAccum += Time.deltaTime;
        switch(current)
        {
            case Deed.idle:
                frAccum = 0;
                frame = 0;
                break;
            case Deed.walk:
                if (frAccum >= walkingFrameRate)
                {
                    frame++;
                    frAccum = 0;
                }
                frame %= 4;
                break;
            case Deed.shoot:
                if (frAccum >= shootingFrameRate)
                {
                    frame++;
                    frAccum = 0;
                }
                if (frame >= 3)
                {
                    frame = 0;
                    current = Deed.idle;
                }
                break;
        }
        spr.sprite = animationSet[(int)dir + (int)el + (int)current + frame];
	}
}
