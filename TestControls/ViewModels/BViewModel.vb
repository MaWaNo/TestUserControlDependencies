Public Class BViewModel
    Inherits ViewModelBase

    Private _selectedIndex As Integer
    Public Property SelectedIndex As Integer
        Get
            Return _selectedIndex
        End Get
        Set(value As Integer)
            _selectedIndex = value
            OnPropertyChanged(NameOf(SelectedIndex))

            ' Update the height based on the selected index
            Select Case _selectedIndex
                Case 0
                    RectHeight = 50
                Case 1
                    RectHeight = 100
                Case 2
                    RectHeight = 150
            End Select
        End Set
    End Property

    Private _rectHeight As Double
    Public Property RectHeight As Double
        Get
            Return _rectHeight
        End Get
        Set(value As Double)
            _rectHeight = value
            OnPropertyChanged(NameOf(RectHeight)) ' Trigger PropertyChanged event for RectHeight
        End Set
    End Property

    Public Sub New()
        ' Initialize default values
        RectHeight = 50 ' Default height for the first item (index 0)
        SelectedIndex = 0 ' Default to first index
    End Sub
End Class
