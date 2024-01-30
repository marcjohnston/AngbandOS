// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellNaturesWrath : Spell
{
    private NatureSpellNaturesWrath(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.DispelMonsters(SaveGame.ExperienceLevel * 4);
        SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 20 + (SaveGame.ExperienceLevel / 2));
        SaveGame.Project(0, 1 + (SaveGame.ExperienceLevel / 12), SaveGame.MapY, SaveGame.MapX, 100 + SaveGame.ExperienceLevel,
            SaveGame.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile)), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem);
    }

    public override string Name => "Nature's Wrath";

    protected override string LearnedDetails => $"dam {4 * SaveGame.ExperienceLevel}+{100 + SaveGame.ExperienceLevel}";
}