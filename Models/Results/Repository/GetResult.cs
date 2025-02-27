namespace MyApi.Models.Results.Repository
{
    public class GetResult<T> : Result
    {
        public IEnumerable<T> Data { get; set; }
    }
}