// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Sorcery;

[Serializable]
internal class SorcerySpellDetectObjectsAndTreasure : Spell
{
    private SorcerySpellDetectObjectsAndTreasure(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.DetectObjectsNormal();
        SaveGame.DetectTreasure();
        SaveGame.DetectObjectsGold();
    }

    public override string Name => "Detect Objects and Treasure";
    
}