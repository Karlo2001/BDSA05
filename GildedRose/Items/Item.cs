using System;
using static GildedRose.QualityChangeStrategies;


namespace GildedRose.Items
{
    public class Item 
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        
        public Func<int, int, int> QualityChange { private get; init; } = NormalQuality;
        public bool Degrades { private get; init; } = true;

        public void Update()
        {
            Quality += QualityChange(SellIn, Quality);
            SellIn -= Degrades? 1 : 0;
        }
    }
}