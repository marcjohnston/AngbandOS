// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Sorcery;

[Serializable]
internal class SorcerySpellConfuseMonster : Spell
{
    private SorcerySpellConfuseMonster(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.ConfuseMonster(dir, SaveGame.Player.Level * 3 / 2);
    }

    public override string Name => "Confuse Monster";
    
}