namespace drawboard.ApiModels
{
    public class UserCard
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Permissions { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string DateJoined { get; set; }
        public string Phone { get; set; }
        public string UserAlias { get; set; }
        public string ActivationId { get; set; }
        public bool IsOptInForCommunication { get; set; }
        public bool AccountActivated { get; set; }

        public override string ToString()
        {
            return $"{Title} {FirstName} {LastName}";
        }
    }
}
