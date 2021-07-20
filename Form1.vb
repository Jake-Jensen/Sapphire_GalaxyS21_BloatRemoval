Public Class Form1

    Dim IsWireless = False
    Dim IsUSB = False
    Dim IsAuthorized = False

    Dim WirelessIP As String = "000.000.000.000"
    Dim USBSerial As String = "Unknown"

    Public Shared ReadOnly Bixby() As String = {"com.samsung.android.bixby.wakeup", "com.samsung.android.app.spage", "com.samsung.android.app.routines", "com.samsung.android.bixby.service", "com.samsung.android.visionintelligence", "com.samsung.android.bixby.agent", "com.samsung.android.bixby.agent.dummy", "com.samsung.android.bixbyvision.framework"}
    Public Shared ReadOnly PassPay() As String = {"com.samsung.android.samsungpassautofill", "com.samsung.android.authfw", "com.samsung.android.samsungpass", "com.samsung.android.spay", "com.samsung.android.spayfw"}
    Public Shared ReadOnly Facebook() As String = {"com.facebook.katana", "com.facebook.system", "com.facebook.appmanager", "com.facebook.services"}
    Public Shared ReadOnly GameLauncher() As String = {"com.samsung.android.game.gamehome", "com.enhance.gameservice", "com.samsung.android.game.gametools", "com.samsung.android.game.gos", "com.samsung.android.gametuner.thin"}
    Public Shared ReadOnly GearVR() As String = {"com.samsung.android.hmt.vrsvc", "com.samsung.android.app.vrsetupwizardstub", "com.samsung.android.hmt.vrshell", "com.google.vr.vrcore"}
    Public Shared ReadOnly Dex() As String = {"com.sec.android.desktopmode.uiservice", "com.samsung.desktopsystemui", "com.sec.android.app.desktoplauncher"}
    Public Shared ReadOnly LedCover() As String = {"com.samsung.android.app.ledbackcover", "com.sec.android.cover.ledcover"}
    Public Shared ReadOnly SamBrowser() As String = {"com.sec.android.app.sbrowser", "com.samsung.android.app.sbrowseredge"}
    Public Shared ReadOnly SamEmail() As String = {"com.samsung.android.email.provider", "com.wsomacp"}
    Public Shared ReadOnly Print() As String = {"com.android.bips", "com.google.android.printservice.recommendation", "com.android.printspooler"}
    Public Shared ReadOnly Kids() As String = {"com.samsung.android.kidsinstaller", "com.samsung.android.app.camera.sticker.facearavatar.preload"}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not (My.Computer.FileSystem.FileExists("adb.exe")) Then
            IO.File.WriteAllBytes(Application.StartupPath + "\\adb.exe", My.Resources.adb)
        End If
        If Not (My.Computer.FileSystem.FileExists("AdbWinApi.dll")) Then
            IO.File.WriteAllBytes(Application.StartupPath + "\\AdbWinApi.dll", My.Resources.AdbWinApi)
        End If
        If Not (My.Computer.FileSystem.FileExists("AdbWinUsbApi.dll")) Then
            IO.File.WriteAllBytes(Application.StartupPath + "\\AdbWinUsbApi.dll", My.Resources.AdbWinUsbApi)
        End If

        MsgBox("Because I am fucking lazy, do NOT have multiple devices attached, this includes over tcpip and USB. Disconnecting from every device now." + vbNewLine + vbNewLine + "It is advised to authorize your phone BEFORE starting this program, as again, I am lazy, and haven't really put protections in against an unauthorized device.")
        Exec("disconnect")

        GetConnectedDevices()
    End Sub

    Private Function Exec(ByVal Arguments As String)
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo("adb.exe", Arguments)
        oStartInfo.UseShellExecute = False
        oStartInfo.CreateNoWindow = True
        oStartInfo.RedirectStandardError = True
        oStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oStartInfo
        oProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()

        End Using

        If (sOutput.Length = 0) Then
            Dim eOutput As String
            Using oStreamReader As System.IO.StreamReader = oProcess.StandardError
                eOutput = oStreamReader.ReadToEnd()
            End Using
            Console.WriteLine("Error output: " + eOutput)
            Return eOutput
        Else
            Console.WriteLine(sOutput)
            Return sOutput
        End If

    End Function

    Private Sub GetConnectedDevices()
        Dim Ret As String = Exec("devices")
        Console.WriteLine("Get devices output: " + Ret)
        Ret = Ret.Remove(0, Ret.IndexOf(ControlChars.CrLf) + 2)
        If (Ret.Contains(":5555")) Then
            IsWireless = True
            WirelessIP = Ret.Substring(0, Ret.IndexOf(":"))
            WIrelessIPLabel.Text = WirelessIP
        Else
            If (Ret.Contains("device")) Then
                IsUSB = True
            End If
        End If

        If (Ret.Contains("device")) Then
            AuthStateLabel.Text = "Authorized"
            IsAuthorized = True
            ConstateLabel.Text = "Connected"
        End If

        If (Ret.Contains("Unauthorized")) Then
            AuthStateLabel.Text = "Unauthorized"
        End If
    End Sub

    Private Function UninstallApp(ByVal PackageName As String)
        Dim Ret As String = Exec("shell pm uninstall --user 0 " + PackageName)
        Console.WriteLine("Uninstall result: " + Ret)
        If (Ret.Contains("Success")) Then
            Return True
        Else
            If (Ret.Contains("Failure [not installed for 0]")) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub DoDebloat()
        For i As Integer = 0 To DebloatBox.Items.Count - 1
            If DebloatBox.GetItemChecked(i) = True Then
                If (i = 0) Then
                    Console.WriteLine("Uninstalling Bixby.")
                    For BixbyIndex As Integer = 0 To Bixby.Length - 1
                        Console.WriteLine("Uninstalling package: " + Bixby(BixbyIndex))
                        Dim RetStatus = UninstallApp(Bixby(BixbyIndex))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + Bixby(BixbyIndex) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 1) Then
                    Console.WriteLine("Uninstalling Pass / Pay.")
                    For Index As Integer = 0 To PassPay.Length - 1
                        Console.WriteLine("Uninstalling package: " + PassPay(Index))
                        Dim RetStatus = UninstallApp(PassPay(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + PassPay(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 2) Then
                    Console.WriteLine("Uninstalling Facebook.")
                    For Index As Integer = 0 To Facebook.Length - 1
                        Console.WriteLine("Uninstalling package: " + Facebook(Index))
                        Dim RetStatus = UninstallApp(Facebook(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + Facebook(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 3) Then
                    Console.WriteLine("Uninstalling Samsung Game Launcher")
                    For Index As Integer = 0 To GameLauncher.Length - 1
                        Console.WriteLine("Uninstalling package: " + GameLauncher(Index))
                        Dim RetStatus = UninstallApp(GameLauncher(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + GameLauncher(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 4) Then
                    Console.WriteLine("Uninstalling GearVR")
                    For Index As Integer = 0 To GearVR.Length - 1
                        Console.WriteLine("Uninstalling package: " + GearVR(Index))
                        Dim RetStatus = UninstallApp(GearVR(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + GearVR(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 5) Then
                    Console.WriteLine("Uninstalling DeX")
                    For Index As Integer = 0 To Dex.Length - 1
                        Console.WriteLine("Uninstalling package: " + Dex(Index))
                        Dim RetStatus = UninstallApp(Dex(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + Dex(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 6) Then
                    Console.WriteLine("Uninstalling Led Cover")
                    For Index As Integer = 0 To LedCover.Length - 1
                        Console.WriteLine("Uninstalling package: " + LedCover(Index))
                        Dim RetStatus = UninstallApp(LedCover(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + LedCover(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 7) Then
                    Console.WriteLine("Uninstalling Samsung Browser")
                    For Index As Integer = 0 To SamBrowser.Length - 1
                        Console.WriteLine("Uninstalling package: " + SamBrowser(Index))
                        Dim RetStatus = UninstallApp(SamBrowser(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + SamBrowser(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 8) Then
                    Console.WriteLine("Uninstalling Samsung Email")
                    For Index As Integer = 0 To SamEmail.Length - 1
                        Console.WriteLine("Uninstalling package: " + SamEmail(Index))
                        Dim RetStatus = UninstallApp(SamEmail(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + SamEmail(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 9) Then
                    Console.WriteLine("Uninstalling Print Services")
                    For Index As Integer = 0 To Print.Length - 1
                        Console.WriteLine("Uninstalling package: " + Print(Index))
                        Dim RetStatus = UninstallApp(Print(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + Print(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If

                If (i = 10) Then
                    ' DISABLED
                    MsgBox("Uninstalling Samsung Kids is currently disabled because the S21 Ultra does not come with it preinstalled. In future version, a check against an installed package list will be done.")
                    Exit Sub
                    Console.WriteLine("Uninstalling Kids")
                    For Index As Integer = 0 To Kids.Length - 1
                        Console.WriteLine("Uninstalling package: " + Kids(Index))
                        Dim RetStatus = UninstallApp(Kids(Index))
                        If (RetStatus = False) Then
                            MsgBox("Critical failure, failed to uninstall " + Kids(Index) + vbNewLine + "Aborting immediately.")
                            Exit Sub
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ((IsWireless Or IsUSB) And IsAuthorized) Then
            Console.WriteLine("Running test.")
            Dim RetX = Exec("shell whoami")
            If (RetX.contains("shell")) Then
                Console.WriteLine("Test passed. Debloating based on choices.")
            Else
                MsgBox("Critical failure, failed to get a user from the shell, HARD aborting.")
                Exit Sub
            End If

            DoDebloat()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Ret As String = Exec("shell whoami")
        If (Ret.Contains("shell")) Then
            Exec("reboot")
        Else
            If (Ret.Contains("no devices/emulators found")) Then
                MsgBox("No device connected.")
            Else
                MsgBox("Unknown failure, error description: " + Ret)
            End If
        End If

    End Sub
End Class
