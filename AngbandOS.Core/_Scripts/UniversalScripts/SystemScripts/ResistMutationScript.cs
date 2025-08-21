namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class ResistMutationScript : UniversalScript, IGetKey
{
    private ResistMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        int num = Game.ExperienceLevel.IntValue / 10;
        int dur = base.Game.DieRoll(20) + 20;
        if (base.Game.RandomLessThan(5) < num)
        {
            Game.AcidResistanceTimer.AddTimer(dur);
            num--;
        }
        if (base.Game.RandomLessThan(4) < num)
        {
            Game.LightningResistanceTimer.AddTimer(dur);
            num--;
        }
        if (base.Game.RandomLessThan(3) < num)
        {
            Game.RunScript(nameof(FireResistance1d20p20TimerScript));
            num--;
        }
        if (base.Game.RandomLessThan(2) < num)
        {
            Game.ColdResistanceTimer.AddTimer(dur);
            num--;
        }
        if (num != 0)
        {
            Game.PoisonResistanceTimer.AddTimer(dur);
        }
    }
}