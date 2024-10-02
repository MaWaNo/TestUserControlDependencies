Public Class MainControl
    Private _mainViewModel As MainViewModel
    Private _aViewModel As AViewModel
    Private _bViewModel As BViewModel

    Public Sub New()
        InitializeComponent()

        ' Initialize MainViewModel and assign it as DataContext
        _mainViewModel = New MainViewModel()
        DataContext = _mainViewModel

        ' Initialize AControl and BControl with their ViewModels
        _aViewModel = New AViewModel()
        _bViewModel = New BViewModel()

        ' Set DataContexts for AControl and BControl
        AControl.DataContext = _aViewModel
        BControl.DataContext = _bViewModel

        ' Subscribe to property changed events for drawing updates
        AddHandler _aViewModel.PropertyChanged, AddressOf OnViewModelChanged
        AddHandler _bViewModel.PropertyChanged, AddressOf OnViewModelChanged
    End Sub

    ' This method will handle property changes and redraw the rectangle
    Private Sub OnViewModelChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        ' Redraw the rectangle when either RectWidth or RectHeight changes
        If e.PropertyName = "RectWidth" OrElse e.PropertyName = "RectHeight" Then
            DrawRectangle()
        End If
    End Sub

    ' Method to draw rectangle on the canvas
    Private Sub DrawRectangle()
        ' Clear existing children from the canvas
        canvas.Children.Clear()

        ' Create a new rectangle with the current dimensions
        Dim rect As New System.Windows.Shapes.Rectangle With {
            .Width = _aViewModel.RectWidth, ' Use RectWidth from AViewModel
            .Height = _bViewModel.RectHeight, ' Use RectHeight from BViewModel
            .Fill = Brushes.SandyBrown,
            .Stroke = Brushes.Black
        }

        Dim line1 As New Line With {
            .X1 = 50, .Y1 = 50, .X2 = 50 + _aViewModel.RectWidth, .Y2 = 50 + _bViewModel.RectHeight,
            .Stroke = Brushes.Black}
        Dim line2 As New Line With {
            .X1 = 50, .Y1 = 50 + _bViewModel.RectHeight, .X2 = 50 + _aViewModel.RectWidth, .Y2 = 50,
            .Stroke = Brushes.Black}

        ' Set rectangle position (top-left corner of the canvas)
        Canvas.SetLeft(rect, 50) ' Adjust the position as needed
        Canvas.SetTop(rect, 50)

        ' Add the rectangle to the canvas
        canvas.Children.Add(rect)
        canvas.Children.Add(line1)
        canvas.Children.Add(line2)

    End Sub
End Class
