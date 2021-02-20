using System.Collections;
using System.Collections.Generic;
using MarkOne.Interfaces;
using UnityEngine;

namespace Processors
{
    [CreateAssetMenu(fileName = "TrackProcessorProvider", menuName = "Processors/TrackProcessorProvider")]
    public class TrackProcessorProviderSO : ScriptableObject
    {
        public List<IMoveable> ChunksMoveables = new List<IMoveable>();
        public List<IMoveable> DynamicMoveables = new List<IMoveable>();
    }
}