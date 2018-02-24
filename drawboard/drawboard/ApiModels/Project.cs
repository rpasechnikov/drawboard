using System;

namespace drawboard.ApiModels
{
    /// <summary>
    /// Response that will be recieved post GET call to <see cref="App.API_PREFIX"/>project/my in
    /// a collection
    /// </summary>
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string Permissions { get; set; }
        public UserCard Owner { get; set; }
        public DateTime? DeletedOn { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
