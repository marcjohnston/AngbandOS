// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class VaultDungeon : Dungeon
{
    private VaultDungeon(Game game) : base(game) { }
    public override int BaseOffset => 10;
    public override int MaxLevel => 30;
    protected override string[]? DungeonGuardianNames => new string[]
    {
        nameof(TheStormbringerDungeonGuardian)
    };
    public override string Name => "the Vault of the Sword";
    public override string Shortname => "Vault";
    public override string MapSymbol => "v";
}