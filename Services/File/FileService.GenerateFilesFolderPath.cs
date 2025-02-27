namespace MyApi.Services.File
{
    public partial class FileService
    {
        //Generating neutral file path that in user environment folder.
        public string GenerateFilesFolderPath()
        {
            string homePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string filesFolderPath = Path.Combine(homePath, _saveFolder);

            return filesFolderPath;
        }
    }
}
