using System;

namespace GildedRose
{
    public static class QualityChangeStrategies
    {
        public static readonly Func<int, int, int> NormalQuality = (s, q) => 
            Math.Max(-1 * (s <= 0 ? 2 : 1), 0-q);
        public static readonly Func<int, int, int> AgedBrie = (s, q) =>
            Math.Min(1 * (s <= 0 ? 2 : 1), 50 - q);
        public static readonly Func<int, int, int> Legendary = (_, _) => 0;
        public static readonly Func<int, int, int> BackstagePass = (s, q) =>
            s <= 0 ? -q : Math.Min(1 + (s < 11 ? 1 : 0) + (s < 6 ? 1 : 0), 50-q);
        public static readonly Func<int, int, int> Conjured = (s, q) => 
            Math.Max(-2 * (s <= 0 ? 2 : 1), 0-q);
    }
}