using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up item. " + item.name);

        bool isPickedUp = Inventory.instance.Add(item);
        
        if(isPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
