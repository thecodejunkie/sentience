using System;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BehaviorTrees
{
    using System.Runtime.InteropServices;
    using System.Threading;
    using Sentience;
    using Sentience.Composite;

    // http://www.gamasutra.com/blogs/ChrisSimpson/20140717/221339/Behavior_trees_for_AI_How_they_work.php
    // http://aigamedev.com/insider/presentations/behavior-trees/
    // http://www.pixelstudio.nl/?p=146
    // https://github.com/listentorick/UnityBehaviorLibrary

    class Program
    {
        static void Main(string[] args)
        {
            BehaviorConfiguration.IsDebug = true;

            var ctx =
                new BehaviorContext();

            //var behavior =
            //    new Sequence(new LongRunningBehavior(), new NormalBehavior(), new LongRunningBehavior(), new NormalBehavior());

            //var behavior =
            //    new Selector(new PredictableBehavior(BehaviorResult.Failure),
            //        new PredictableBehavior(BehaviorResult.Failure), new PredictableBehavior(BehaviorResult.Failure),
            //        new PredictableBehavior(BehaviorResult.Failure));

            var behavior =
                new Random(new FooBehavior("1"), new LongRunningBehavior(), new FooBehavior("2"), new FooBehavior("3"), new FooBehavior("4"));

            var allBehaviorsDone = false;

            while (!allBehaviorsDone)
            {
                var result =
                    behavior.Behave(ctx);

                allBehaviorsDone =
                    (result != BehaviorResult.Running);

                Thread.Sleep(200);
            }

            Console.ReadLine();
        }
    }

    public class GameObject
    {
    }

    public class FooBehavior : Behavior
    {
        public FooBehavior(string name)
            : base(name)
        {
        }

        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            return BehaviorResult.Success;
        }
    }

    public class PredictableBehavior : Behavior
    {
        private readonly BehaviorResult result;

        public PredictableBehavior(BehaviorResult result)
        {
            this.result = result;
        }

        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            return result;
        }
    }

    public class NormalBehavior : Behavior
    {
        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            return BehaviorResult.Success;
        }
    }

    public class LongRunningBehavior : Behavior
    {
        private bool isComplete;
        private System.Timers.Timer timer;

        public override BehaviorResult OnBehave(BehaviorContext context)
        {
            if (!isComplete)
            {
                this.timer =
                    new System.Timers.Timer(3000);

                timer.Start();

                timer.Elapsed += (x, y) =>
                {
                    this.isComplete = true;
                    timer.Stop(); ;
                };

                return BehaviorResult.Running;
            }

            return BehaviorResult.Success; ;
        }
    }
}
