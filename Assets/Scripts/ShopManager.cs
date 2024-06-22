// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ShopManager : MonoBehaviour
// {
//     public int milkQuantity;
//     public int eggQuantity;
//     public List<Seed> seeds;
//     public List<Vegetable> vegetables;

//     public int milkPrice;
//     public int eggPrice;

//     public int money;
//     public string notification;

//     public void BuySeed(Seed seed, int quantity)
//     {
//         if (money >= seed.price * quantity)
//         {
//             money -= seed.price * quantity;
//             seeds.Find(s => s.name == seed.name).quantity += quantity;
//             notification = "Successful transaction!";
//         }
//         else
//         {
//             notification = "Not enough money!";
//         }
//     }

//     public void SellMilk(int quantity)
//     {
//         if (milkQuantity >= quantity)
//         {
//             money += milkPrice * quanity;
//             milkQuantity -= quantity;
//             notification = "Successful transaction!";
//         }
//         else
//         {
//             notification = "Not enough milk!";
//         }
//     }

//     public void SellVegetable(Vegetable vegetable, int quantity)
//     {
//         if (vegetable.quantity >= quantity)
//         {
//             money += vegetable.price * quantity;
//             vegetables.Find(v => v.name == vegetable.name).quantity -= quantity;
//             notification = "Successful transaction!";
//         }
//         else
//         {
//             notification = "Not enough vegetable!";
//         }
//     }

//     public void SellEgg(int quantity)
//     {
//         if (eggQuantity >= quantity)
//         {
//             money += eggPrice * quantity;
//             eggQuantity -= quantity;
//             notification = "Successful transaction!";
//         }
//         else
//         {
//             notification = "Not enough egg!";
//         }
//     }

// }
