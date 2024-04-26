// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class MajorDisplacementTalent : Talent
{
    private MajorDisplacementTalent(Game game) : base(game) { }
    public override string Name => "Major Displacement";
    public override int Level => 7;
    public override int ManaCost => 6;
    public override int BaseFailure => 35;

    public override void Use()
    {
        Game.RunScriptInt(nameof(TeleportSelfScript), Game.ExperienceLevel.IntValue * 5);
        if (Game.ExperienceLevel.IntValue > 29)
        {
            Game.RunScriptInt(nameof(BanishMonsters4xScript), Game.ExperienceLevel.IntValue);
        }
    }

    protected override string Comment()
    {
        return $"range {Game.ExperienceLevel.IntValue * 5}";
    }
}