// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class LightPlayerEffect : PlayerEffect
{
    private LightPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by something slow!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasLightResistance)
        {
            dam *= 4;
            dam /= Game.DieRoll(6) + 6;
        }
        else if (!blind && !Game.HasBlindnessResistance)
        {
            Game.BlindnessTimer.AddTimer(Game.DieRoll(5) + 2);
        }
        if (Game.Race.IsBurnedBySunlight)
        {
            Game.MsgPrint("The light scorches your flesh!");
            dam *= 2;
        }
        Game.TakeHit(dam, killer);
        if (Game.EtherealnessTimer.Value != 0)
        {
            Game.EtherealnessTimer.SetValue();
            Game.MsgPrint("The light forces you out of your incorporeal shadow form.");
            Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        }
        return IdentifiedResultEnum.True;
    }
}
