namespace PayProcessor.App {
    public class Employee {
        private readonly string _name;

        public Employee(string name) {
            _name = name;
        }

        public IPayMaster PayMaster { get; set; }
        public HourlyPayType PayType { get; set; }
    }
}