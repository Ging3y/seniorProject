using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace guessingGame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Int32 number;
        Int32 guess;
        Random randNum = new Random();
        List<string> guessBank = new List<string>();
        string displayText;
      

        public MainPage()
        {
            this.InitializeComponent();
            guessButton.IsEnabled = false;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        public void displayGuess()
        {
            displayText = "";

            for (int i = 0; i < guessBank.Count; i++)
            {
                displayText = displayText + guessBank[i] + "\n";
            }
            guessBankLabel.Text = displayText;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            //numberText.Text = Convert.ToString(limitSlider.Value);
            number = Convert.ToInt32((randNum.Next(0, Convert.ToInt16(limitSlider.Value))));

            //disable slider & Set limit Button so they can't reset 
            startButton.IsEnabled = false;
            guessButton.IsEnabled = true;
            rangeLabel.Text = "You a guessing a number from 0 - " + Convert.ToString(limitSlider.Value);

           

        }

        private void guessButton_Click(object sender, RoutedEventArgs e)
        {
            guess = Convert.ToInt32(guessedNumber.Text);


            if (guess == number)
            {
                feedBackLabel.Text = "You got it!";
                startButton.IsEnabled = true;
                guessButton.IsEnabled = false;
            }
            else if (guess > number)
            {
                feedBackLabel.Text = "Lower!";
                guessBank.Add(Convert.ToString(guess) + " (guess lower)");
                displayGuess();
               
            }
            else if (guess < number)
            {
                feedBackLabel.Text = "Higher!";
                guessBank.Add(Convert.ToString(guess) + " (guess higher)");
                displayGuess();

            }
        }
    }
}
