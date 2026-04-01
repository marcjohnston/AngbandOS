// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Talents;

[Serializable]
internal class MinorDisplacementTalent : Talent
{
    private MinorDisplacementTalent(Game game) : base(game) { }
    public override string Name => "Minor Displacement";
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;

    public override void Use()
    {
        if (Game.ExperienceLevel.IntValue < 25)
        {
            Game.RunScript(nameof(TeleportSelf10TeleportSelfScript));
        }
        else
        {
            Game.MsgPrint("Choose a destination.");
            if (!Game.TgtPt(out int i, out int j))
            {
                return;
            }
            Game.Energy -= 60 - Game.ExperienceLevel.IntValue;
            if (!Game.GridPassableNoCreature(j, i) || Game.Map.Grid[j][i].InVault || !Game.Map.Grid[j][i].FeatureType.IsWater || Game.Distance(j, i, Game.MapY.IntValue, Game.MapX.IntValue) > Game.ExperienceLevel.IntValue + 2 || Game.RandomLessThan(Game.ExperienceLevel.IntValue * Game.ExperienceLevel.IntValue / 2) == 0)
            {
                Game.MsgPrint("Something disrupts your concentration!");
                Game.Energy -= 100;
                Game.RunScript(nameof(TeleportSelf20TeleportSelfScript));
            }
            else
            {
                Game.TeleportPlayerTo(j, i);
            }
        }
    }

    protected override string LearnedDetails()
    {
        return $"range {(Game.ExperienceLevel.IntValue < 25 ? 10 : Game.ExperienceLevel.IntValue + 2)}";
    }
}