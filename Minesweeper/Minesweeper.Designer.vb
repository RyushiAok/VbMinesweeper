<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Minesweeper
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Minesweeper))
        Me.pnlMap = New System.Windows.Forms.Panel()
        Me.picDisp = New System.Windows.Forms.PictureBox()
        CType(Me.picDisp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMap
        '
        Me.pnlMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMap.AutoScroll = True
        Me.pnlMap.Location = New System.Drawing.Point(0, 0)
        Me.pnlMap.Name = "pnlMap"
        Me.pnlMap.Size = New System.Drawing.Size(1058, 922)
        Me.pnlMap.TabIndex = 1
        '
        'picDisp
        '
        Me.picDisp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.picDisp.Location = New System.Drawing.Point(0, 0)
        Me.picDisp.Name = "picDisp"
        Me.picDisp.Size = New System.Drawing.Size(1146, 1020)
        Me.picDisp.TabIndex = 0
        Me.picDisp.TabStop = False
        '
        'Minesweeper
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1375, 1129)
        Me.Controls.Add(Me.picDisp)
        Me.Controls.Add(Me.pnlMap)
        Me.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Minesweeper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minesweeper"
        CType(Me.picDisp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMap As System.Windows.Forms.Panel
    Friend WithEvents picDisp As System.Windows.Forms.PictureBox

End Class
