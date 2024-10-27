

namespace Wep_Page_Calssifier.Services.Home.Implementation
{
    public class ContentReaderFile 
    {
        IFormFile _file;

        public ContentReaderFile(IFormFile file)
        {
            _file = file;
        }


        public async Task<string> ReadContent()
        {

            string fileContent;

            if (_file != null && _file.Length > 0)
            {

                using (var reader = new StreamReader(_file.OpenReadStream()))
                {
                    fileContent = reader.ReadToEnd();


                }

                return fileContent;

            }
            else
            {
                return "FIFLE  NOT UPLOADED";
            }



        }
    }
}
