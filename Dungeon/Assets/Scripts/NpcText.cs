using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NpcText : Collidable
{
    public string message;
    private float cooldown = 10.0f;
    private float last = -10.0f;

    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - last > cooldown) 
        {
            GameManager.instance.ShowText(message, 20, Color.white, transform.position + new Vector3(0, 0.5f, 0), Vector3.zero, cooldown);
            last = Time.time;
        }
    }
}
