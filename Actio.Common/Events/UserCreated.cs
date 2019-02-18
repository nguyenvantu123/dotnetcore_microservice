namespace Actio.Common.Event {
    public class UserCreated : IEvents {
        public UserCreated (string email, string name) {
            this.Email = email;
            this.Name = name;

        }
        public UserCreated () {

        }
        public string Email { get; set; }

        public string Name { get; set; }
    }
}