using System;

namespace Actio.Common.Event {
    public class ActivityCreated : IAuthenticatedEvents {

        public ActivityCreated (Guid id, string category, string name, string description, DateTime createAt, Guid userId) {
            this.Id = id;
            this.Category = category;
            this.Name = name;
            this.Description = description;
            this.CreateAt = createAt;
            this.UserId = userId;

        }
        public Guid Id { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateAt { get; set; }

        public Guid UserId { get; set; }
    }
}