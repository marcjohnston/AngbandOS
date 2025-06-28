// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.PlayerEffects;

[Serializable]
internal class NetherPlayerEffect : PlayerEffect
{
    private NetherPlayerEffect(Game game) : base(game) { } // This object is a singleton.
    public override string? BlindPreMessage => "You are hit by nether forces!";
    protected override IdentifiedResultEnum Apply(Monster mPtr, int r, int y, int x, int dam, int aRad)
    {
        string killer = mPtr.IndefiniteVisibleName;
        if (Game.HasNetherResistance)
        {
            if (Game.Race.NegatesNetherResistance)
            {
                dam *= 6;
            }
            dam /= Game.DieRoll(6) + 6;
        }
        else
        {
            if (Game.HasHoldLife && Game.RandomLessThan(100) < 75)
            {
                Game.MsgPrint("You keep hold of your life force!");
            }
            else if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                Game.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (Game.HasHoldLife)
            {
                Game.MsgPrint("You feel your life slipping away!");
                Game.LoseExperience(200 + (Game.ExperiencePoints.IntValue / 1000 * Constants.MonDrainLife));
            }
            else
            {
                Game.MsgPrint("You feel your life draining away!");
                Game.LoseExperience(200 + (Game.ExperiencePoints.IntValue / 100 * Constants.MonDrainLife));
            }
        }
        if (Game.Race.ProjectingNetherRestoresHealth)
        {
            Game.MsgPrint("You feel invigorated!");
            Game.RestoreHealth(dam / 4);
        }
        else
        {
            Game.TakeHit(dam, killer);
        }
        return IdentifiedResultEnum.True;
    }
}
