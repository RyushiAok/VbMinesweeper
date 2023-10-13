<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.btnEasy = New System.Windows.Forms.Button()
        Me.btnNormal = New System.Windows.Forms.Button()
        Me.btnHard = New System.Windows.Forms.Button()
        Me.btnCustom = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnEasy
        '
        Me.btnEasy.Font = New System.Drawing.Font("Meiryo UI", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnEasy.Location = New System.Drawing.Point(92, 133)
        Me.btnEasy.Name = "btnEasy"
        Me.btnEasy.Size = New System.Drawing.Size(540, 103)
        Me.btnEasy.TabIndex = 0
        Me.btnEasy.Text = "      初級   9 × 9"
        Me.btnEasy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEasy.UseVisualStyleBackColor = True
        '
        'btnNormal
        '
        Me.btnNormal.Font = New System.Drawing.Font("Meiryo UI", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnNormal.Location = New System.Drawing.Point(92, 261)
        Me.btnNormal.Name = "btnNormal"
        Me.btnNormal.Size = New System.Drawing.Size(540, 103)
        Me.btnNormal.TabIndex = 1
        Me.btnNormal.Text = "      中級   16 × 16"
        Me.btnNormal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNormal.UseVisualStyleBackColor = True
        '
        'btnHard
        '
        Me.btnHard.Font = New System.Drawing.Font("Meiryo UI", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnHard.Location = New System.Drawing.Point(92, 387)
        Me.btnHard.Name = "btnHard"
        Me.btnHard.Size = New System.Drawing.Size(540, 103)
        Me.btnHard.TabIndex = 2
        Me.btnHard.Text = "      上級   30 × 16"
        Me.btnHard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHard.UseVisualStyleBackColor = True
        '
        'btnCustom
        '
        Me.btnCustom.Font = New System.Drawing.Font("Meiryo UI", 13.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnCustom.Location = New System.Drawing.Point(92, 514)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(540, 103)
        Me.btnCustom.TabIndex = 3
        Me.btnCustom.Text = "      カスタム"
        Me.btnCustom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCustom.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(736, 761)
        Me.Controls.Add(Me.btnCustom)
        Me.Controls.Add(Me.btnHard)
        Me.Controls.Add(Me.btnNormal)
        Me.Controls.Add(Me.btnEasy)
        Me.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu"
        Me.Text = "メニュー"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEasy As System.Windows.Forms.Button
    Friend WithEvents btnNormal As System.Windows.Forms.Button
    Friend WithEvents btnHard As System.Windows.Forms.Button
    Friend WithEvents btnCustom As System.Windows.Forms.Button
End Class
