using FluentValidation;

var myCustomer = new Customer();
var validator = new CustomerValidator();
var result = validator.Validate(myCustomer);

Console.WriteLine(result.IsValid);

public class Customer 
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Forename { get; set; }
    public decimal Discount { get; set; }
    public string Address { get; set; }
}


public class CustomerValidator : AbstractValidator<Customer> 
{
    public CustomerValidator()
    {
        RuleFor(customer => customer.Surname).NotNull();
        RuleFor(customer => customer.Forename).NotNull();
    }
}