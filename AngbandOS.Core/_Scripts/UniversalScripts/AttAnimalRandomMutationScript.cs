namespace AngbandOS.Core.Scripts;
internal class AttAnimalRandomMutationScript : UniversalScript, IGetKey
{
    private AttAnimalRandomMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(7000) != 1)
        {
            return;
        }
        bool aSummon;
        if (base.Game.DieRoll(3) == 1)
        {
            aSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(AnimalMonsterRaceFilter)), true, true);
        }
        else
        {
            aSummon = Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(AnimalMonsterRaceFilter)), true, false);
        }
        if (!aSummon)
        {
            return;
        }
        Game.MsgPrint("You have attracted an animal!");
        Game.Disturb(false);
    }
}