using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void ItemsAfterOneUpdateReturnsCorrectValues()
        {
            var items = new List<Item>() {    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 6}};

            var checkList = new List<Item>() {new Item {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                                              new Item {Name = "Aged Brie", SellIn = 1, Quality = 1},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 14,
                                                      Quality = 21
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 1, Quality = 4}};

            Program.SetItems(items);
            Program.UpdateQuality();
            var counter = 0;
            foreach (var item in Program.Items)
            {
                Assert.Equal(checkList[counter].Name, item.Name);
                Assert.Equal(checkList[counter].SellIn, item.SellIn);
                Assert.Equal(checkList[counter].Quality, item.Quality);
                counter++;
            }
        }

        [Fact]
        public void ItemsQualityAfterAllSellInIsUnderZeroReturnRightQuality()
        {
            var items = new List<Item>() {    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 2, Quality = 6}};
            
            var checkList = new List<Item>() {new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 19},
                                              new Item {Name = "Aged Brie", SellIn = 0, Quality = 1},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 6},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 0,
                                                      Quality = 21
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 4}};
            Program.SetItems(items);
            for (int i = 0; i < 20; i++)
            {
                Program.UpdateQuality();
            }
            var counter = 0;
            foreach (var item in Program.Items)
            {
                Assert.Equal(checkList[counter].Name, item.Name);
                Assert.Equal(checkList[counter].SellIn, item.SellIn);
                Assert.Equal(checkList[counter].Quality, item.Quality);
                counter++;
            }          
        }
    }
}