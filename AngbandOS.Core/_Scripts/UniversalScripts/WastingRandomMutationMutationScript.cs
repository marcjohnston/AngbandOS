namespace AngbandOS.Core.Scripts;
internal class WastingRandomMutationMutationScript : UniversalScript, IGetKey
{
    private WastingRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

    public override void ExecuteScript()
    {
        if (Game.DieRoll(3000) != 13)
        {
            return;
        }
        WeightedRandom<Ability> abilitiesWeightedRandom = Game.SingletonRepository.ToWeightedRandom<Ability>();
        Ability whichStat = abilitiesWeightedRandom.Choose();
        bool sustained = whichStat.HasSustain;
        if (sustained)
        {
            return;
        }
        Game.Disturb(false);
        if (base.Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(LobonGod)).AdjustedFavour)
        {
            Game.MsgPrint("Lobon's favour protects you from wasting away!");
            Game.MsgPrint(string.Empty);
            return;
        }
        Game.MsgPrint("You can feel yourself wasting away!");
        Game.MsgPrint(string.Empty);
        Game.DecreaseAbilityScore(whichStat, base.Game.DieRoll(6) + 6, base.Game.DieRoll(3) == 1);
    }
}