namespace MilitaryElite.Soldiers.Specialised.Missions
{
    public class Mission
    {
        private IMissionState _state;
        
        public string CodeName { get; }

        public string State => _state.ToString();

        private Mission(string codeName, IMissionState state)
        {
            this.CodeName = codeName;
            _state = state;
        }

        public void SetState(IMissionState newState)
        {
            _state = newState;
        }

        public void CompleteMission()
        {
            _state.CompleteMission(this);
        }

        public override string ToString()
        {
            return _state.ToString() != string.Empty
                ? $"Code Name: {this.CodeName} State: {_state}"
                : string.Empty;
        }

        public static Mission FromPair(IEnumerable<string> pair)
        {
            if (pair == null)
            {
                throw new ArgumentNullException(nameof(pair));
            }

            if (pair.Count() != 2)
            {
                throw new ArgumentException("Mission pair must contain exactly 2 values", nameof(pair));
            }

            var codeName = pair.First();
            var stateValue = pair.Last();

            IMissionState state;
            switch (stateValue)
            {
                case "inProgress":
                    state = new InProgressMissionState();
                    break;
                case "Finished":
                    state = new FinishedMissonState();
                    break;
                default:
                    state = new InvalidMissionState();
                    break;
            }
            
            return new Mission(codeName, state);
        }
    }
}
