using System.Collections.Generic;

namespace PayProcessor.App {
    public interface IPayMaster {
        List<Check> HeldPayChecks { get; }
    }
}