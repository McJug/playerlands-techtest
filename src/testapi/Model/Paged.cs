namespace Model
{
    public class Paged<T>
    {
        public T[] Data { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
    }
}
