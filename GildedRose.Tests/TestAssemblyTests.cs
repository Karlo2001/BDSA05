using Xunit;
using System.Collections.Generic;
using GildedRose.Items;
using static GildedRose.QualityChangeStrategies;
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

        public void Update_GivenOneDayPasses_ReturnsCorrectItemStates()

        {
            var items = _program.Items;
            var checkList = new List<Item>
            {

                new() {Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19},
                new() {QualityChange = AgedBrie, Name = "Aged Brie", SellIn = 1, Quality = 1},
                new() {Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6},

                new() {QualityChange = Legendary, Degrades = false, Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {QualityChange = Legendary, Degrades = false, Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new()
                {
                    QualityChange = BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 14,
                    Quality = 21
                },
                new()
                {
                    QualityChange = BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 50
                },
                new()
                {
                    QualityChange = BackstagePass,
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 4,
                    Quality = 50
                },
                new() {QualityChange = Conjured, Name = "Conjured Mana Cake", SellIn = 2, Quality = 4}
            };
            
            var counter = 0;
            foreach (var item in items)
            {
                item.Update();
                Assert.Equal(checkList[counter].Name, item.Name);
                Assert.Equal(checkList[counter].SellIn, item.SellIn);
                Assert.Equal(checkList[counter].Quality, item.Quality);
                counter++;
            }
        }

        [Fact]
        public void Update_GivenAllSellInBecomesNegative_ReturnsCorrectItemStates()

        {
            var items = _program.Items;

            var checkList = new List<Item>
            {
                new() {Name = "+5 Dexterity Vest", SellIn = -2, Quality = 6},
                new() {Name = "Aged Brie", SellIn = -10, Quality = 22},
                new() {Name = "Elixir of the Mongoose", SellIn = -7, Quality = 0},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new() {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 3,
                    Quality = 41
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -2,
                    Quality = 0
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -7,
                    Quality = 0
                },

                new() {Name = "Conjured Mana Cake", SellIn = -9, Quality = 0}
            };
            for (int i = 0; i < 12; i++)
            {
                foreach (Item item in items)
                {
                    item.Update();
                }
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
        
        [Fact]

        public void Update_GivenConcertSellInHitsZero_ReturnsCorrectQuality()

        {
            var items = _program.Items;
            for (var i = 0; i < 16; i++)
            {
                foreach (Item item in items)
                {
                    item.Update();
                }
            }

            var concertItem = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0
            };
            var actualConcert = items[5];
            Assert.Equal(concertItem.Name, actualConcert.Name);
            Assert.Equal(concertItem.SellIn, actualConcert.SellIn);
            Assert.Equal(concertItem.Quality, actualConcert.Quality);
        }
    }
}