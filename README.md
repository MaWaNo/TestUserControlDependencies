# TestControls
We have `AControl` and `BControl` that will be used together as Items in a `MainControl`.
If one of the two control properties change, then a redraw of the rectangle in the `canvas` of the `MainContol` will be started.
We just need `INotifyPropertyChanged` for this purpose.
