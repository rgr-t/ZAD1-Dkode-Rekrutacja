namespace MyApi.Models.Results.File
{
    public class FileDownloadResult : Result
    {
        public long FileSize { get; set; }
        public byte[] File { get; set; }
    }
}
