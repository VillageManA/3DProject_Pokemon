using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemData> potions = new List<ItemData>();
    List<ItemData> balls = new List<ItemData>();

    public void AddPotion(ItemData potion)
    {
        potions.Add(potion);
    }
    public void RemovePotion(ItemData potion)
    {
        potions.Remove(potion);
    }
    public int GetPotionCount()
    {
        return potions.Count;
    }
    public void AddBall(ItemData ball)
    {
        balls.Add(ball);
    }
    public void RemoveBall(ItemData ball)
    {
        balls.Remove(ball);
    }
    public int GetBallCount()
    {
        return balls.Count;
    }


}
