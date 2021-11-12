Public NotInheritable Class FrmSobre
    'Simplesmente fecha o diálogo
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub FrmSobre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBoxDescription.Text = "Sistemas Operacionais" & vbCrLf & _
                                  "Objeto de Aprendiagem" & vbCrLf & _
                                  "Escalonamento de Processos " & vbCrLf & vbCrLf & _
                                  "Orientador: Prof. Msc. Edeyson Andrade Gomes" & vbCrLf & _
                                  "edeyson@ifba.edu.br"
    End Sub

    Private Sub LabelProductName_Click(sender As Object, e As EventArgs) Handles LabelProductName.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
