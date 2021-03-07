using MarkOne.Interfaces;
using UnityEngine;

namespace Obstacles.MoveableObstacles
{
    public class Tram : Obstacle, IMoveable
    {
        public void Move(Vector3 direction) => this.transform.position += direction * Time.deltaTime;
    }
}