namespace Sentience
{
    /// <summary>
    /// Defines the base functionality of a behavior.
    /// </summary>
    public abstract class Behavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Behave"/> class.
        /// </summary>
        /// <remarks>The type name of the behavior will be used as the friendly name.</remarks>
        protected Behavior()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Behave"/> class, with
        /// the provided <paramref name="name"/>.
        /// </summary>
        /// <param name="name">A <see cref="string"/> containing a friendly name of the behavior.</param>
        /// <remarks>The the <paramref name="name"/> is <see langword="null" />, then the type name of the behavior will be used as the friendly name.</remarks>
        protected Behavior(string name)
        {
            this.Name = name ?? this.GetType().Name;
        }

        /// <summary>
        /// Gets or sets the friendly name of the behavior.
        /// </summary>
        /// <value>A <see cref="string"/> containing the friendly name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Invokes the behavior.
        /// </summary>
        /// <param name="context">A <see cref="BehaviorContext"/> instance.</param>
        /// <returns>A <see cref="BehaviorResult"/> enum value that indicates the result of the behavior execution.</returns>
        /// <remarks>By default, this will invoke <see cref="OnBehave"/> and return the result. All exception will be caught and returned as <see cref="BehaviorResult.Failure"/>.</remarks>
        public virtual BehaviorResult Behave(BehaviorContext context)
        {
            BehaviorResult result;

            try
            {
                result = this.OnBehave(context);
            }
            catch
            {
                result = BehaviorResult.Failure;
            }

            return result;
        }

        /// <summary>
        /// Invokes behavior specific logic.
        /// </summary>
        /// <param name="context">A <see cref="BehaviorContext"/> instance.</param>
        /// <returns>A <see cref="BehaviorResult"/> enum value that indicates the result of the behavior execution.</returns>
        public abstract BehaviorResult OnBehave(BehaviorContext context);
    }
}