namespace TechChallenge.Core.DTO;

public class ReturnTableDto<T> where T : class
{
    public ReturnTableDto()
    {
        List = new List<T>();
    }

    public ReturnTableDto(int totalRegister, int totalRegisterFilter, int totalPages)
    {
        TotalRegister = totalRegister;
        TotalRegisterFilter = totalRegisterFilter;
        TotalPages = totalPages;
        List = new List<T>();
    }



    public int TotalRegister { get; set; }
    public int TotalRegisterFilter { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<T> List { get; set; }

}
