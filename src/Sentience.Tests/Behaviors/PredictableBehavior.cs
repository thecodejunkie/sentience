namespace Sentience.Tests.Behaviors
{
    public sealed class PredictableBehavior : Behavior
    {
        private readonly BehaviorResult result;

        public PredictableBehavior(BehaviorResult result)
        {
            this.result = result;
        }

        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            return this.result;
        }
    }
}
