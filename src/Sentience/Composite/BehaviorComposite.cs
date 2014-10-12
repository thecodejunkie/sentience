namespace Sentience.Composite
{
    /// <summary>
    /// Defined the base functionality of a composite behavior.
    /// </summary>
    public abstract class BehaviorComposite : Behavior
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorComposite"/> class,
        /// with the provided <paramref name="behaviors"/>.
        /// </summary>
        /// <param name="behaviors">An array of <see cref="Behavior"/> instances.</param>
        protected BehaviorComposite(params Behavior[] behaviors)
            : this(null, behaviors)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorComposite"/> class,
        /// with the provided <paramref name="name"/> and <paramref name="behaviors"/>.
        /// </summary>
        /// <param name="name">The friendly name of the behavior.</param>
        /// <param name="behaviors">An array of <see cref="Behavior"/> instances.</param>
        protected BehaviorComposite(string name, params Behavior[] behaviors)
            : base(name)
        {
            this.Behaviors = behaviors;
        }

        /// <summary>
        /// Gets or sets the behaviors of the composite.
        /// </summary>
        /// <value>An array of <see cref="Behavior"/> instances.</value>
        public Behavior[] Behaviors { get; set; }
    }
}