namespace Sentience.Tests.Decorator
{
    using Sentience.Decorator;
    using Sentience.Tests.Behaviors;
    using Xunit;
    using Xunit.Extensions;

    public sealed class InverterTests
    {
        public sealed class TheOnBehaveMethod
        {
            [Theory]
            [InlineData(BehaviorResult.Running, BehaviorResult.Running)]
            [InlineData(BehaviorResult.Success, BehaviorResult.Failure)]
            [InlineData(BehaviorResult.Failure, BehaviorResult.Success)]
            public void Should_Return_Expected_Result_Depending_On_Behaviors_Result(BehaviorResult state, BehaviorResult expected)
            {
                // Given
                var context = new BehaviorContext();
                var selector = new Inverter(new PredictableBehavior(state));

                // When
                var result = selector.OnBehave(context);

                // Then
                Assert.Equal(expected, result);
            }
        }
    }
}
