using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentience.Tests.Behaviors
{
    public sealed class PredictableBehavior : Behavior
    {
        private readonly BehaviorResult _result;

        public PredictableBehavior(BehaviorResult result)
        {
            _result = result;
        }

        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            return _result;
        }
    }
}
