Public Class AViewModel
    Inherits ViewModelBase

    Private _aInput As String
    Public Property AInput As String
        Get
            Return _aInput
        End Get
        Set(value As String)
            _aInput = value
            OnPropertyChanged(NameOf(AInput))

            ' Update the width based on the input value
            Dim widthValue As Double
            If Double.TryParse(_aInput, widthValue) Then
                RectWidth = widthValue
            End If
        End Set
    End Property

    Private _rectWidth As Double
    Public Property RectWidth As Double
        Get
            Return _rectWidth
        End Get
        Set(value As Double)
            _rectWidth = value
            OnPropertyChanged(NameOf(RectWidth))
        End Set
    End Property

    Public Sub New()
        ' Initialize default values
        AInput = "50"
        RectWidth = 50 ' Default width
    End Sub
End Class
