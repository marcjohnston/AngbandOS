// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class NecropolisDungeon : Dungeon
{
    private NecropolisDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 30;
    /// <summary>
    /// Returns true because this dungeon is a tower.
    /// </summary>
    public override bool Tower => true;
    public override int MaxLevel => 40;
    protected override string? BiasMonsterFilterName => nameof(HiUndeadMonsterFilter);
    public override string FirstGuardian => "Fire Phantom";
    public override string SecondGuardian => "Vecna, the Emperor Lich";
    public override int FirstLevel => 1;
    public override int SecondLevel => 40;
    public override string Name => "the Necropolis";
    public override string Shortname => "Necropolis";
    public override string MapSymbol => "n";
}