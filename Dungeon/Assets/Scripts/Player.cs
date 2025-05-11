using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    public bool isAlive = true;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // getting OX and OY parameter
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (this.isAlive)
            UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }

    public void OnLevelUp()
    {
        maxHitPoint++;
        hitPoint = maxHitPoint;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    public void Heal(int healingAmount)
    {
        if (hitPoint == maxHitPoint)
            return;

        hitPoint += healingAmount;
        if (hitPoint > maxHitPoint)
        {
            hitPoint = maxHitPoint;
        }
        GameManager.instance.ShowText("+ " + healingAmount.ToString() + " HP", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitpointChange();
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (isAlive)
        {
            base.ReceiveDamage(dmg);
            GameManager.instance.OnHitpointChange();
        }

        else
            return;
    }

    protected override void Death()
    {
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
        this.isAlive = false;
    }
}
