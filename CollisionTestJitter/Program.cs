using System;
using System.Collections.Generic;
using System.Diagnostics;
using Jitter.Collision.Shapes;
using Jitter.Dynamics;
using Jitter.LinearMath;
using static Jitter.Collision.Shapes.CompoundShape;

namespace CollisionTestJitter
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new CollisionChecker();
            
            var boxes1 = new List<TransformedShape>()
            {
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 0, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 0, 1)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 1, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 1, 1)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 0, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 0, 1)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 1, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 1, 1)),
            };

            var boxes2 = new List<TransformedShape>()
            {
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 0, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 0, 1)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 1, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(0, 1, 1)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 0, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 0, 1)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 1, 0)),
                new TransformedShape(new BoxShape(1, 1, 1), JMatrix.Identity, new JVector(1, 1, 1)),
            };
            
            var compoundShape1 = new CompoundShape(boxes1);
            var rigidBody1 = new RigidBody(compoundShape1);
            
            var compoundShape2 = new CompoundShape(boxes2);
            var rigidBody2 = new RigidBody(compoundShape2);

            rigidBody1.Position = new JVector(0, 0, 0);
            rigidBody2.Position = new JVector(20, 0, 0);

            var stepSize = new JVector(0.1f, 0, 0);

            var stopWatch = new Stopwatch();
            int stepCount = 0;

            while (rigidBody1.Position.X < 20)
            {
                rigidBody1.Position = JVector.Add(rigidBody1.Position, stepSize);

                stopWatch.Start();
                bool colliding = checker.CheckCollision(rigidBody1, rigidBody2);
                stopWatch.Stop();
                stepCount++;

                float pos1 = rigidBody1.Position.X;
                float pos2 = rigidBody1.Position.X;

                Console.WriteLine($"Position1 {pos1}; Position2 {pos2}; Colliding {colliding}");
            }

            Console.WriteLine($"Total time taken for {stepCount} steps: {stopWatch.ElapsedMilliseconds}ms, time per step{stopWatch.ElapsedMilliseconds / (float)stepCount}ms");


            Console.ReadLine();
        }
    }
}
