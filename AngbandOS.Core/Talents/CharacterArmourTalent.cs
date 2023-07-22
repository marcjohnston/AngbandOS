// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class CharacterArmourTalent : Talent
{
    private CharacterArmourTalent(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Character Armour";
    public override void Initialize(int characterClass)
    {
        Level = 13;
        ManaCost = 12;
        BaseFailure = 50;
    }

    public override void Use()
    {
        SaveGame.Player.TimedStoneskin.AddTimer(SaveGame.Player.ExperienceLevel);
        if (SaveGame.Player.ExperienceLevel > 14)
        {
            SaveGame.Player.TimedAcidResistance.AddTimer(SaveGame.Player.ExperienceLevel);
        }
        if (SaveGame.Player.ExperienceLevel > 19)
        {
            SaveGame.Player.TimedFireResistance.AddTimer(SaveGame.Player.ExperienceLevel);
        }
        if (SaveGame.Player.ExperienceLevel > 24)
        {
            SaveGame.Player.TimedColdResistance.AddTimer(SaveGame.Player.ExperienceLevel);
        }
        if (SaveGame.Player.ExperienceLevel > 29)
        {
            SaveGame.Player.TimedLightningResistance.AddTimer(SaveGame.Player.ExperienceLevel);
        }
        if (SaveGame.Player.ExperienceLevel > 34)
        {
            SaveGame.Player.TimedPoisonResistance.AddTimer(SaveGame.Player.ExperienceLevel);
        }
    }

    protected override string Comment()
    {
        return $"dur {SaveGame.Player.ExperienceLevel}";
    }
}