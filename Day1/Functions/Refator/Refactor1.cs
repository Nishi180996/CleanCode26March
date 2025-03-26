using System;

public class OrderProcessor
{
    private const decimal TaxRate = 0.1m;
    private const decimal PremiumDiscountRate = 0.9m;

    private readonly IEmailService _emailService;
    private readonly IAppDbContext _dbContext;

    public OrderProcessor(IEmailService emailService, IAppDbContext dbContext)
    {
        _emailService = emailService;
        _dbContext = dbContext;
    }

    public void ProcessOrder(Order order)
    {
        ValidateOrder(order);
        decimal total = CalculateOrderTotal(order);
        SaveToDatabase(order, total);
        SendConfirmationEmail(order, total);
    }

    private void ValidateOrder(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order), "Order cannot be null.");
        if (order.Items == null || order.Items.Count == 0) throw new InvalidOperationException("Order must have at least one item.");
    }

    private decimal CalculateOrderTotal(Order order)
    {
        decimal total = 0;

        foreach (var item in order.Items)
        {
            total += item.Price * item.Quantity;

            if (item.IsTaxable)
            {
                total += CalculateTax(item);
            }
        }

        if (order.Customer.IsPremium)
        {
            total *= PremiumDiscountRate;
        }
        return total;
    }

    private decimal CalculateTax(OrderItem item)
    {
        return item.Price * TaxRate;
    }

    private void SaveToDatabase(Order order, decimal total)
    {
        order.Total = total;
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
    }

    private void SendConfirmationEmail(Order order, decimal total)
    {
        string subject = "Order Confirmed";
        string body = $"Thank you for your order! The total is: ${total}";
        _emailService.Send(order.Customer.Email, subject, body);
    }
}