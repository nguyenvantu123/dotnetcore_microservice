using System;

namespace Actio.Common.Command {
    public class CreateActivity : IAuthentication {

        public CreateActivity (Guid id, Guid userId, string name, string category, string description, DateTime createAt) {
            this.Id = id;
            this.UserId = userId;
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.CreateAt = createAt;

        }

        public CreateActivity () { }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public DateTime CreateAt { get; set; }
    }
}