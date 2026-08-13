namespace AngbandOS.Core.Scripts;
internal class NormalityRandomMutationMutationScript : UniversalScript, IGetKey
{
    private NormalityRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(5000) == 1)
        {
            if (Game.MutationsPossessed.Count == 0)
            {
                return;
            }
            Game.MsgPrint("You change...");
            int total = 0;
            foreach (Mutation mutation in Game.MutationsPossessed)
            {
                total += mutation.Frequency;
            }
            int roll = Game.DieRoll(total);
            for (int i = 0; i < Game.MutationsPossessed.Count; i++)
            {
                roll -= Game.MutationsPossessed[i].Frequency;
                if (roll > 0)
                {
                    continue;
                }
                Mutation mutation = Game.MutationsPossessed[i];
                Game.MutationsPossessed.RemoveAt(i);
                mutation.OnLose();
                Game.MutationsNotPossessed.Add(mutation);
                Game.MsgPrint(mutation.LoseMessage);
                return;
            }
            Game.MsgPrint("Oops! Fell out of mutation list!");
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            Game.HandleStuff();
        }
    }
}