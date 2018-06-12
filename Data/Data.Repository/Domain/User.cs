

using System;

namespace Data.Repository.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime HangedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
