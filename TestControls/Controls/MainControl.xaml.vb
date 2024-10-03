Public Class MainControl
    Private _mainViewModel As MainViewModel

    Public Sub New()
        InitializeComponent()

        ' Initialize MainViewModel and assign it as DataContext
        _mainViewModel = New MainViewModel()
        DataContext = _mainViewModel

        ' Set DataContexts for AControl and BControl
        'AControl.DataContext = _mainViewModel.AViewModel
        'BControl.DataContext = _mainViewModel.BViewModel

        ' Subscribe to property changed events for drawing updates
        AddHandler _mainViewModel.AViewModel.PropertyChanged, AddressOf OnViewModelChanged
        AddHandler _mainViewModel.BViewModel.PropertyChanged, AddressOf OnViewModelChanged

        DrawRectangle()
    End Sub

    ' This method will handle property changes and redraw the rectangle
    Private Sub OnViewModelChanged(sender As Object, e As ComponentModel.PropertyChangedEventArgs)
        ' Redraw the rectangle when either RectWidth or RectHeight changes
        If e.PropertyName = "RectWidth" OrElse e.PropertyName = "RectHeight" Then
            DrawRectangle()
        End If
    End Sub

    ' Method to draw rectangle and lines on the canvas
    Private Sub DrawRectangle()
        ' Clear existing children from the canvas
        canvas.Children.Clear()

        ' Create a new rectangle with the current dimensions
        Dim rect As New System.Windows.Shapes.Rectangle With {
            .Width = _mainViewModel.AViewModel.RectWidth, ' Use RectWidth from AViewModel
            .Height = _mainViewModel.BViewModel.RectHeight, ' Use RectHeight from BViewModel
            .Fill = Brushes.SandyBrown,
            .Stroke = Brushes.Black
        }

        ' Create diagonal lines across the rectangle
        Dim line1 As New Line With {
            .X1 = 50, .Y1 = 50,
            .X2 = 50 + _mainViewModel.AViewModel.RectWidth,
            .Y2 = 50 + _mainViewModel.BViewModel.RectHeight,
            .Stroke = Brushes.Black
        }
        Dim line2 As New Line With {
            .X1 = 50, .Y1 = 50 + _mainViewModel.BViewModel.RectHeight,
            .X2 = 50 + _mainViewModel.AViewModel.RectWidth,
            .Y2 = 50,
            .Stroke = Brushes.Black
        }

        ' Set rectangle position (top-left corner of the canvas)
        Canvas.SetLeft(rect, 50)
        Canvas.SetTop(rect, 50)

        ' Add the rectangle and lines to the canvas
        canvas.Children.Add(rect)
        canvas.Children.Add(line1)
        canvas.Children.Add(line2)
    End Sub
End Class
