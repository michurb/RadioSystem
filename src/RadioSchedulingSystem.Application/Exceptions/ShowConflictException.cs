namespace RadioSchedulingSystem.Application.Exceptions;

public class ShowConflictException : Exception
{
    public ShowConflictException(string message)
        : base(message)
    {
    }
}