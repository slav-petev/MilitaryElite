namespace MilitaryElite.Soldiers.Specialised.Missions
{
    public class InvalidMissionState : IMissionState
    {
        public void CompleteMission(Mission mission)
        {
            throw new InvalidOperationException("Cannot complete an invalid mission");
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
