// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Dungeons;

[Serializable]
internal class YeekDungeon : Dungeon
{
    private YeekDungeon(SaveGame saveGame) : base(saveGame) { }
    public override int BaseOffset => 2;
    public override int MaxLevel => 8;
    public override MonsterFilter? Bias => SaveGame.SingletonRepository.MonsterFilters.Get(nameof(YeekMonsterFilter));
    public override string FirstGuardian => "Orfax, Son of Boldor";
    public override string SecondGuardian => "Boldor, King of the Yeeks";
    public override int FirstLevel => 7;
    public override int SecondLevel => 8;
    public override string Name => "the Yeek King's Lair";
    public override string Shortname => "Yeek Lair";
    public override string MapSymbol => "y";
}