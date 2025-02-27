using MyApi.Models.Results.File;

namespace MyApi.Services.File
{
    public partial class FileService
    {
        //File download method using url.
        public async Task<FileDownloadResult> Download(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    byte[]? file = await httpClient.GetByteArrayAsync(url);

                    if (file != null && file.Length > 0)
                        return new FileDownloadResult() { Success = true, Message = $"Successfuly downloaded file from url: \"{url}\".", File = file, FileSize = file.Length };
                }  
                catch(HttpRequestException ex)
                {
                    return new FileDownloadResult() { Success = false, Message = $"Http request error, {ex.Message}" };
                }
                catch(Exception ex)
                {
                    return new FileDownloadResult() { Success = false, Message = $"Unexpected error: {ex.Message}" };
                }

                return new FileDownloadResult() { Success = false, Message = $"Failed to download file from url: \"{url}\". " };
            }
        }
    }
}
