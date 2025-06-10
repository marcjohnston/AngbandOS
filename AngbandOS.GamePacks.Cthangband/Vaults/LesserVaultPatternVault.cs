// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LesserVaultPatternVault : VaultGameConfiguration
{
    public override string Name => "Lesser vault (Pattern)";
    public override int Category => 8;
    public override int Height => 31;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%X@&+.............................+&@X,,,,,,X.%%XXXX.p...bad.bad.bad.bad.cbb.....XXXX,,,,,,X.%%X@&X.a.dcb.dcb.dcb.dcb.dcc.baa...X&@X,,,,,,X.%%XX+X.b.d.....................ad..X+XX,,,,,,X.%%X....c.a.dabcdabcda...........dc....X,,,,,,X.%%X....d.b.d........a..cbadcba...c....X,,,,,,X.%%X...ad.c.c.dcbadcba..c.....ad..cb...X++XXX+X.%%X...a..d.b.d.........cdabc..d...b...X^^X^^^X.%%X...b.ad.a.a..abcd.......cd.dcb.a...X**X^X+X.%%X..cb.a..d.b..a..d..adcb..d...b.ad..X,,X^X^X.%%X..c..b..c.c..d.ad..a..ba.a...a..d..X&&X^X&X.%%X.dc.cb..b.d..c.a..PPP..a.a.cda..dc.X^^X^X+X.%%X.d..c...a.a..b.b.PPAPP.d.b.c.....c.+^^X^X*X.%%X.da.cd..d.b..a.c.PABAP.c.b.cba..bc.X^^X^X*X.%%X..a..d..c.c..d.d.PPAPP.b.c...a..b..X&&X^XXX.%%X..ab.da.b.d..c.a..PPP..a.c...d.ab..X,,X^X,X.%%X...b..a.a.a..b.ab.....da.d..cd.a...XXXX+X+X.%%X...c..b.d.b..a..bcd.bcd..a.bc..d...X**^^^,X.%%X...cd.bcd.c..ad...dab...ba.b..cd...X,,,,,,X.%%X....d.....d...dc......dcb..a..c....X,,,XXXX.%%X....da....da...cbadcbad...da.bc....X,,,+,,X.%%X.....a.....abc...........cd..b.....X,,,X,,X.%%XX+X..ab......cdabcdabcdabc..ab..X+XXXXXX,,X.%%X@&X...bc...................da...X&@X,,,,,,X.%%XXXX....cddaabbccddaabbcdabcd....XXXX,,,,,&+.%%X@&+.............................+&@X****&&+.%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX++X.%%.............................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 47;
}
