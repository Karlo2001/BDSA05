using Xunit;
using GildedRose.Console;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private readonly Program _program;

        public TestAssemblyTests()
        {
            _program = new Program();
        }

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [Fact]
        public void UpdateQuality_GivenOneDayPasses_ReturnsCorrectItemStates()
        {
            var items = _program.Items;
            var checkList = new List<Item> {  new() {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                                              new() {Name = "Aged Brie", SellIn = 1, Quality = 1},
                                              new() {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},
                                              new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new()
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 14,
                                                      Quality = 21
                                                  },
                                              new() {Name = "Conjured Mana Cake", SellIn = 1, Quality = 4}};

            _program.UpdateQuality();
            var counter = 0;
            foreach (var item in items)
            {
                Assert.Equal(checkList[counter].Name, item.Name);
                Assert.Equal(checkList[counter].SellIn, item.SellIn);
                Assert.Equal(checkList[counter].Quality, item.Quality);
                counter++;
            }
        }

        [Fact]
        public void UpdateQuality_GivenAllSellInBecomesNegative_ReturnsCorrectItemStates()
        {
            var items = _program.Items;
            var checkList = new List<Item> {new() {Name = "+5 Dexterity Vest", SellIn = -2, Quality = 6},
                                              new() {Name = "Aged Brie", SellIn = -10, Quality = 22},
                                              new() {Name = "Elixir of the Mongoose", SellIn = -7, Quality = 0},
                                              new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new()
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 3,
                                                      Quality = 41
                                                  },
                                              new() {Name = "Conjured Mana Cake", SellIn = -10, Quality = 0}};
            for (var i = 0; i < 12; i++)
            {
                _program.UpdateQuality();
            }
            var counter = 0;
            foreach (var item in items)
            {
                Assert.Equal(checkList[counter].Name, item.Name);
                Assert.Equal(checkList[counter].SellIn, item.SellIn);
                Assert.Equal(checkList[counter].Quality, item.Quality);
                counter++;
            }          
        }
    }
}