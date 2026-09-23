namespace AngbandOS.Core.Scripts;
internal class NormalityRandomMutationScript : UniversalScript, IGetKey
{
    private NormalityRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

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