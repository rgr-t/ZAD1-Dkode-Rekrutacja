using MyApi.Models.Results;

namespace MyApi.Services.Download
{
    public partial class FileService
    {
        public async Task<FileDownloadResult> Download(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    byte[]? file = await httpClient.GetByteArrayAsync(url);

                    if (file != null && file.Length > 0)
                        return new FileDownloadResult() { Success = true, Message = "Successfuly downloaded file from url: \"{url}\"", File = file, FileSize = file.Length };
                }  
                catch(HttpRequestException ex)
                {

                    // log
                }
                catch(Exception ex)
                {
                    // log
                };                
            }

            return new FileDownloadResult() { Success = false, Message = $"Failed to download file from url: \"{url}\"" };
        }
    }
}
