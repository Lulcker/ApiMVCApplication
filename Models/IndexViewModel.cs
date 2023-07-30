namespace ApiMVCApplication.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; }
        public PagingInfo PagingInfo { get; }

        public IndexViewModel(IEnumerable<User> users, PagingInfo pagingInfo)
        {
            Users = users;
            PagingInfo = pagingInfo;
        }
    }
}
