using System.Collections;
using Microsoft.VisualBasic;

namespace Big6Search.ScriptingEngine
{

    public class ArrayValue : DataValue, IEnumerable
    {

        public DataValue[] Items;
        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
        public override string ToString()
        {
            string s = null;
            foreach (DataValue item in Items)
                s = byMarc.Net2.Library.Strings.StringLib.DelimitIf(s, Constants.vbCrLf, item.ToString());
            return s;
        }
        public ArrayValue(DataValue[] items)
        {
            Items = items;
        }
    }
}