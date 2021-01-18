namespace Acme.IssueManagement.Samples
{
    public class ContentDto
    {
        public ContentDto(IdClass id, UserIdClass userid, TitleClass title, IsCompletedClass iscompleted)
        {
            this.Id = id;
            this.UserId = userid;
            this.Title = title;
            this.IsCompleted = iscompleted;
        }

        public IdClass Id { get; set; }
        public UserIdClass UserId { get; set; }
        public TitleClass Title { get; set; }
        public IsCompletedClass IsCompleted { get; set; }

        public class IdClass
        {
            public IdClass(int iv)
            {
                this.iv = iv;
            }
            public int iv { get; set; }
        }
        public class UserIdClass
        {
            public UserIdClass(int iv)
            {
                this.iv = iv;
            }
            public int iv { get; set; }
        }
        public class TitleClass
        {
            public TitleClass(string iv)
            {
                this.iv = iv;
            }
            public string iv { get; set; }
        }
        public class IsCompletedClass
        {
            public IsCompletedClass(bool iv)
            {
                this.iv = iv;
            }
            public bool iv
            {
                get; set;
            }
        }
    }
}