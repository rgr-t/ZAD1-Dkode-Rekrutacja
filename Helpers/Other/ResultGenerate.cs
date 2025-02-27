using MyApi.Models.Results;

namespace MyApi.Helpers.Other
{
    public static class ResultGenerate
    {
        public static Result Fail(string message) => new Result { Success = false, Message = message };
    }
}
