using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemCrush : MonoBehaviour
{
    private float timeCrush = 0.05f;

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BossCrush")
        {
            Destroy(collision.gameObject, timeCrush);
        }
    }
}
