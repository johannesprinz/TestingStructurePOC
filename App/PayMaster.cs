using System.Collections.Generic;

namespace PayProcessor.App {
    public class PayMaster : IPayMaster {
        public List<Check> HeldPayChecks { get; private set; }

        public PayMaster() {
            HeldPayChecks = new List<Check>();
        }
    }
}