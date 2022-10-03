using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.ViewModels {
    public class GetStateViewModel {
        private int v1;
        private object id;
        private string v2;
        private string v3;
        private object initials;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public virtual List<string> Cities { get; set; }

        public GetStateViewModel(int id, object id2, object id1, string name, string intials) {
            Id = id;
            Name = name;
            Initials = intials;
            Cities = new List<string>();
        }

        public GetStateViewModel(object id, string name, string initials)
        {
        }

        public GetStateViewModel(int v1, object id, string v2, string name, string v3, object initials)
        {
            this.v1 = v1;
            this.id = id;
            this.v2 = v2;
            Name = name;
            this.v3 = v3;
            this.initials = initials;
        }
    }
}
