using System;

class PriceCalculator
{
    public decimal PricePerDay { get; set; }
    public int DaysCount { get; set; }
    public SeasonsPrice Season { get; set; }
    public Discount DiscountType { get; set; }

    public PriceCalculator(decimal pricePerDay, int daysCount, SeasonsPrice season, Discount discountType)
    {
        PricePerDay = pricePerDay;
        DaysCount = daysCount;
        Season = season;
        DiscountType = discountType;
    }

    public void Calculate(Action<string> print)
    {
        int season = (int)Season;
        decimal discount = (100 - (decimal)DiscountType) / 100.0m;

        decimal totalPrice = (PricePerDay * DaysCount * season) * discount;

        print($"{totalPrice:f2}");
    }
}