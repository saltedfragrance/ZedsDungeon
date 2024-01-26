using Pre.Pe2.Cons.DataRepositories;
using Pre.Pe2.Cons.Entities;
using Pre.Pre.Core.Enums;
using Pre.Pre.Core.GameProps;
using Pre.Pre.Core.GameProps.Wearables;
using Pre.Pre.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Pe2.Cons.GameProps
{
    internal class Inventory
    {
        internal List<Item> Items { get; set; }

        internal List<string> ItemCategories { get; set; }

        internal List<string> InventoryLog { get; set; }

        internal Inventory()
        {
            ItemCategories = new List<string>();
        }

        internal void AppendInventoryLogItem(string error = null, Item item = null)
        {
            if (InventoryLog.Count > 3) InventoryLog.Clear();

            if (error == null)
            {
                if (item is HealthPotion) InventoryLog.Add($"You've consumed a {item.Name}! You have restored your health by {item.StatsBonus} points.");
                else if (item is ArmorRepairStone) InventoryLog.Add($"You've used a {item.Name}! You have restored your armor by {item.StatsBonus} points.");
                else if (item is Weapon) InventoryLog.Add($"You've equiped a {item.Name}! You have upgraded your attack power with {item.StatsBonus} points.");
                else if (item is Armor) InventoryLog.Add($"You've equiped a {item.Name}! You have upgraded your defence power with {item.StatsBonus} points.");
                else if (item is ResurrectPotion) InventoryLog.Add($"Your ghost drank this ethereal potion, so your earthly form has come back into existence!");
            }
            else InventoryLog.Add(error);
        }

        internal void ShowInventory(Inventory inventory)
        {
            int id = 1;

            ItemCategories.Clear();

            foreach (var category in inventory.Items.GroupBy(i => i.Name)
                                                                   .Select(c => new
                                                                   {
                                                                       ItemName = c.Key,
                                                                       Count = c.Count()
                                                                   }).OrderBy(x => x.ItemName))
            {
                Item item = Items.Find(i => i.Name == category.ItemName);
                Console.WriteLine($"[{id}]{category.ItemName} (Amount: {category.Count}) - {item.Description}");
                ItemCategories.Add(id++ + category.ItemName);
            }
        }
    }
}
