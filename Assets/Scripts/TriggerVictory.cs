using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVictory : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        var p = collider.gameObject.GetComponent<witchAnimate>();
        if (p != null)
        {
            switch (p.el)
            {
                case witchAnimate.Element.fire:
                    changeVictoryCandyColor.spriteIndex = 0;
                    break;
                case witchAnimate.Element.ice:
                    changeVictoryCandyColor.spriteIndex = 1;
                    break;
                case witchAnimate.Element.wind:
                    changeVictoryCandyColor.spriteIndex = 2;
                    break;
            }
            Application.LoadLevel("Victory");
        }

    }
}
