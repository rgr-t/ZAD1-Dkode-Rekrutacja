namespace MyApi.Services.File
{
    public partial class FileService
    {
        public string GenerateFilesFolderPath()
        {
            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filesFolderPath = Path.Combine(homePath, _saveFolder);

            return filesFolderPath;
        }
    }
}
