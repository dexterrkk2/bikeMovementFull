using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.State
{
    public class BikeController : MonoBehaviour
    {
        public float maxSpeed = 2f;
        public float turnDistance = 2f;
        public float CurrentSpeed { get; set; }

        public Direction CurrentTurnDirection
        {
            get; private set;
        }
        private IBikeState
            _startState, _stopState, _turnState;
        private BikeStateContext bikeStateContext;
        // Start is called before the first frame update
        void Start()
        {
            bikeStateContext = new BikeStateContext(this);

            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();
            bikeStateContext.Transition(_stopState);
        }
        public void StartBike()
        {
            bikeStateContext.Transition(_startState);
        }
        public void StopBike()
        {
            bikeStateContext.Transition(_stopState);
        }
        public void Turn(Direction direction)
        {
            CurrentTurnDirection = direction;
            bikeStateContext.Transition(_turnState);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
