class Player
{
    // auto property
    public Room CurrentRoom { get; set; }
    
    // field
    public int health;
    private Inventory backpack;
    // constructor
    public Player()
    {
        CurrentRoom = null;
        health = 100;
        backpack = new Inventory(25); 
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
    }

    public bool IsAlive()
    {
        if (health <= 0)
        {
            return false;
        }
        return true;
    }

    public bool TakeFromChest(string itemName)
    {
        // TODO implement:
        // Remove the Item from the Room
        // Put it in your backpack.
        // Inspect returned values.
        // If the item doesn't fit your backpack, put it back in the chest.
        // Communicate to the user what's happening.
        // Return true/false for success/failure
        
        
        return false;
    }
    public bool DropToChest(string itemName)
    {
        // TODO implement:
        // Remove Item from your inventory.
        // Add the Item to the Room
        // Inspect returned values
        // Communicate to the user what's happening
        // Return true/false for success/failure
        return false;
    }

}