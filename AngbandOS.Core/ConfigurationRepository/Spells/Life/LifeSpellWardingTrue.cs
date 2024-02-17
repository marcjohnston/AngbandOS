// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellWardingTrue : Spell
{
    private LifeSpellWardingTrue(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.RunScript(nameof(ElderSignScript));
        ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
        SaveGame.Project(0, 1, SaveGame.MapY, SaveGame.MapX, 0, SaveGame.SingletonRepository.Projectiles.Get(nameof(MakeElderSignProjectile)), flg);
    }

    public override string Name => "Warding True";
}