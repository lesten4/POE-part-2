namespace frmTaskAssistant.cs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rtbChat = new RichTextBox();
            txtInput = new TextBox();
            btnSend = new Button();
            btnQuiz = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // rtbChat
            // 
            rtbChat.BackColor = Color.DarkOrange;
            rtbChat.ForeColor = SystemColors.Window;
            rtbChat.Location = new Point(79, 52);
            rtbChat.Name = "rtbChat";
            rtbChat.Size = new Size(574, 237);
            rtbChat.TabIndex = 0;
            rtbChat.Text = "";
            // 
            // txtInput
            // 
            txtInput.BackColor = Color.DarkOrange;
            txtInput.ForeColor = SystemColors.Window;
            txtInput.Location = new Point(79, 296);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(331, 23);
            txtInput.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.DarkOrange;
            btnSend.ForeColor = SystemColors.ButtonHighlight;
            btnSend.Location = new Point(416, 296);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // btnQuiz
            // 
            btnQuiz.BackColor = Color.DarkOrange;
            btnQuiz.ForeColor = SystemColors.ControlLightLight;
            btnQuiz.Location = new Point(497, 295);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Size = new Size(75, 23);
            btnQuiz.TabIndex = 3;
            btnQuiz.Text = "Start Quiz";
            btnQuiz.UseVisualStyleBackColor = false;
            btnQuiz.Click += btnQuiz_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkOrange;
            btnClear.ForeColor = SystemColors.ControlLightLight;
            btnClear.Location = new Point(578, 295);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnQuiz);
            Controls.Add(btnSend);
            Controls.Add(txtInput);
            Controls.Add(rtbChat);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbChat;
        private TextBox txtInput;
        private Button btnSend;
        private Button btnQuiz;
        private Button btnClear;
    }
}
