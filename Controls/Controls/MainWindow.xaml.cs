// -----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace Controls
{
    using Microsoft.UI.Xaml;

    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.nbOperationPerHourChart.tdte = new () { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
        }

        /// <summary>
        /// Called.
        /// </summary>
        /// <param name="sender">zd.</param>
        /// <param name="e">dz.</param>
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            this.nbOperationPerHourChart.tdte = new () { 5, 3, 2, 3, 4, 8, 6, 7, 8, 9, 10, 24, 12, 13, 14, 0, 16, 17, 3, 19, 20, 1, 2, 2 };
        }
    }
}
