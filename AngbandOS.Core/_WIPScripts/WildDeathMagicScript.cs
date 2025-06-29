﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WildDeathMagicScript : Script, ICastSpellScript
{
    private WildDeathMagicScript(Game game) : base(game) { }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    public void ExecuteCastSpellScript(Spell spell)
    {
        int bookIndex = spell.SpellBookItemFactory.BookIndex;
        int spellIndex= spell.SpellIndex;
        if (bookIndex == 3 && Game.DieRoll(2) == 1)
        {
            Game.Monsters[0].SanityBlast(true);
        }
        else
        {
            Game.MsgPrint("It hurts!");
            Game.TakeHit(Game.DiceRoll(bookIndex + 1, 6), "a miscast Death spell");
            if (spellIndex > 15 && Game.DieRoll(6) == 1 && !Game.HasHoldLife)
            {
                Game.LoseExperience(spellIndex * 250);
            }
        }
    }
}
