namespace WebShoppie.Persistence.Exceptions;

public class EntityNotFoundException(string? message) : Exception(message);
public class OmgCustomerDoesNotExistInDbException(string? message) : EntityNotFoundException(message);
public class OmgOrderDoesNotExistInDbException(string? message) : EntityNotFoundException(message);
public class OmgProductDoesNotExistInDbException(string? message) : EntityNotFoundException(message);