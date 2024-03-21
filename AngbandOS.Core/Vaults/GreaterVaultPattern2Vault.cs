// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultPattern2Vault : Vault
{
    private GreaterVaultPattern2Vault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Name => "Greater vault (Pattern 2)*";
    public override int Category => 8;
    public override int Height => 30;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%.X9+^^^^^^^^^^^^^^^^^+,,,,,,,,,,,,,,,+8X%%.X+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+X%%.X,X.................................X^X%%.X,X....adcbadcbadcbadcbadcbadc......X^X%%.X,X...ba.....................cbad...X^X%%.X,X..cb..bad.bad.bad.bad.bad....d...X^X%%.X,X..c..cb.dcb.dcb.dcb.dcb.dcba.dc..X^X%%.X&X..d.dc.....................a..c..X^X%%.X&X..d.d..bbcc...cbadcba..adc.ad.b..X^X%%.X+X..a.a.ab..cd.dc.....ad.a.c..d.a..X+X%%.X^X..a.b.a....d.d..PPP..d.b.c.cd.d..X@X%%&X^X..b.c.ad...a.a.PPAPP.c.c.b.c..dc.X9X%%.+^X..b.d..dc..a.b.PABAP.b.d.b.cb..c.+8X%%&X^X..c.a...cb.b.c.PPAPP.a.a.a..b..b.X9X%%.X^X..d.b....b.c.d..PPP..d.b.d.ab..a.X@X%%.X+X..a.c.cdab.d.da..d...dcb.d.a..da.X+X%%.X&X..b.d.c....a..abcd.......c.ad.d..X^X%%.X&X..c.a.cbad.ab......abc..bc..d.c..X^X%%.X,X..d.b....d..bcdabcda.cdab..cd.b..X^X%%.X,X..a.bcda.c................bc..a..X^X%%.X,X..b....abc..dab.dab.dab.dab..da..X^X%%.X,X..bcda.....cd.bcd.bcd.bcd...cd...X^X%%.X,X.....abcdabc..............pbc....X^X%%.X,X.................................X^X%%.X+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+X%%.X9+^^^^^^^^^^^^^^^^^+,,,,,,,,,,,,,,,+8X%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 42;
}
