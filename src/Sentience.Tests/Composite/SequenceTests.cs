namespace Sentience.Tests.Composite
{
    using Behaviors;
    using Sentience.Composite;
    using Xunit;

    public sealed class SequenceTests
    {
        public sealed class TheOnBehaveMethod
        {
            [Fact]
            public void Should_Return_Success_If_Sequence_Have_No_Attached_Behaviors()
            {
                // Given
                var context = new BehaviorContext();
                var sequence = new Sequence();

                // When
                var result = sequence.OnBehave(context);

                // Then
                Assert.Equal(BehaviorResult.Success, result);
            }

            [Fact]
            public void Should_Return_Success_If_All_Child_Behaviors_Succeed()
            {
                // Given
                var context = new BehaviorContext();
                var sequence = new Sequence(
                    new PredictableBehavior(BehaviorResult.Success),
                    new PredictableBehavior(BehaviorResult.Success));

                // When
                var result = sequence.OnBehave(context);

                // Then
                Assert.Equal(BehaviorResult.Success, result);
            }

            [Fact]
            public void Should_Return_Failure_If_Any_Child_Behavior_Returns_Failure()
            {
                // Given
                var context = new BehaviorContext();
                var sequence = new Sequence(
                    new PredictableBehavior(BehaviorResult.Failure),
                    new PredictableBehavior(BehaviorResult.Success));

                // When
                var result = sequence.OnBehave(context);

                // Then
                Assert.Equal(BehaviorResult.Failure, result);
            }

            [Fact]
            public void Should_Return_Running_If_Any_Child_Behavior_Returns_Running()
            {
                // Given
                var context = new BehaviorContext();
                var sequence = new Sequence(
                    new PredictableBehavior(BehaviorResult.Running),
                    new PredictableBehavior(BehaviorResult.Success));

                // When
                var result = sequence.OnBehave(context);

                // Then
                Assert.Equal(BehaviorResult.Running, result);
            }
        }
    }
}
