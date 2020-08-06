using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DualScreenDemos
{
    public partial class DragAndDrop : ContentPage
    {
        public DragAndDrop()
        {
            InitializeComponent();
        }

        void ImageDragStarting(System.Object sender, Xamarin.Forms.DragStartingEventArgs e)
        {
            imageFrame.BackgroundColor = Color.Gray;
        }

        void ImageDropCompleted(System.Object sender, Xamarin.Forms.DropCompletedEventArgs e)
        {
            imageFrame.BackgroundColor = Color.LightGray;
        }

        void TextDragStarting(System.Object sender, Xamarin.Forms.DragStartingEventArgs e)
        {
            textFrame.BackgroundColor = Color.Gray;
        }

        void TextDropCompleted(System.Object sender, Xamarin.Forms.DropCompletedEventArgs e)
        {
            textFrame.BackgroundColor = Color.LightGray;
        }

        void ImageDragOver(System.Object sender, Xamarin.Forms.DragEventArgs e)
        {
            if (e.Data?.Image == null)
                e.AcceptedOperation = DataPackageOperation.None;
        }

        void TextDragOver(System.Object sender, Xamarin.Forms.DragEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Data?.Text))
                e.AcceptedOperation = DataPackageOperation.None;
        }

        async void OnDropImage(System.Object sender, Xamarin.Forms.DropEventArgs e)
        {
            DropImage.Source = await e.Data.GetImageAsync();
        }

        async void OnTextDrop(System.Object sender, Xamarin.Forms.DropEventArgs e)
        {
            DropLabel.Text = await e.Data.GetTextAsync();
            ImageDest.IsVisible = false;
        }
    }
}
