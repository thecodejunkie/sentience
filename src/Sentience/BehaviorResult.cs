namespace Sentience
{
    /// <summary>
    /// The possible results from a behavior.
    /// </summary>
    public enum BehaviorResult
    {
        /// <summary>
        /// Signals that the behavior failed to complete.
        /// </summary>
        Failure,

        /// <summary>
        /// Signals that the behavior is still being executed.
        /// </summary>
        Running,

        /// <summary>
        /// Signals that the behavior successfully completed.
        /// </summary>
        Success
    }
}