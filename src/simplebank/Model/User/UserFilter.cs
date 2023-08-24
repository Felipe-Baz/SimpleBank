namespace simplebank.Model
{
    public class UserFilter
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        public string PhoneNumber { get; set; }

        public string OrderBy { get; set; } = "email";

        public string SortBy { get; set; } = "asc";
    }
}