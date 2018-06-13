using Jitter;
using Jitter.Collision;
using Jitter.Dynamics;
using Jitter.LinearMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CollisionTestJitter
{
    class CollisionChecker
    {
        private readonly CollisionSystem collisionSystem = new CollisionSystemSAP();
        private bool collisionDetected = false;


        public bool CheckCollision(IBroadphaseEntity rigidBody1, IBroadphaseEntity rigidBody2)
        {
            collisionDetected = false;

            collisionSystem.AddEntity(rigidBody1);
            collisionSystem.AddEntity(rigidBody2);

            collisionSystem.CollisionDetected += CollisionSystem_CollisionDetected;

            collisionSystem.Detect(true);

            collisionSystem.CollisionDetected -= CollisionSystem_CollisionDetected;

            collisionSystem.RemoveEntity(rigidBody1);
            collisionSystem.RemoveEntity(rigidBody2);

            return collisionDetected;
        }

        private void CollisionSystem_CollisionDetected(RigidBody body1, RigidBody body2, JVector point1, JVector point2, JVector normal, float penetration)
        {
            collisionDetected = true;
        }
    }
}
