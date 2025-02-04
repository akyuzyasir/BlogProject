namespace BlogProject.Domain.Utilities.Interfaces;

public interface IResult
{
    // IResult interface created for the result of the operations. 
    // The reason we don't use set is that we don't want to change the value of the properties after the object is created.
    public bool IsSuccess { get; }
    public string Message { get; }
}
