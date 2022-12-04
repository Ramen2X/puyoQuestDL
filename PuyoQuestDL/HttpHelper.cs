namespace puyoQuestDL.PuyoQuestDL
{
    // Class derived from https://dev.to/1001binary/download-file-using-httpclient-wrapper-asynchronously-1p6
    public static class HttpHelper
    {
        private static readonly HttpClient _httpClient = new();

        public static async Task DownloadFileAsync(string uri, string outputPath)
        {
            Console.WriteLine("Downloading " + uri);

            if (!Uri.TryCreate(uri, UriKind.Absolute, out Uri uriResult))
                throw new InvalidOperationException("URL is invalid.");

            byte[] fileBytes = await _httpClient.GetByteArrayAsync(uri);
            File.WriteAllBytes(outputPath, fileBytes);
        }
    }
}

