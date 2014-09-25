Public Class clsMain
    Implements Quasi97.iHOption

    Private Enum SecLevel As Byte
        LOperator = 0
        LEngineer = 1
    End Enum

    Private qst As Quasi97.Application
    Private myFrm As New frmPopup

    Private Sub NotifyProductionCompleteHandler(ByVal msg$, ByVal msgColor As Integer)
        If myFrm.IsDisposed Then myFrm = New frmPopup

        'connect to production test
        myFrm.failcodelist.Items.Clear()
        myFrm.failcodelist.ForeColor = Color.FromArgb(msgColor)
        myFrm.failcodelist.Items.Add(msg)

        'the form default location is center screen
        myFrm.Show() 'show the form in the center of the screen
        myFrm.TopMost = True 'show on top of all other menus

        qst.GetMainModNew.RootForm.Focus()
    End Sub

    Public Sub Initialize3(InstanceName As String, ByRef AppPtr As Object) Implements Quasi97.iHOption.Initialize3
        qst = AppPtr    'save pointer to QST workspace for future use
        AddHandler qst.GetMainModNew.evNotifyProductionComplete, AddressOf NotifyProductionCompleteHandler
    End Sub

    Public Sub Terminate() Implements Quasi97.iHOption.Terminate
        If qst IsNot Nothing Then RemoveHandler qst.GetMainModNew.evNotifyProductionComplete, AddressOf NotifyProductionCompleteHandler
        qst = Nothing   'disconnect pointer from QSt workspace
    End Sub

    Public ReadOnly Property EventInterests As Integer Implements Quasi97.iHOption.EventInterests
        Get
            Return 0 '
        End Get
    End Property

#Region "Unused"

    Public Sub ShowUserMenu() Implements Quasi97.iHOption.ShowUserMenu
        'do nothing
    End Sub

    Public Sub StartStop(ByRef doStart As Boolean) Implements Quasi97.iHOption.StartStop

    End Sub

    Public Sub AddNotifier(ByRef objnot As Object) Implements Quasi97.iHOption.AddNotifier
        'do nothing
    End Sub

    Public Function CheckHealth(ByRef usrDescr As String, PartLoadedState As Byte) As Short Implements Quasi97.iHOption.CheckHealth
        Return 0
        'do nothing
    End Function

    Public Sub ConnectHead(ByRef doConnect As Byte) Implements Quasi97.iHOption.ConnectHead

    End Sub

    Public Sub CurrentHeadInitiate(ByRef hdnum As Short) Implements Quasi97.iHOption.CurrentHeadInitiate

    End Sub

    Public Sub CurrentHeadTerminate(hdNum As Short) Implements Quasi97.iHOption.CurrentHeadTerminate

    End Sub

    Public Sub DetectAllNew(ByRef Devs1Based() As String) Implements Quasi97.iHOption.DetectAllNew

    End Sub

    Public Sub GetChannels(ByRef Channels() As Short) Implements Quasi97.iHOption.GetChannels

    End Sub

    Public Function GetNewProperties2(ByRef propDetails(,) As String) As Object Implements Quasi97.iHOption.GetNewProperties2
        Return Nothing
    End Function

    Public WriteOnly Property NetHostCallBack As Object Implements Quasi97.iHOption.NetHostCallBack
        Set(value As Object)
            'do nothing
        End Set
    End Property

    Public Sub NotifyOptionsUpdated() Implements Quasi97.iHOption.NotifyOptionsUpdated

    End Sub

    Public Function Recover(ByRef usrDescr As String) As Short Implements Quasi97.iHOption.Recover
        Return 0
    End Function

    Public Sub RemoveNotifier(ByRef objnot As Object) Implements Quasi97.iHOption.RemoveNotifier

    End Sub

    Public Sub SetChannels(ByRef Channels() As Short) Implements Quasi97.iHOption.SetChannels

    End Sub

    Public Sub SetupOpenClose(DoOpen As Boolean) Implements Quasi97.iHOption.SetupOpenClose

    End Sub

    Public Sub ShowDiagnostics() Implements Quasi97.iHOption.ShowDiagnostics

    End Sub

    Public ReadOnly Property Status As Short Implements Quasi97.iHOption.Status
        Get
            Return 0 'Quasi97.clsHardwareOption.HDWOptStat.Missing 
        End Get
    End Property

    Public ReadOnly Property UserControl As String Implements Quasi97.iHOption.UserControl
        Get
            Return ""
        End Get
    End Property
#End Region

End Class
