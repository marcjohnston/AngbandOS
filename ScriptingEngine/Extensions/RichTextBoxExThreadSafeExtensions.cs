using byMarc.Net2.WinControls;
using Microsoft.VisualBasic.CompilerServices;

namespace Big6Search.ScriptingEngine
{

    // Module RichTextBoxExThreadSafeExtensions
    // Private Delegate Function InvokeGetSelectionStartDelegate(richTextBoxEx As RichTextBoxEx) As Integer
    // <Extension()> _
    // Public Function InvokeGetSelectionStart(richTextBoxEx As RichTextBoxEx) As Integer
    // If richTextBoxEx.InvokeRequired Then
    // Return richTextBoxEx.Invoke(New InvokeGetSelectionStartDelegate(AddressOf InvokeGetSelectionStart), richTextBoxEx)
    // Else
    // Return richTextBoxEx.SelectionStart
    // End If
    // End Function

    // Private Delegate Sub InvokeSetSelectionStartDelegate(richTextBoxEx As RichTextBoxEx, value As Integer)
    // <Extension()> _
    // Public Sub InvokeSetSelectionStart(richTextBoxEx As RichTextBoxEx, value As Integer)
    // If richTextBoxEx.InvokeRequired Then
    // richTextBoxEx.Invoke(New InvokeSetSelectionStartDelegate(AddressOf InvokeSetSelectionStart), richTextBoxEx, value)
    // Else
    // richTextBoxEx.SelectionStart = value
    // End If
    // End Sub

    // Private Delegate Function InvokeGetSelectionLengthDelegate(richTextBoxEx As RichTextBoxEx) As Integer
    // <Extension()> _
    // Public Function InvokeGetSelectionLength(richTextBoxEx As RichTextBoxEx) As Integer
    // If richTextBoxEx.InvokeRequired Then
    // Return richTextBoxEx.Invoke(New InvokeGetSelectionLengthDelegate(AddressOf InvokeGetSelectionLength), richTextBoxEx)
    // Else
    // Return richTextBoxEx.SelectionLength
    // End If
    // End Function

    // Private Delegate Sub InvokeSetSelectionLengthDelegate(richTextBoxEx As RichTextBoxEx, value As Integer)
    // <Extension()> _
    // Public Sub InvokeSetSelectionLength(richTextBoxEx As RichTextBoxEx, value As Integer)
    // If richTextBoxEx.InvokeRequired Then
    // richTextBoxEx.Invoke(New InvokeSetSelectionLengthDelegate(AddressOf InvokeSetSelectionLength), richTextBoxEx, value)
    // Else
    // richTextBoxEx.SelectionLength = value
    // End If
    // End Sub

    // Private Delegate Sub InvokeSelectDelegate(richTextBoxEx As RichTextBoxEx)
    // <Extension()> _
    // Public Sub InvokeSelect(richTextBoxEx As RichTextBoxEx)
    // If richTextBoxEx.InvokeRequired Then
    // richTextBoxEx.Invoke(New InvokeSelectDelegate(AddressOf InvokeSelect), richTextBoxEx)
    // Else
    // richTextBoxEx.Select()
    // End If
    // End Sub

    // End Module

    static class RichTextBoxExLib
    {
        private delegate int InvokeGetSelectionStartDelegate(RichTextBoxEx richTextBoxEx);
        public static int InvokeGetSelectionStart(RichTextBoxEx richTextBoxEx)
        {
            if (richTextBoxEx.InvokeRequired)
            {
                return Conversions.ToInteger(richTextBoxEx.Invoke(new InvokeGetSelectionStartDelegate(InvokeGetSelectionStart), richTextBoxEx));
            }
            else
            {
                return richTextBoxEx.SelectionStart;
            }
        }

        private delegate void InvokeSetSelectionStartDelegate(RichTextBoxEx richTextBoxEx, int value);
        public static void InvokeSetSelectionStart(RichTextBoxEx richTextBoxEx, int value)
        {
            if (richTextBoxEx.InvokeRequired)
            {
                richTextBoxEx.Invoke(new InvokeSetSelectionStartDelegate(InvokeSetSelectionStart), richTextBoxEx, value);
            }
            else
            {
                richTextBoxEx.SelectionStart = value;
            }
        }

        private delegate int InvokeGetSelectionLengthDelegate(RichTextBoxEx richTextBoxEx);
        public static int InvokeGetSelectionLength(RichTextBoxEx richTextBoxEx)
        {
            if (richTextBoxEx.InvokeRequired)
            {
                return Conversions.ToInteger(richTextBoxEx.Invoke(new InvokeGetSelectionLengthDelegate(InvokeGetSelectionLength), richTextBoxEx));
            }
            else
            {
                return richTextBoxEx.SelectionLength;
            }
        }

        private delegate void InvokeSetSelectionLengthDelegate(RichTextBoxEx richTextBoxEx, int value);
        public static void InvokeSetSelectionLength(RichTextBoxEx richTextBoxEx, int value)
        {
            if (richTextBoxEx.InvokeRequired)
            {
                richTextBoxEx.Invoke(new InvokeSetSelectionLengthDelegate(InvokeSetSelectionLength), richTextBoxEx, value);
            }
            else
            {
                richTextBoxEx.SelectionLength = value;
            }
        }

        private delegate void InvokeSelectDelegate(RichTextBoxEx richTextBoxEx);
        public static void InvokeSelect(RichTextBoxEx richTextBoxEx)
        {
            if (richTextBoxEx.InvokeRequired)
            {
                richTextBoxEx.Invoke(new InvokeSelectDelegate(InvokeSelect), richTextBoxEx);
            }
            else
            {
                richTextBoxEx.Select();
            }
        }

    }
}