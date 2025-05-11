using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Boss : Enemy 
{
    public float[] fireballSpeeds = { 2.5f, -2.5f };
    public Transform[] fireballs;
    public float distance = 0.25f;

    private void Update()
    {
            for (int i = 0; i < fireballs.Length; i++)
            {
                fireballs[i].position = transform.position + new Vector3((float)-Math.Cos(Time.time * fireballSpeeds[i]) * distance, (float)Math.Sin(Time.time * fireballSpeeds[i]) * distance, 0);
            }
    }
}