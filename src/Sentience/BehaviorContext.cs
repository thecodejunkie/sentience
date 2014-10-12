namespace Sentience
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a context which is passed between executing behaviors.
    /// </summary>
    public class BehaviorContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BehaviorContext"/> class.
        /// </summary>
        public BehaviorContext()
        {
            this.State =
                new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets or sets the shared state of the context.
        /// </summary>
        /// <value>A <see cref="IDictionary{TKey,TValue}"/> instance that contains the shared state.</value>
        public IDictionary<string, object> State { get; set; }
    }
}