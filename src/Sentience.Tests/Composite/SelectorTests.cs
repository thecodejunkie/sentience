namespace Sentience.Tests.Composite
{
    using Sentience.Composite;
    using Sentience.Tests.Behaviors;
    using Xunit;
    using Xunit.Extensions;

    public sealed class SelectorTests
    {
        public sealed class TheOnBehaveMethod
        {
            [Fact]
            public void Should_Return_Failure_If_Selector_Have_No_Attached_Behaviors()
            {
                // Given
                var context = new BehaviorContext();
                var selector = new Selector();

                // When
                var result = selector.OnBehave(context);

                // Then
                Assert.Equal(BehaviorResult.Failure, result);
            }

            [Theory]
            [InlineData(BehaviorResult.Success)]
            [InlineData(BehaviorResult.Running)]
            public void Should_Return_Result_If_Any_Behavior_Returns_Anything_Other_Than_Failure(BehaviorResult expected)
            {
                // Given
                var context = new BehaviorContext();
                var selector = new Selector(
                    new PredictableBehavior(BehaviorResult.Failure),
                    new PredictableBehavior(expected));

                // When
                var result = selector.OnBehave(context);

                // Then
                Assert.Equal(expected, result);
            }
        }
    }
}
