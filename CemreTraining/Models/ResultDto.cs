namespace CemreTraining.Models
{
    public class ResultDto<T>
    {
        public string Draw { get; set; }

        public int RecordsFiltered { get; set; }

        public int RecordsTotal { get; set; }

        public List<T> Data { get; set; }
    }
}
