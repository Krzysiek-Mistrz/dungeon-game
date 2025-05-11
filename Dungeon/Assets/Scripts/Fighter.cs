using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour 
{
    // health
    public int hitPoint;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // immunity
    protected float immuneTime = 1.0f;
    public float lastImmune;

    // push
    public Vector3 pushDirection;

    // all fighter can receive damage
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, gameObject.transform.position, Vector3.zero, 0.5f);

            if(hitPoint <= 0)
            {
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
