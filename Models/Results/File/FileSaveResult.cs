namespace MyApi.Models.Results.File
{
    public class FileSaveResult : Result
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
    }
}
