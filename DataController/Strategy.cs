using System;

// Discount strategy interface
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal amount);
}

// Discount strategy for students
public class StudentDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        decimal discountPercentage = 0.2m; // 20% discount for students
        return amount - (amount * discountPercentage);
    }
}

// Discount strategy for veterans
public class VeteranDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        decimal discountPercentage = 0.15m; // 15% discount for veterans
        return amount - (amount * discountPercentage);
    }
}

// Discount strategy for persons with disabilities
public class DisabilityDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        decimal discountPercentage = 0.1m; // 10% discount for persons with disabilities
        return amount - (amount * discountPercentage);
    }
}

// Discount strategy for children
public class ChildrenDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount)
    {
        decimal discountPercentage = 0.25m; // 25% discount for children
        return amount - (amount * discountPercentage);
    }
}

// Context class that applies the discount strategy
public class DiscountContext
{
    private IDiscountStrategy discountStrategy;

    public void SetDiscountStrategy(IDiscountStrategy strategy)
    {
        discountStrategy = strategy;
    }

    public decimal ApplyDiscount(decimal amount)
    {
        if (discountStrategy == null)
        {
            throw new InvalidOperationException("Discount strategy not set.");
        }

        return discountStrategy.ApplyDiscount(amount);
    }
}
