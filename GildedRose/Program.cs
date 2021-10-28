using System.Collections.Generic;
using System;
using GildedRose.Items;
using static GildedRose.QualityChangeStrategies;

namespace GildedRose
{
    public class Program
    {
        public IList<Item> Items { get; }

        public Program()
        {
            
            Items = new List<Item>
            {
                new() {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new() {QualityChange = AgedBrie, Name = "Aged Brie", SellIn = 2, Quality = 0},
                new() {QualityChange = NormalQuality, Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new() {QualityChange = Legendary, Degrades = false, Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {QualityChange = Legendary, Degrades = false, Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new()
                {
                    QualityChange = BackstagePass, 
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new()
                {
                    QualityChange = BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new()
                {
                    QualityChange = BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },

                new() {QualityChange = Conjured, Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var program = new Program();

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < program.Items.Count; j++)
                {
                    Console.WriteLine(program.Items[j].Name + ", " + program.Items[j].SellIn + ", " + program.Items[j].Quality);
                }
                Console.WriteLine("");
                foreach (Item item in program.Items)
                {
                    item.Update();
                }
            }
        }
    }
}