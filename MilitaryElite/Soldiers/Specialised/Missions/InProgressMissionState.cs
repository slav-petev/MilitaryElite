namespace MilitaryElite.Soldiers.Specialised.Missions
{
    public class InProgressMissionState : IMissionState
    {
        public void CompleteMission(Mission mission)
        {
            mission.SetState(new FinishedMissonState());
        }

        public override string ToString()
        {
            return "inProgress";
        }
    }
}
