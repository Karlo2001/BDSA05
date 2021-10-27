using System.Collections.Generic;
using System;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items { get; }

        public Program()
        {
            Items = new List<Item> {
                new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new() {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new() {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new() {Name = "Conjured Mana Cake", SellIn = 2, Quality = 6}
            };
        }
        
        static void Main(string[] args)
        {
            var program = new Program();
            
            for (var i = 0; i < 12; i++)
            {
                program.UpdateQuality();
                foreach (var item in program.Items)
                {
                    System.Console.Write($"{item.Name}: {item.Quality} ");
                }

                System.Console.WriteLine();
            }
        }
        
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            if (Items[i].Name.StartsWith("Conjured"))
                            {
                                Items[i].Quality = Items[i].Quality - 2;
                            }
                            else
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}