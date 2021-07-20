<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WIrelessIPLabel = New System.Windows.Forms.Label()
        Me.USBSerialLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ConstateLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AuthStateLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DebloatBox = New System.Windows.Forms.CheckedListBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ConstateLabel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.AuthStateLabel)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.USBSerialLabel)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.WIrelessIPLabel)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(364, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 112)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Wireless IP:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'WIrelessIPLabel
        '
        Me.WIrelessIPLabel.Location = New System.Drawing.Point(79, 4)
        Me.WIrelessIPLabel.Name = "WIrelessIPLabel"
        Me.WIrelessIPLabel.Size = New System.Drawing.Size(118, 23)
        Me.WIrelessIPLabel.TabIndex = 1
        Me.WIrelessIPLabel.Text = "0.0.0.0"
        Me.WIrelessIPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'USBSerialLabel
        '
        Me.USBSerialLabel.Location = New System.Drawing.Point(79, 27)
        Me.USBSerialLabel.Name = "USBSerialLabel"
        Me.USBSerialLabel.Size = New System.Drawing.Size(118, 23)
        Me.USBSerialLabel.TabIndex = 3
        Me.USBSerialLabel.Text = "Unknown"
        Me.USBSerialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(4, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "USB Serial: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConstateLabel
        '
        Me.ConstateLabel.Location = New System.Drawing.Point(107, 73)
        Me.ConstateLabel.Name = "ConstateLabel"
        Me.ConstateLabel.Size = New System.Drawing.Size(90, 23)
        Me.ConstateLabel.TabIndex = 7
        Me.ConstateLabel.Text = "Not connected"
        Me.ConstateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 23)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Connection Status"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AuthStateLabel
        '
        Me.AuthStateLabel.Location = New System.Drawing.Point(120, 50)
        Me.AuthStateLabel.Name = "AuthStateLabel"
        Me.AuthStateLabel.Size = New System.Drawing.Size(77, 23)
        Me.AuthStateLabel.TabIndex = 5
        Me.AuthStateLabel.Text = "Unauthorized"
        Me.AuthStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(4, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 23)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Authorization State:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DebloatBox
        '
        Me.DebloatBox.FormattingEnabled = True
        Me.DebloatBox.Items.AddRange(New Object() {"Bixby", "Samsung Pass / Samsung Pay", "Facebook", "Samsung Game Launcher", "Gear VR", "DeX", "LED Cover", "Samsung Browser", "Samsung Email", "Print Services", "Kids", "[More coming soon]"})
        Me.DebloatBox.Location = New System.Drawing.Point(13, 13)
        Me.DebloatBox.Name = "DebloatBox"
        Me.DebloatBox.Size = New System.Drawing.Size(176, 184)
        Me.DebloatBox.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(13, 379)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(551, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Debloat my ass"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(371, 196)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(193, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Reboot my ass"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(576, 414)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DebloatBox)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "Form1"
        Me.Text = "Sapphire's S21 Debloater"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents USBSerialLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents WIrelessIPLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ConstateLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AuthStateLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DebloatBox As CheckedListBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
