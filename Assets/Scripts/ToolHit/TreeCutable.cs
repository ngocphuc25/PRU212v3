
using UnityEngine;

public class TreeCutable : ToolHit
{
   [SerializeField] GameObject pickUpDrop;
   [SerializeField] int dropcount =5;
   [SerializeField] float spread =0.7f; 
   public override void Hit(){
    while(dropcount>0){
      dropcount-= 1;
  
   Vector3 position = transform.position;
   position.x += spread * Random.value- spread/2;
   position.y += spread * Random.value- spread/2;
   GameObject go = Instantiate(pickUpDrop);
   go.transform.position = position;
    }
    
    Destroy(gameObject);
   }
}
