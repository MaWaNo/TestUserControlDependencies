Public Class MainViewModel
    Inherits ViewModelBase

    Public Property AViewModel As AViewModel
    Public Property BViewModel As BViewModel

    Public Sub New()
        ' Initialize AViewModel and BViewModel inside MainViewModel
        AViewModel = New AViewModel()
        BViewModel = New BViewModel()
    End Sub
End Class