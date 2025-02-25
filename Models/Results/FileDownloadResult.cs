namespace MyApi.Models.Results
{
    public class FileDownloadResult : Result
    {       
        public long FileSize { get; set; }
        public byte[]? File { get; set; }
    }
}
