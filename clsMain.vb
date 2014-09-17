Public Class clsMain
    Implements Quasi97.iHOption

    Private Enum SecLevel As Byte
        LOperator = 0
        LEngineer = 1
    End Enum

    Private qst As Quasi97.Application
    Private myFrm As New frmPopup

    Public Sub Initialize3(InstanceName As String, ByRef AppPtr As Object) Implements Quasi97.iHOption.Initialize3
        qst = AppPtr    'save pointer to QST workspace for future use
    End Sub

    Public Sub Terminate() Implements Quasi97.iHOption.Terminate
        qst = Nothing   'disconnect pointer from QSt workspace
    End Sub

    Public ReadOnly Property EventInterests As Integer Implements Quasi97.iHOption.EventInterests
        Get
            Return Quasi97.clsOptionManager.eEventInt.eStartStop 'let Quasi97 know that you want it to call startstop function on your module
        End Get
    End Property

    Public Sub ShowUserMenu() Implements Quasi97.iHOption.ShowUserMenu
        If qst Is Nothing Then Return
        If myFrm.IsDisposed Then myFrm = New frmPopup

        'connect to production test
        Dim ProdTest As Quasi97.clsTestSeqNET = CType(qst.QuasiParameters.TestObj("Production", 1).TestPtr, Quasi97.clsTestSeqNET)
        myFrm.failcodelist.Items.Clear()

        myFrm.failcodelist.ForeColor = Color.Green
        If qst.OptionsParameters.Grading Then 'if grading is disabled then no need to check the list, there will be no failed items
            'extract most recent failcodes
            For i = 0 To ProdTest.colResults.Count - 1
                If ProdTest.colResults(i).PASSLIST.Count = 0 Then 'only show parts that failed some grade
                    'myFrm.failcodelist.Items.Add(ProdTest.colResults(i).Head & " - " & ProdTest.colResults(i).FailCodeHex)
                    myFrm.failcodelist.Items.Add(ProdTest.colResults(i).Head & " - " & ProdTest.colResults(i).GetResult("DEFECT_CODE_BY_HEAD - Production").ToString)
                    If ProdTest.colResults(i).FailCode <> 0 Then myFrm.failcodelist.ForeColor = Color.Red
                End If
            Next i
        End If

        If myFrm.failcodelist.Items.Count = 0 Then Return 'don't show if there are no failed items

        'the form default location is center screen
        myFrm.Show() 'show the form in the center of the screen
        myFrm.TopMost = True 'show on top of all other menus

        qst.GetMainModNew.RootForm.Focus()
    End Sub

    Private ProdTestStarted As Boolean = False 'flag to keep track when production test starts, so that we don't display menu when closing setup file
    Public Sub StartStop(ByRef doStart As Boolean) Implements Quasi97.iHOption.StartStop
        'this method will be called by Quasi97 when production test finishes
        If qst.QuasiParameters.SecurityLevel <> SecLevel.LOperator Then Return
        If Not doStart And prodteststarted Then
            ShowUserMenu()
            ProdTestStarted = False
        ElseIf doStart Then 'to avoid hide right away
            If Not myFrm.IsDisposed Then myFrm.Hide()
            ProdTestStarted = True
        End If
    End Sub

#Region "Unused"
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
