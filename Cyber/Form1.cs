using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyber
{
    public partial class rbtChat : Form
    {
        Dictionary<string, string> botResponses =
    new Dictionary<string, string>();

        Dictionary<string, List<string>> keywordResponses =
            new Dictionary<string, List<string>>();

        Dictionary<string, List<string>> sentimentResponses =
    new Dictionary<string, List<string>>();

        Random random = new Random();

        string userName = "";
        string favouriteTopic = "";
        public rbtChat()
        {
            InitializeComponent();
            DisplayLogoInChat();
            SetupResponses();
            BotReply("Hello! Welcome to the Cybersecurity Awareness Bot.");
            BotReply("What is your name?");
        }

       
        // method for the logo
        private void DisplayLogoInChat()
        {
            string logo = @"
                                                                                                                                      
                        ,-----.         ,--.                  ,---.                 ,---.                                                                 
                       '  .--./,--. ,--.|  |-.  ,---. ,--.--.'   .-'  ,---.  ,---. /  O  \ ,--.   ,--. ,--,--.,--.--. ,---. ,--,--,  ,---.  ,---.  ,---.  
                       |  |     \  '  / | .-. '| .-. :|  .--'`.  `-. | .-. :| .--'|  .-.  ||  |.'.|  |' ,-.  ||  .--'| .-. :|      \| .-. :(  .-' (  .-'  
                       '  '--'\  \   '  | `-' |\   --.|  |   .-'    |\   --.\ `--.|  | |  ||   .'.   |\ '-'  ||  |   \   --.|  ||  |\   --..-'  `).-'  `) 
                        `-----'.-'  /    `---'  `----'`--'   `-----'  `----' `---'`--' `--''--'   '--' `--`--'`--'    `----'`--''--' `----'`----' `----'  
                              `---'                                                                                                                           

        CYBERSECURITY AWARENESS BOT
--------------------------------------------------------
";

            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            richTextBox1.AppendText(logo + Environment.NewLine);

            // move back to left alignment for bot messages
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void SetupResponses()
        {
            botResponses.Add("how are you",
                "I'm doing well and ready to help.") ;

            botResponses.Add("what is your purpose",
                "My purpose is to help users stay safe online.");

            botResponses.Add("what can i ask about",
                "You can ask about password safety, phishing, privacy and safe browsing.");

            keywordResponses["password"] = new List<string>()
{
    "Use strong and unique passwords.",
    "Never reuse passwords on multiple accounts.",
    "Use a password manager if possible."
};

            keywordResponses["scam"] = new List<string>()
{
    "Be careful of scam emails asking for information.",
    "Never click suspicious links.",
    "Scammers often pretend to be trusted companies."
};

            keywordResponses["privacy"] = new List<string>()
{
    "Check your privacy settings regularly.",
    "Keep personal information private online.",
    "Use two-factor authentication to protect your privacy."
};
            sentimentResponses["worried"] = new List<string>()
{
    "It's completely understandable to feel that way.",
    "That makes sense. Online threats can feel overwhelming sometimes.",
    "It's okay to feel worried—cybersecurity can be confusing at first."
};

            sentimentResponses["curious"] = new List<string>()
{
    "I’m glad you’re curious about cybersecurity.",
    "That’s a great topic to explore.",
    "Curiosity is one of the best ways to stay safe online."
};

            sentimentResponses["frustrated"] = new List<string>()
{
    "I understand your frustration.",
    "That sounds frustrating, but we can work through it together.",
    "Cybersecurity issues can definitely be frustrating sometimes."
};

        } 

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        // button send method 
        private void btnSend_Click(object sender, EventArgs e)
        {

            string input = txtUserInput.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(input))
            {
                BotReply("Please type something first.");
                return;
            }
            UserReply(txtUserInput.Text);

            if (string.IsNullOrEmpty(userName))
            {
                userName = input;

                BotReply($"Nice to meet you {userName}.");
                BotReply("What cybersecurity topic interests you most?");
                txtUserInput.Clear();
                return;
            }
            if (input.Contains("interested in"))
            {
                favouriteTopic = input.Split(' ').Last();

                BotReply($"Great {userName}, I'll remember that you're interested in {favouriteTopic}.");
                return;
            }
            if (input.Contains("remember"))
            {
                BotReply($"You told me you're interested in {favouriteTopic}. You may want to review your security settings.");
                return;
            }
            foreach (var response in botResponses)
            {
                if (input.Contains(response.Key))
                {
                    BotReply(response.Value);
                    return;
                }
            }
            foreach (var keyword in keywordResponses)
            {
                if (input.Contains(keyword.Key))
                {
                    List<string> replies = keyword.Value;

                    int randomIndex = random.Next(replies.Count);

                    BotReply(replies[randomIndex]);
                    BotReply("Would you like another tip?");
                    return;
                }
                
            }
           

            bool responseFound = false;


            // SENTIMENT DETECTION
            foreach (var sentiment in sentimentResponses)
            {
                if (input.Contains(sentiment.Key))
                {
                    BotReply(GetRandomResponse(sentiment.Value));
                    responseFound = true;
                    break;
                }
            }


            // KEYWORD DETECTION
            foreach (var keyword in keywordResponses)
            {
                if (input.Contains(keyword.Key))
                {
                    BotReply(GetRandomResponse(keyword.Value));
                    responseFound = true;
                    break;
                }
            }


            // DEFAULT RESPONSE
            if (!responseFound)
            {
                BotReply("I did not get that, may you please rephrase?");
            }


        }
        private void BotReply(string message)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
            richTextBox1.AppendText("Bot: " + message + Environment.NewLine);
        }
        private void UserReply(string message)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.AppendText("User: " + message + Environment.NewLine);
        }

        private string GetRandomResponse(List<string> responses)
        {
            int index = random.Next(responses.Count);
            return responses[index];
        }
        // Method for the clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            txtUserInput.Clear();

            BotReply("Chat cleared.");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
