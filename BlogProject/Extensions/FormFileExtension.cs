namespace BlogProject.UI.Extentions
{
    public static class FormFileExtension
    {
        public static async Task<byte[]> ToByteArrayAsync(this IFormFile formFile)
        {
            if (formFile == null) throw new ArgumentNullException(nameof(formFile));
            using MemoryStream memory = new MemoryStream();
            await formFile.CopyToAsync(memory);
            return memory.ToArray();
        }

        public static string ToBase64String(this byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
                return string.Empty;

            return Convert.ToBase64String(byteArray);
        }
        public static IFormFile ToFormFile(
            this byte[] byteArray, 
            string fileName, 
            string contentType,
            string fieldName = "file")
        {
            if (byteArray == null || byteArray.Length == 0)
                return null;

            var stream = new MemoryStream(byteArray);
            IFormFile formFile = new FormFile(stream, 0, byteArray.Length, fieldName, fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return formFile;
        }
        public static TimeSpan CalculateReadingTime(this string content, int wordsPerMinute = 120)
        {
            if (string.IsNullOrEmpty(content))
                return TimeSpan.Zero;

            // Assume average word length = 5 characters
            int wordCount = content.Length / 5;
            int minutes = wordCount / wordsPerMinute;
            return TimeSpan.FromMinutes(minutes < 1 ? 1 : minutes);
        }
    }
}
