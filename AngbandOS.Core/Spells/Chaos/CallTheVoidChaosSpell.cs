﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class CallTheVoidChaosSpell : Spell
{
    private CallTheVoidChaosSpell(Game game) : base(game) { }
    protected override string[]? CastScriptNames => new string[] { nameof(CallTheVoidScript) };

    protected override string[]? CastFailedScriptNames => new string[] { nameof(WildChaoticMagicScript) };

    public override string Name => "Call the Void";

    protected override string LearnedDetails => "dam 3 * 175";
}