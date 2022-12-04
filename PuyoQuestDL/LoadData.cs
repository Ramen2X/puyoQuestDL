using System.Text.Json.Serialization;

namespace puyoQuestDL.PuyoQuestDL
{
    public class MasterDataMap
    {
        public MasterArchiveData[] master_archive_data_array { get; set; }
    }

    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public class MasterArchiveData
    {
        public sbyte download_type { get; set; }
        public string archive_url { get; set; }
        public long check_sum { get; set; }
        public long archive_size { get; set; }
        public int archive_id { get; set; }
    }

    public class LoadData
    {
        public MasterDataMap master_data_map { get; set; }
    }
}
