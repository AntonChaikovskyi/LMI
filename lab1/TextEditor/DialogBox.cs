    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TextEditor;
public static class DialogBox
{
    public static string ShowDialog(string text, string caption)
    {
        // Create the Window for the dialog
        Window dialogWindow = new Window
        {
            Title = caption,
            Width = 300,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            ResizeMode = ResizeMode.NoResize,
            Owner = Application.Current.MainWindow,
        };

        // Create a StackPanel to arrange dialog content
        StackPanel stackPanel = new StackPanel { Margin = new Thickness(10) };

        // Create the text label
        TextBlock textBlock = new TextBlock
        {
            Text = text,
            Margin = new Thickness(0, 0, 0, 10),
        };

        // Create the TextBox for user input
        TextBox inputTextBox = new TextBox
        {
            Width = 250
        };

        // Create the buttons (OK and Cancel)
        Button okButton = new Button { Content = "OK", Width = 75, Margin = new Thickness(0, 10, 10, 0), IsDefault = true };
        Button cancelButton = new Button { Content = "Cancel", Width = 75, Margin = new Thickness(10, 10, 0, 0), IsCancel = true };

        // Create a panel for buttons
        StackPanel buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Center };
        buttonPanel.Children.Add(okButton);
        buttonPanel.Children.Add(cancelButton);

        // Add everything to the stack panel
        stackPanel.Children.Add(textBlock);
        stackPanel.Children.Add(inputTextBox);
        stackPanel.Children.Add(buttonPanel);

        // Set the content of the window
        dialogWindow.Content = stackPanel;

        // Set the event for the OK button
        okButton.Click += (sender, e) =>
        {
            dialogWindow.DialogResult = true;
            dialogWindow.Close();
        };

        // Show the dialog and return the input when the OK button is clicked
        if (dialogWindow.ShowDialog() == true)
        {
            return inputTextBox.Text;
        }

        return null; // Return null if canceled
    }
}
