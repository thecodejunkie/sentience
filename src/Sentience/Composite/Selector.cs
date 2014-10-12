namespace Sentience.Composite
{
    /// <summary>
    /// Invokes all behaviors, in order, until one of them returns <see cref="BehaviorResult.Success"/>.
    /// If all behaviors fail, then <see cref="BehaviorResult.Failure"/> will be returned.
    /// </summary>
    public class Selector : BehaviorComposite
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class,
        /// with the provided <paramref name="behaviors"/>.
        /// </summary>
        /// <param name="behaviors">An array of <see cref="Behavior"/> instances.</param>
        public Selector(params Behavior[] behaviors)
            : this(null, behaviors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class,
        /// with the provided <paramref name="name"/> and <paramref name="behaviors"/>.
        /// </summary>
        /// <param name="name">The friendly name of the behavior.</param>
        /// <param name="behaviors">An array of <see cref="Behavior"/> instances.</param>
        public Selector(string name, params Behavior[] behaviors)
            : base(name)
        {
            this.Behaviors = behaviors;
        }

        /// <summary>
        /// Invokes behavior specific logic.
        /// </summary>
        /// <param name="context">A <see cref="BehaviorContext"/> instance.</param>
        /// <returns>A <see cref="BehaviorResult"/> enum value that indicates the result of the behavior execution.</returns>
        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            foreach (var behavior in this.Behaviors)
            {
                var result =
                    behavior.Behave(context);

                if (result == BehaviorResult.Running)
                {
                    return BehaviorResult.Running;
                }

                if (result == BehaviorResult.Success)
                {
                    return BehaviorResult.Success;
                }
            }

            return BehaviorResult.Failure;
        }
    }
}