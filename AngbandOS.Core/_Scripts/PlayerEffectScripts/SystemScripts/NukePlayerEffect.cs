// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class NukePlayerEffect : PlayerEffectUniversalScript
{
    private NukePlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by radiation!";
    public override IdentifiedResultEnum Apply(Monster mPtr, int dam)
    {
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasPoisonResistance)
        {
            dam = ((2 * dam) + 2) / 5;
        }
        if (Game.PoisonResistanceTimer.Value != 0)
        {
            dam = ((2 * dam) + 2) / 5;
        }
        Game.TakeHit(dam, killer);
        if (!(Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0))
        {
            Game.PoisonTimer.AddTimer(Game.RandomLessThan(dam) + 10);
            if (Game.DieRoll(5) == 1)
            {
                Game.MsgPrint("You undergo a freakish metamorphosis!");
                if (Game.DieRoll(4) == 1)
                {
                    Game.RunScript(nameof(PolymorphSelfScript));
                }
                else
                {
                    Game.ShuffleAbilityScores();
                }
            }
            if (Game.DieRoll(6) == 1)
            {
                Game.InvenDamage(Game.SetAcidDestroy, 2);
            }
        }
        return IdentifiedResultEnum.True;
    }
}
