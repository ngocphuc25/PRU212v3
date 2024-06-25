
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

        public Item item;
        public int count =1;
    private void Awake()
    {
        player = PickUpController.instance.player.transform;
    
    }
    private void Update()
    {
        ttl -=  Time.deltaTime;
        if(ttl<0) {Destroy(gameObject);}
        float distance = UnityEngine.Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = UnityEngine.Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime);


        if (distance < 0.1f)
        { 
            if(PickUpController.instance.inventoyContainer!= null)
            {
                    PickUpController.instance.inventoyContainer.Add(item,count);
            }
            else
            {
                Debug.LogWarning("No invetory container attached to the game manager");
            }
            Destroy(gameObject);
        }
    }
}