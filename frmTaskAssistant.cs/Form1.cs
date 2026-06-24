namespace frmTaskAssistant.cs
{
    public partial class Form1 : Form
    {


        List<string> cyberTasks = new List<string>();

        Dictionary<string, string> taskDescriptions =
            new Dictionary<string, string>();

        Dictionary<string, string> taskReminders =
            new Dictionary<string, string>();

        List<string> activityLog =
            new List<string>();


        int currentQuestion = 0;
        int quizScore = 0;
        bool quizRunning = false;

        List<string> questions =
            new List<string>();

        Dictionary<int, string> answers =
            new Dictionary<int, string>();

        Dictionary<int, string> explanations =
            new Dictionary<int, string>();

        public Form1()
        {
            InitializeComponent();
            LoadTasks();
            LoadQuizQuestions();

            rtbChat.AppendText(
    "Chatbot: WELCOME TO THE CYBERSECURITY ASSISTANT!\n\n" +
    "I CAN HELP YOU:\n" +
    " Add cybersecurity tasks, Set Reminders, " +
    " Take cybersecurity quizzes and  View activity logs\n\n" +
 
    "TRY COMMANDS LIKE:\n" +
    "\"add task review privacy settings\"\n" +
    "\"start quiz\"\n" +
    "\"show activity log\"\n\n");


        }

        private void LoadTasks()
        {
            taskDescriptions.Add(
                "enable two-factor authentication",
                "Adds extra protection to your account.");

            taskDescriptions.Add(
                "review privacy settings",
                "Check your account privacy settings.");

            taskDescriptions.Add(
                "update password",
                "Replace weak passwords.");

            taskDescriptions.Add(
                "backup files",
                "Create secure backups.");
        }
        // method for the quiz questions
        private void LoadQuizQuestions()
        {
            questions.Add(
                "True or False: Password123 is a strong password?");
            answers.Add(0, "false");
            explanations.Add(0,
                "Password123 is easy to guess.");

            questions.Add(
                "Which is phishing?\nA) Scam Email\nB) Antivirus");
            answers.Add(1, "a");
            explanations.Add(1,
                "Phishing uses fake emails.");

            questions.Add(
                "True or False: You should share passwords.");
            answers.Add(2, "false");
            explanations.Add(2,
                "Passwords should remain private.");

            questions.Add(
                "What does 2FA stand for?\nA) Two-Factor Authentication\nB) Two File Access");
            answers.Add(3, "a");
            explanations.Add(3,
                "2FA adds an extra security step.");

            questions.Add(
                "True or False: Antivirus helps protect devices.");
            answers.Add(4, "true");
            explanations.Add(4,
                "Antivirus detects threats.");

            questions.Add(
                "What should you do with suspicious links?\nA) Click\nB) Avoid");
            answers.Add(5, "b");
            explanations.Add(5,
                "Avoid suspicious links.");

            questions.Add(
                "True or False: Public Wi-Fi is always safe.");
            answers.Add(6, "false");
            explanations.Add(6,
                "Public Wi-Fi can be risky.");

            questions.Add(
                "Social engineering attacks:\nA) Manipulate people\nB) Repair computers");
            answers.Add(7, "a");
            explanations.Add(7,
                "Attackers trick people.");

            questions.Add(
                "True or False: Updates improve security.");
            answers.Add(8, "true");
            explanations.Add(8,
                "Updates fix vulnerabilities.");

            questions.Add(
                "Email asks for your password. What do you do?\nA) Reply\nB) Report phishing");
            answers.Add(9, "b");
            explanations.Add(9,
                "Report phishing attempts.");

            questions.Add(
                "True or False: Using the same password everywhere is safe.");
            answers.Add(10, "false");
            explanations.Add(10,
                "Different passwords are safer.");
        }

        // method for adding tasks
        private void AddTask(string task)
        {
            cyberTasks.Add(task);

            string description = "Cybersecurity task added.";

            if (taskDescriptions.ContainsKey(task))
            {
                description = taskDescriptions[task];
            }

            rtbChat.AppendText(
    "Chatbot: Task added with description \"" +
    description +
    "\"\nWould you like a reminder?\n\n");

            activityLog.Add(
                "Task added: " + task);
        }
        private void SetReminder(
    string task,
    string date)
        {
            taskReminders[task] = date;

            rtbChat.AppendText(
                "\nReminder set for " +
                task +
                " on " +
                date);

            activityLog.Add(
                "Reminder set for " +
                task +
                " on " +
                date);
        }
        // method for starting the quiz
        private void StartQuiz()
        {
            quizRunning = true;
            currentQuestion = 0;
            quizScore = 0;

            rtbChat.AppendText(
                "\nCybersecurity Quiz Started!\n");

            AskQuestion();
        }
        // method for questions
        private void AskQuestion()
        {
            if (currentQuestion < questions.Count)
            {
                rtbChat.AppendText(
                    "\nQuestion " +
                    (currentQuestion + 1) +
                    "\n" +
                    questions[currentQuestion] +
                    "\n");
            }
            else
            {
                EndQuiz();
            }
        }
        // method that check the answer
        private void CheckAnswer(
    string userAnswer)
        {
            if (userAnswer.ToLower() ==
                answers[currentQuestion])
            {
                quizScore++;

                rtbChat.AppendText(
                    "\nCorrect!\n");
            }
            else
            {
                rtbChat.AppendText(
                    "\nIncorrect!\n");
            }

            rtbChat.AppendText(
                explanations[currentQuestion] +
                "\n");

            currentQuestion++;

            AskQuestion();
        }
        //Method to end the quiz
        private void EndQuiz()
        {
            quizRunning = false;

            rtbChat.AppendText(
                "\nFinal Score: " +
                quizScore +
                "/" +
                questions.Count);

            if (quizScore >= 8)
            {
                rtbChat.AppendText(
                    "\nGreat Job! You are a cyber security pro!");
            }
            else if (quizScore >= 5)
            {
                rtbChat.AppendText(
                    "\nGood effort!");
            }
            else
            {
                rtbChat.AppendText(
                    "\nKeep practising cybersecurity.");
            }

            activityLog.Add(
                "Quiz completed. Score: " +
                quizScore);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // the button send method
        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.ToLower();

            rtbChat.AppendText(
        "\nUser: " + txtInput.Text + "\n");

            if (quizRunning)
            {
                CheckAnswer(input);

                txtInput.Clear();
                return;
            }

            if (input.Contains("add task"))
            {
                string task =
                    input.Replace(
                        "add task",
                        "").Trim();

                AddTask(task);
            }
            else if (input.Contains("show activity log"))
            {
                foreach (string item in activityLog)
                {
                    rtbChat.AppendText(
                        "\n" + item);
                }
            }
            else if (input.Contains("remind"))
            {
                rtbChat.AppendText(
                    "Chatbot: Got it! I'll remind you in 4 days.\n\n");

                activityLog.Add(
                    "Reminder set for 4 days");
            }

            txtInput.Clear();
        }
        // the start quiz button method
        private void btnQuiz_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }
        // the clear button method
        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChat.Clear();
        }
    }
}
