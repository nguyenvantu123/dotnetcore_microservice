namespace Actio.Common.Event {
    public class UserAuthenticated : IEvents {
        public UserAuthenticated (string name) {
            this.Name = name;

        }
        public UserAuthenticated () {

        }
        public string Name { get; set; }
    }
}