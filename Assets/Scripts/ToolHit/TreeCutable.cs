
using UnityEngine;

public class TreeCutable : ToolHit
{
   [SerializeField] GameObject pickUpDrop;

   [SerializeField] float spread = 0.7f;

   [SerializeField] Item item;
   [SerializeField] int dropcount = 5;
   [SerializeField] int itemcountInOneDrop = 5;
   public override void Hit()
   {
      while (dropcount > 0)
      {
         dropcount -= 1;

         Vector3 position = transform.position;
         position.x += spread * Random.value - spread / 2;
         position.y += spread * Random.value - spread / 2;
         
         ItemSpawnManager.instance.SpawnItem(position,item,itemcountInOneDrop);
      }

      Destroy(gameObject);
   }
}
