class Player
{
    // auto property
    public Room CurrentRoom { get; set; }
    
    // field
    public int health;
    // constructor
    public Player()
    {
        CurrentRoom = null;
        health = 100;
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    public void Heal(int heal)
    {
        health += heal;
    }

    public void IsAlive()
    {
        if (health <= 0)
        {
            Console.WriteLine("You have died.");
            Console.WriteLine("Game Over.");
            Environment.Exit(0);
        }
    }


}