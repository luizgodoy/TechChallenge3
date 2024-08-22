namespace TechChallenge.Core.DTO;

public class ReturnApiDto<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }
}
