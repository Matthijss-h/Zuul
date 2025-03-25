using System.Reflection.Metadata.Ecma335;

class Inventory
{
    // fields
    private int maxWeight;
    private Dictionary<string, Item> items;

    // constructor
    public Inventory(int maxWeight)
    {
        this.maxWeight = maxWeight;
        this.items = new Dictionary<string, Item>();
    }

    // methods
    public bool Put(string itemName, Item item)
    {
        // TODO implement:
        // Check the Weight of the Item and check for enough space in the Inventory
        // Does the Item fit?
        // Put Item in the items Dictionary
        // Return true/false for success/failure
        items.Add(itemName, item);

        return false;
    }

    public Item Get(string itemName)
    {
        // TODO implement:
        // Find Item in items Dictionary
        // remove Item from items Dictionary if found
        // return Item or null
        return items[itemName];

        // return null;
    }

    public int TotalWeight()
    {
        int total = 0;
        // TODO implement:
        // loop through the items, and add all the weights
        return total;
    }

    public int FreeWeight()
    {
        // TODO implement:
        // compare MaxWeight and TotalWeight()

        if (TotalWeight() >= maxWeight)
        {
            return 0;
        }

        return maxWeight - TotalWeight();
    }

    public string ShowItems()
    {
        // string itemList = "";

        // foreach (string item in items.Keys)
        // {
        //     itemList += item + ", ";
        // }
    
        // return "Items on da floor: "+ itemList;

        return "Items on da floor: " + string.Join(", ", items.Keys);

    }
}