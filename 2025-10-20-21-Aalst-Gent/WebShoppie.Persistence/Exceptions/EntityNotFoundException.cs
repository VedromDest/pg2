namespace WebShoppie.Persistence.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int? id = null, string? message = null) 
            : base (message ?? $"Entity with id '{(id.HasValue ? id.ToString() : "unknown")}' not found.") { }
    }

    public class CustomerNotFoundException : EntityNotFoundException 
    {
        public CustomerNotFoundException(): base() { }
        public CustomerNotFoundException(int id) : base(id: null, message: $"Customer Entity '{id}' not found.") { }
        public CustomerNotFoundException(int id, string message) : base(id, message) { }
    }

    public class ProductNotFoundException : EntityNotFoundException
    {
        public ProductNotFoundException() : base() { }
        public ProductNotFoundException(int id) : base(id: null, message: $"Product Entity '{id}' not found.") { }
        public ProductNotFoundException(int id, string message) : base(id, message) { }
    }
}
