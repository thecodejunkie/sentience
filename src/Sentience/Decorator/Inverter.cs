namespace Sentience.Decorator
{
    /// <summary>
    /// Inverts the result of a <see cref="Behavior"/>.
    /// </summary>
    public class Inverter : Behavior
    {
        private readonly Behavior behavior;

        /// <summary>
        /// Creates an instance of the <see cref="Inverter"/> class, using the
        /// provided <paramref name="behavior"/>.
        /// </summary>
        /// <param name="behavior">The <see cref="Behavior"/> instance to decorate.</param>
        public Inverter(Behavior behavior)
        {
            this.behavior = behavior;
        }

        /// <summary>
        /// Invokes behavior specific logic.
        /// </summary>
        /// <param name="context">A <see cref="BehaviorContext"/> instance.</param>
        /// <returns>A <see cref="BehaviorResult"/> enum value that indicates the result of the behavior execution.</returns>
        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            var result =
                this.behavior.Behave(context);

            if (result == BehaviorResult.Running)
            {
                return BehaviorResult.Running;
            }

            return (result == BehaviorResult.Success)
                ? BehaviorResult.Failure
                : BehaviorResult.Success;
        }
    }
}