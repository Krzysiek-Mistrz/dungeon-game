using UnityEngine;

// inherits from class monobehaviour
public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coinsAmount = 5;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.coins += coinsAmount;
            GameManager.instance.ShowText("+" + coinsAmount + " coins", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
