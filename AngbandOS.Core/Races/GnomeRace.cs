﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Races;

[Serializable]
internal class GnomeRace : Race
{
    private GnomeRace(Game game) : base(game) { }
    public override string Title => "Gnome";
    public override int BaseDisarmBonus => 10;
    public override int BaseDeviceBonus => 12;
    public override int BaseSaveBonus => 12;
    public override int BaseStealthBonus => 3;
    public override int BaseSearchBonus => 6;
    public override int BaseSearchFrequency => 13;
    public override int BaseMeleeAttackBonus => -8;
    public override int BaseRangedAttackBonus => 12;
    public override int HitDieBonus => 8;
    public override int ExperienceFactor => 135;
    public override int BaseAge => 50;
    public override int AgeRange => 40;
    public override int Infravision => 4;
    public override uint Choice => 0x1E0F;
    public override string Description => "Gnomes are small, playful, and talented at magic. However,\nthey are almost chronically incapable of taking anything\nseriously. Gnomes are constantly fidgeting and always on\nthe move, and this makes them impossible to paralyse or\nmagically slow. Gnomes are even able to learn how to \nteleport short distances (at lvl 5).";

    /// <summary>
    /// Gnome 13->14->3->50->51->52->53->End
    /// </summary>
    public override int Chart => 13;

    public override string RacialPowersDescription(int lvl) => lvl < 5 ? "teleport           (racial, unusable until level 5)" : "teleport           (racial, cost 5 + lvl/5, INT based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, RwItemPropertySet itemCharacteristics)
    {
        itemCharacteristics.FreeAct = true;
    }
    protected override string GenerateNameSyllableSetName => nameof(GnomishSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 4)
        {
            return new string[] { $"You can teleport, range {1 + level} (cost {5 + (level / 5)})." };
        }
        return null;
    }

    public override void CalcBonuses()
    {
        Game.HasFreeAction = true;
    }
}