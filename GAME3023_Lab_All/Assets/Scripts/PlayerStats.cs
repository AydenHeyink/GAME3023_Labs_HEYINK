using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class PlayerStats 
{

    public static float health;
    public static int maxHealth = 100;
    public static int minHealth = 0;
    public static Item sword = new Item("Sword", 40, 50);
    public static Item dagger = new Item("Dagger", 20, 10);
    public static Item fists = new Item("Fists", 10, 5);
    public static Item throwingKnives = new Item("Throwing Knives", 5, 10);
    public static List<Item> items = new List<Item>()
    { sword, dagger, fists, throwingKnives};
}
