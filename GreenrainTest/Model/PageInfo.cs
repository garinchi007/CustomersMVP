
namespace WindowsFormsApplication1.Model
{
    public class PageInfo<T>
    {
        public PageInfo()
        {
            CurrentPage = 0;
            PageSize = 10;
            PageCount = 0;
            CustomerRecordsCount = 0;
        }

        public PageInfo(int pageSize)
        {
            PageSize = pageSize;
            CurrentPage = 0;
            PageCount = 0;
            CustomerRecordsCount = 0;
        }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int CurrentPage { get; set; }

        public int CustomerRecordsCount { get; set; }

    }
}
