// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class TalentCharacterArmour : Talent
{
    public override string Name => "Character Armour";
    public override void Initialise(int characterClass)
    {
        Level = 13;
        ManaCost = 12;
        BaseFailure = 50;
    }

    public override void Use(SaveGame saveGame)
    {
        saveGame.Player.TimedStoneskin.AddTimer(saveGame.Player.ExperienceLevel);
        if (saveGame.Player.ExperienceLevel > 14)
        {
            saveGame.Player.TimedAcidResistance.AddTimer(saveGame.Player.ExperienceLevel);
        }
        if (saveGame.Player.ExperienceLevel > 19)
        {
            saveGame.Player.TimedFireResistance.AddTimer(saveGame.Player.ExperienceLevel);
        }
        if (saveGame.Player.ExperienceLevel > 24)
        {
            saveGame.Player.TimedColdResistance.AddTimer(saveGame.Player.ExperienceLevel);
        }
        if (saveGame.Player.ExperienceLevel > 29)
        {
            saveGame.Player.TimedLightningResistance.AddTimer(saveGame.Player.ExperienceLevel);
        }
        if (saveGame.Player.ExperienceLevel > 34)
        {
            saveGame.Player.TimedPoisonResistance.AddTimer(saveGame.Player.ExperienceLevel);
        }
    }

    protected override string Comment(Player player)
    {
        return $"dur {player.ExperienceLevel}";
    }
}