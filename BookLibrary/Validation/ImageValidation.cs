using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Validation
{
    public class ImageValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            IFormFile file = value as IFormFile;

            int maxLength = 1024 * 1024 * 3;
            string[] fileType = { ".jpg", ".gif", ".png", "jpeg" };

            //Check if file is null
            if (file == null)
            {
                ErrorMessage = "Please upload a file";
                return false;
            }
            //Check if the file is correct file type
            if (!fileType.Contains(Path.GetExtension(file.FileName)))
            {
                ErrorMessage = $"Not an Image File. Please upload {string.Join(",", fileType)}";
                return false;
            }
            //Check if the image size is valid
            if (file.Length > maxLength)
            {
                ErrorMessage = $"File is too large, max size {maxLength / 1024}kb";
                return false;
            }
            return true;
        }
    }
}
