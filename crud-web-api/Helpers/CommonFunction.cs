using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;



namespace LDCC_DOC.Common.Helpers
{
    public static class CommonFunction
    {
        private static readonly Encoding encoding = Encoding.UTF8;
        public static string ComputeHmacSHA256(string plainText, string key)
        {
            using HMACSHA256 hmac = new(encoding.GetBytes(key));
            return Convert.ToHexString(hmac.ComputeHash(encoding.GetBytes(plainText)));
        }

        public static string GenerateRandomString(int length)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Ký tự có thể xuất hiện trong chuỗi
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                char randomChar = chars[index];
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }

        public static string GenerateRandomString(int length, bool v)
        {

            const string chars = "0123456789"; // Ký tự có thể xuất hiện trong chuỗi
            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                char randomChar = chars[index];
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }

        public static string GeneratePrefixFromFileType(string fileExtension)
        {
            string prefix = "other"; // Giá trị mặc định cho các loại tệp không được quy định

            if (!string.IsNullOrEmpty(fileExtension))
            {
                fileExtension = fileExtension.TrimStart('.'); // Loại bỏ dấu chấm nếu có
                switch (fileExtension.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                    case "png":
                    case "gif":
                        prefix = "images";
                        break;
                    case "pdf":
                        prefix = "pdfs";
                        break;
                    case "doc":
                    case "docx":
                    case "txt":
                        prefix = "documents";
                        break;
                    case "mp3":
                    case "wav":
                    case "flac":
                        prefix = "audio";
                        break;
                    case "mp4":
                    case "avi":
                    case "mkv":
                        prefix = "videos";
                        break;
                    case "html":
                        prefix = "html";
                        break;
                    case "md":
                        prefix = "markdown";
                        break;
                        // Thêm các loại tệp khác và tiền tố tương ứng ở đây
                }
            }

            return prefix;
        }

        public static T ConvertJsonToObject<T>(string json)
        {
            var camelSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            try
            {
                var result = JsonConvert.DeserializeObject<T>(json, camelSettings);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }
    }
}
