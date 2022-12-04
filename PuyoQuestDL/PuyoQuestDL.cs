using System.Text;
using System.Text.Json;

namespace puyoQuestDL.PuyoQuestDL
{
    class PuyoQuestDL
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: puyoQuestDL load_data.json [output directory]");
                return;
            }

            string jsonF = args[0];
            string outDir = args[1];

            string json;

            using (StreamReader r = new(jsonF))
                json = r.ReadToEnd();

            LoadData loadData = JsonSerializer.Deserialize<LoadData>(json);

            StringBuilder sb = new();

            string url;
            string fileName;
            for (int i = 0; i < loadData.master_data_map.master_archive_data_array.Length; i++)
            {
                url = loadData.master_data_map.master_archive_data_array[i].archive_url;

                fileName = url.Replace("https://pyq-cf-dl.sega-net.jp/", string.Empty);

                sb.Clear();

                sb.Append(outDir);
                sb.Append('\\');
                sb.Append(fileName);

                await HttpHelper.DownloadFileAsync(url, sb.ToString());
            }

            Console.WriteLine("\nDone!");
        }
    }
}