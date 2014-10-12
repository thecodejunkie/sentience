namespace Sentience.Composite
{
    using System;

    /// <summary>
    /// Invokes a randomly selected behavior.
    /// </summary>
    public class Random : BehaviorComposite
    {
        private readonly System.Random random;
        private Behavior current;

        /// <summary>
        /// Initializes a new instance of the <see cref="Random"/> class,
        /// with the provided <paramref name="behaviors"/>.
        /// </summary>
        /// <param name="behaviors">An array of <see cref="Behavior"/> instances.</param>
        protected Random(params Behavior[] behaviors)
            : this(null, behaviors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Random"/> class,
        /// with the provided <paramref name="name"/> and <paramref name="behaviors"/>.
        /// </summary>
        /// <param name="name">The friendly name of the behavior.</param>
        /// <param name="behaviors">An array of <see cref="Behavior"/> instances.</param>
        protected Random(string name, params Behavior[] behaviors)
            : base(name, behaviors)
        {
            this.random =
                new System.Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Invokes behavior specific logic.
        /// </summary>
        /// <param name="context">A <see cref="BehaviorContext"/> instance.</param>
        /// <returns>A <see cref="BehaviorResult"/> enum value that indicates the result of the behavior execution.</returns>
        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            var behavior =
                this.GetBehaviorToInvoke();

            var result =
                behavior.Behave(context);

            this.current = (result == BehaviorResult.Running)
                ? behavior
                : null;

            return result;
        }

        private Behavior GetBehaviorToInvoke()
        {
            if (this.current != null)
            {
                return current;
            }

            var index =
                this.random.Next(this.Behaviors.Length);

            return this.Behaviors[index];
        }
    }
}