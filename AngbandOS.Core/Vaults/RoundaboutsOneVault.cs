// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class RoundaboutsOneVault : Vault
{
    private RoundaboutsOneVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Roundabouts One";
    public override int Category => 8;
    public override int Height => 21;
    public override int Rating => 15;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X^^^^^^^^^^^^^^^^#&^^^&^^^^^^^^^^^^^&^,,X%%X^^^XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX&.,X%%X^.X+^&^..^^.....#&^^^&......^^....,XX&.X%%X.^X^&^XXXXXXXXXXXXXXXXXXXXXXXXXXX^,,X.^X%%X^.X&^XX,.^^......&^^^&#.....^^&^+X^^X^.X%%X.^X^^X,,.^^......&^^^&#.....^^ &^X^^X.^X%%X^.X^^X*^^XXXXXXXXXXXXXXXXXXXXX^^&X^^X^.X%%X.^X^^X*^X+^,,,,,,@#8X@9    *&XX^*X^^X.^X%%X^^X^^X^^X^&*^^^^^@XXX@^^^^^*&^X^^X^^X^^X%%X^.X^^X*^XX&*....9@X8#@,,,,,,^+X^*X^^X^.X%%X.^X^^X&^^XXXXXXXXXXXXXXXXXXXXX^^*X^^X.^X%%X^.X^^X^& ^^.....#&^^^&......^^.,,X^^X^.X%%X.^X^^X+^&^^.....#&^^^&......^^.,XX^&X.^X%%X^.X,,^XXXXXXXXXXXXXXXXXXXXXXXXXXX^&^X^.X%%X.&XX,....^^......&^^^&#.....^^..^&^+X.^X%%X,.&XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX^^^X%%X,,^&^^^^^^^^^^^^^&^^^&#^^^^^^^^^^^^^^^^X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 43;
}
