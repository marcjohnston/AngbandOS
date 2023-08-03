// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultroundVault : Vault
{
    private LesserVaultroundVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Lesser vault (round)";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 5;
    public override string Text => "       %%%%%%           %%%..##..%%%      %%....####....%%   %......#**#......% %...,.##+##+##.,...%%.,.,.#*#*&#*#.,.,.%%.,.,.#*#&*#*#.,.,.%%...,.##+##+##.,...% %......#**#......%   %%....####....%%      %%%..##..%%%           %%%%%%       ";
    public override int Width => 20;
}
