' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System
Imports System.Diagnostics
Imports Microsoft.VisualBasic

' TODO ERROR: Skipped IfDirectiveTrivia
' #If TARGET = "module" AndAlso _MYTYPE = "" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' #Const _MYTYPE="Empty"
' ' TODO ERROR: Skipped EndIfDirectiveTrivia
' #End If
' 
' TODO ERROR: Skipped IfDirectiveTrivia
' #If _MYTYPE = "WindowsForms" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' #Const _MYFORMS = True
' #Const _MYWEBSERVICES = True
' #Const _MYUSERTYPE = "Windows"
' #Const _MYCOMPUTERTYPE = "Windows"
' #Const _MYAPPLICATIONTYPE = "WindowsForms"
' 
' ' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE = "WindowsFormsWithCustomSubMain" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' #Const _MYFORMS = True
' #Const _MYWEBSERVICES = True
' #Const _MYUSERTYPE = "Windows"
' #Const _MYCOMPUTERTYPE = "Windows"
' #Const _MYAPPLICATIONTYPE = "Console"
' 
' ' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE = "Windows" OrElse _MYTYPE = "" Then
' 
' TODO ERROR: Skipped DefineDirectiveTrivia
' #Const _MYWEBSERVICES = True
' ' TODO ERROR: Skipped DefineDirectiveTrivia
' #Const _MYUSERTYPE = "Windows"
' ' TODO ERROR: Skipped DefineDirectiveTrivia
' #Const _MYCOMPUTERTYPE = "Windows"
' ' TODO ERROR: Skipped DefineDirectiveTrivia
' #Const _MYAPPLICATIONTYPE = "Windows"
' 
' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE = "Console" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' #Const _MYWEBSERVICES = True
' #Const _MYUSERTYPE = "Windows"
' #Const _MYCOMPUTERTYPE = "Windows"
' #Const _MYAPPLICATIONTYPE = "Console"
' 
' ' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE = "Web" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' #Const _MYFORMS = False
' #Const _MYWEBSERVICES = False
' #Const _MYUSERTYPE = "Web"
' #Const _MYCOMPUTERTYPE = "Web"
' 
' ' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE = "WebControl" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' #Const _MYFORMS = False
' #Const _MYWEBSERVICES = True
' #Const _MYUSERTYPE = "Web"
' #Const _MYCOMPUTERTYPE = "Web"
' 
' ' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE = "Custom" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' ' TODO ERROR: Skipped ElifDirectiveTrivia
' #ElseIf _MYTYPE <> "Empty" Then
' ' TODO ERROR: Skipped DisabledTextTrivia
' 
' #Const _MYTYPE = "Empty"
' 
' ' TODO ERROR: Skipped EndIfDirectiveTrivia
' #End If
' 
' TODO ERROR: Skipped IfDirectiveTrivia
' #If _MYTYPE <> "Empty" Then
' 
Namespace byMarc.Net2.Library.LanguageParsing.My

    ' TODO ERROR: Skipped IfDirectiveTrivia
    ' #If _MYAPPLICATIONTYPE = "WindowsForms" OrElse _MYAPPLICATIONTYPE = "Windows" OrElse _MYAPPLICATIONTYPE = "Console" Then
    ' 
    <CodeDom.Compiler.GeneratedCode("MyTemplate", "11.0.0.0")>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>

    ' TODO ERROR: Skipped IfDirectiveTrivia
    ' #If _MYAPPLICATIONTYPE = "WindowsForms" Then
    ' ' TODO ERROR: Skipped DisabledTextTrivia
    ' Inherits Global.Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    ' #If TARGET = "winexe" Then
    ' <Global.System.STAThread(), Global.System.Diagnostics.DebuggerHidden(), Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    ' Friend Shared Sub Main(ByVal Args As String())
    ' Try
    ' Global.System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(MyApplication.UseCompatibleTextRendering())
    ' Finally
    ' End Try               
    ' My.Application.Run(Args)
    ' End Sub
    ' #End If
    ' 
    ' ' TODO ERROR: Skipped ElifDirectiveTrivia
    ' #ElseIf _MYAPPLICATIONTYPE = "Windows" Then
    ' 
    Friend Partial Class MyApplication
        Inherits ApplicationServices.ApplicationBase
        ' TODO ERROR: Skipped ElifDirectiveTrivia
        ' #ElseIf _MYAPPLICATIONTYPE = "Console" Then
        ' ' TODO ERROR: Skipped DisabledTextTrivia
        ' Inherits Global.Microsoft.VisualBasic.ApplicationServices.ConsoleApplicationBase	
        ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If '_MYAPPLICATIONTYPE = "WindowsForms"
        ' 
    End Class

    ' TODO ERROR: Skipped EndIfDirectiveTrivia
    ' #End If '#If _MYAPPLICATIONTYPE = "WindowsForms" Or _MYAPPLICATIONTYPE = "Windows" or _MYAPPLICATIONTYPE = "Console"
    ' 
    ' TODO ERROR: Skipped IfDirectiveTrivia
    ' #If _MYCOMPUTERTYPE <> "" Then
    ' 
    <CodeDom.Compiler.GeneratedCode("MyTemplate", "11.0.0.0")>
    <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>

    ' TODO ERROR: Skipped IfDirectiveTrivia
    ' #If _MYCOMPUTERTYPE = "Windows" Then
    ' 
    Friend Partial Class MyComputer
        Inherits Devices.Computer
        ' TODO ERROR: Skipped ElifDirectiveTrivia
        ' #ElseIf _MYCOMPUTERTYPE = "Web" Then
        ' ' TODO ERROR: Skipped DisabledTextTrivia
        ' Inherits Global.Microsoft.VisualBasic.Devices.ServerComputer
        ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If
        ' 
        <DebuggerHidden()>
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
        Public Sub New()
            MyBase.New()
        End Sub
    End Class
    ' TODO ERROR: Skipped EndIfDirectiveTrivia
    ' #End If
    ' 
    <HideModuleName()>
    <CodeDom.Compiler.GeneratedCode("MyTemplate", "11.0.0.0")>
    Friend Module MyProject

        ' TODO ERROR: Skipped IfDirectiveTrivia
        ' #If _MYCOMPUTERTYPE <> "" Then
        ' 
        <ComponentModel.Design.HelpKeyword("My.Computer")>
        Friend ReadOnly Property Computer As MyComputer
            <DebuggerHidden()>
            Get
                Return m_ComputerObjectProvider.GetInstance
            End Get
        End Property

        Private ReadOnly m_ComputerObjectProvider As ThreadSafeObjectProvider(Of MyComputer) = New ThreadSafeObjectProvider(Of MyComputer)()
        ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If
        ' 
        ' TODO ERROR: Skipped IfDirectiveTrivia
        ' #If _MYAPPLICATIONTYPE = "Windows" Or _MYAPPLICATIONTYPE = "WindowsForms" Or _MYAPPLICATIONTYPE = "Console" Then
        ' 
        <ComponentModel.Design.HelpKeyword("My.Application")>
        Friend ReadOnly Property Application As MyApplication
            <DebuggerHidden()>
            Get
                Return m_AppObjectProvider.GetInstance
            End Get
        End Property
        Private ReadOnly m_AppObjectProvider As ThreadSafeObjectProvider(Of MyApplication) = New ThreadSafeObjectProvider(Of MyApplication)()
        ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If
        ' 
        ' TODO ERROR: Skipped IfDirectiveTrivia
        ' #If _MYUSERTYPE = "Windows" Then
        ' 
        <ComponentModel.Design.HelpKeyword("My.User")>
        Friend ReadOnly Property User As ApplicationServices.User
            <DebuggerHidden()>
            Get
                Return m_UserObjectProvider.GetInstance
            End Get
        End Property
        Private ReadOnly m_UserObjectProvider As ThreadSafeObjectProvider(Of ApplicationServices.User) = New ThreadSafeObjectProvider(Of ApplicationServices.User)()
        ' TODO ERROR: Skipped ElifDirectiveTrivia
        ' #ElseIf _MYUSERTYPE = "Web" Then
        ' ' TODO ERROR: Skipped DisabledTextTrivia
        ' <Global.System.ComponentModel.Design.HelpKeyword("My.User")> _
        ' Friend ReadOnly Property User() As Global.Microsoft.VisualBasic.ApplicationServices.WebUser
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Get
        ' Return m_UserObjectProvider.GetInstance()
        ' End Get
        ' End Property
        ' Private ReadOnly m_UserObjectProvider As New ThreadSafeObjectProvider(Of Global.Microsoft.VisualBasic.ApplicationServices.WebUser)
        ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If
        ' 
        ' TODO ERROR: Skipped IfDirectiveTrivia
        ' #If _MYFORMS = True Then
        ' ' TODO ERROR: Skipped DisabledTextTrivia
        ' 
        ' #Const STARTUP_MY_FORM_FACTORY = "My.MyProject.Forms"
        ' 
        ' <Global.System.ComponentModel.Design.HelpKeyword("My.Forms")> _
        ' Friend ReadOnly Property Forms() As MyForms
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Get
        ' Return m_MyFormsObjectProvider.GetInstance()
        ' End Get
        ' End Property
        ' 
        ' <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Never)> _
        ' <Global.Microsoft.VisualBasic.MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")> _
        ' Friend NotInheritable Class MyForms
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Private Shared Function Create__Instance__(Of T As {New, Global.System.Windows.Forms.Form})(ByVal Instance As T) As T
        ' If Instance Is Nothing OrElse Instance.IsDisposed Then
        ' If m_FormBeingCreated IsNot Nothing Then
        ' If m_FormBeingCreated.ContainsKey(GetType(T)) = True Then
        ' Throw New Global.System.InvalidOperationException(Global.Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_RecursiveFormCreate"))
        ' End If
        ' Else
        ' m_FormBeingCreated = New Global.System.Collections.Hashtable()
        ' End If
        ' m_FormBeingCreated.Add(GetType(T), Nothing)
        ' Try
        ' Return New T()
        ' Catch ex As Global.System.Reflection.TargetInvocationException When ex.InnerException IsNot Nothing
        ' Dim BetterMessage As String = Global.Microsoft.VisualBasic.CompilerServices.Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message)
        ' Throw New Global.System.InvalidOperationException(BetterMessage, ex.InnerException)
        ' Finally
        ' m_FormBeingCreated.Remove(GetType(T))
        ' End Try
        ' Else
        ' Return Instance
        ' End If
        ' End Function
        ' 
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Private Sub Dispose__Instance__(Of T As Global.System.Windows.Forms.Form)(ByRef instance As T)
        ' instance.Dispose()
        ' instance = Nothing
        ' End Sub
        ' 
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Never)> _
        ' Public Sub New()
        ' MyBase.New()
        ' End Sub
        ' 
        ' <Global.System.ThreadStatic()> Private Shared m_FormBeingCreated As Global.System.Collections.Hashtable
        ' 
        ' <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> Public Overrides Function Equals(ByVal o As Object) As Boolean
        ' Return MyBase.Equals(o)
        ' End Function
        ' <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> Public Overrides Function GetHashCode() As Integer
        ' Return MyBase.GetHashCode
        ' End Function
        ' <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> _
        ' Friend Overloads Function [GetType]() As Global.System.Type
        ' Return GetType(MyForms)
        ' End Function
        ' <Global.System.ComponentModel.EditorBrowsable(Global.System.ComponentModel.EditorBrowsableState.Never)> Public Overrides Function ToString() As String
        ' Return MyBase.ToString
        ' End Function
        ' End Class
        ' 
        ' Private m_MyFormsObjectProvider As New ThreadSafeObjectProvider(Of MyForms)
        ' 
        ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If
        ' 
        ' TODO ERROR: Skipped IfDirectiveTrivia
        ' #If _MYWEBSERVICES = True Then
        ' 
        <ComponentModel.Design.HelpKeyword("My.WebServices")>
        Friend ReadOnly Property WebServices As MyWebServices
            <DebuggerHidden()>
            Get
                Return m_MyWebServicesObjectProvider.GetInstance
            End Get
        End Property

        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
        <MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")>
        Friend NotInheritable Class MyWebServices

            <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
            <DebuggerHidden()>
            Public Overrides Function Equals(ByVal o As Object) As Boolean
                Return MyBase.Equals(o)
            End Function
            <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
            <DebuggerHidden()>
            Public Overrides Function GetHashCode() As Integer
                Return MyBase.GetHashCode()
            End Function
            <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
            <DebuggerHidden()>
            Friend Overloads Function [GetType]() As Type
                Return GetType(MyWebServices)
            End Function
            <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
            <DebuggerHidden()>
            Public Overrides Function ToString() As String
                Return MyBase.ToString()
            End Function

            <DebuggerHidden()>
            Private Shared Function Create__Instance__(Of T As New)(ByVal instance As T) As T
                If instance Is Nothing Then
                    Return New T()
                Else
                    Return instance
                End If
            End Function

            <DebuggerHidden()>
            Private Sub Dispose__Instance__(Of T)(ByRef instance As T)
                instance = Nothing
            End Sub

            <DebuggerHidden()>
            <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
                MyBase.New()
            End Sub
        End Class

        Private ReadOnly m_MyWebServicesObjectProvider As ThreadSafeObjectProvider(Of MyWebServices) = New ThreadSafeObjectProvider(Of MyWebServices)()
        ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If
        ' 
        ' TODO ERROR: Skipped IfDirectiveTrivia
        ' #If _MYTYPE = "Web" Then
        ' ' TODO ERROR: Skipped DisabledTextTrivia
        ' 
        ' <Global.System.ComponentModel.Design.HelpKeyword("My.Request")> _
        ' Friend ReadOnly Property Request() As Global.System.Web.HttpRequest
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Get
        ' Dim CurrentContext As Global.System.Web.HttpContext = Global.System.Web.HttpContext.Current
        ' If CurrentContext IsNot Nothing Then
        ' Return CurrentContext.Request
        ' End If
        ' Return Nothing
        ' End Get
        ' End Property
        ' 
        ' <Global.System.ComponentModel.Design.HelpKeyword("My.Response")> _
        ' Friend ReadOnly Property Response() As Global.System.Web.HttpResponse
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Get
        ' Dim CurrentContext As Global.System.Web.HttpContext = Global.System.Web.HttpContext.Current
        ' If CurrentContext IsNot Nothing Then
        ' Return CurrentContext.Response
        ' End If
        ' Return Nothing
        ' End Get
        ' End Property
        ' 
        ' <Global.System.ComponentModel.Design.HelpKeyword("My.Application.Log")> _
        ' Friend ReadOnly Property Log() As Global.Microsoft.VisualBasic.Logging.AspLog
        ' <Global.System.Diagnostics.DebuggerHidden()> _
        ' Get
        ' Return m_LogObjectProvider.GetInstance()
        ' End Get
        ' End Property
        ' 
        ' Private ReadOnly m_LogObjectProvider As New ThreadSafeObjectProvider(Of Global.Microsoft.VisualBasic.Logging.AspLog)
        ' 
        ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
        ' #End If  '_MYTYPE="Web"
        ' 
        <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
        <ComVisible(False)>
        Friend NotInheritable Class ThreadSafeObjectProvider(Of T As New)
            Friend ReadOnly Property GetInstance As T
                ' TODO ERROR: Skipped IfDirectiveTrivia
                ' #If TARGET = "library" Then
                ' 
                <DebuggerHidden()>
                Get
                    Dim Value = m_Context.Value
                    If Value Is Nothing Then
                        Value = New T()
                        m_Context.Value = Value
                    End If
                    Return Value
                End Get
                ' TODO ERROR: Skipped ElseDirectiveTrivia
                ' #Else
                ' ' TODO ERROR: Skipped DisabledTextTrivia
                ' <Global.System.Diagnostics.DebuggerHidden()> _
                ' Get
                ' If m_ThreadStaticValue Is Nothing Then m_ThreadStaticValue = New T
                ' Return m_ThreadStaticValue
                ' End Get
                ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
                ' #End If
                ' 
            End Property

            <DebuggerHidden()>
            <ComponentModel.EditorBrowsable(ComponentModel.EditorBrowsableState.Never)>
            Public Sub New()
                MyBase.New()
            End Sub

            ' TODO ERROR: Skipped IfDirectiveTrivia
            ' #If TARGET = "library" Then
            ' 
            Private ReadOnly m_Context As MyServices.Internal.ContextValue(Of T) = New MyServices.Internal.ContextValue(Of T)()
            ' TODO ERROR: Skipped ElseDirectiveTrivia
            ' #Else
            ' ' TODO ERROR: Skipped DisabledTextTrivia
            ' <Global.System.Runtime.CompilerServices.CompilerGenerated(), Global.System.ThreadStatic()> Private Shared m_ThreadStaticValue As T
            ' ' TODO ERROR: Skipped EndIfDirectiveTrivia
            ' #End If
            ' 
        End Class
    End Module
End Namespace
' TODO ERROR: Skipped EndIfDirectiveTrivia
' #End If
' 