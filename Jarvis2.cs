using System;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
namespace SpeechWindowsForms
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer JARVIS = new SpeechSynthesizer();
        string QEvent;
        string ProcWindow;
        double timer = 10;
        int count = 1;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"txt file location")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum = rnd.Next(1, 10);
            string speech = e.Result.Text;
            switch (speech)
            {
                //GREETINGS
                case "hello":
                case "hello jarvis":
                    if (ranNum < 6) { sSynth.SpeakAsync("Hello sir"); }
                    else if (ranNum > 5) { sSynth.SpeakAsync("Hi"); }
                    break;
                case "goodbye":
                case "goodbye jarvis":
                case "close":
                case "close jarvis":
                    sSynth.SpeakAsync("Until next time");
                    Close();
                    break;
                case "jarvis":
                    if (ranNum < 5) { QEvent = ""; sSynth.SpeakAsync("Yes sir"); }
                    else if (ranNum > 4) { QEvent = ""; sSynth.SpeakAsync("Yes?"); }
                    break;

                //WEBSITES
                case "open website":
                    System.Diagnostics.Process.Start("url");
                    break;

                //SHELL COMMANDS
                case "open program":
                    System.Diagnostics.Process.Start("file location");
                    sSynth.SpeakAsync("Loading");
                    break;

                //CLOSE PROGRAMS
                case "close program":
                    ProcWindow = "process name";
                    StopWindow();
                    break;

                //CONDITION OF DAY
                case "what time is it":
                    DateTime now = DateTime.Now;
                    string time = now.GetDateTimeFormats('t')[0];
                    sSynth.SpeakAsync(time);
                    break;
                case "what day is it":
                    sSynth.SpeakAsync(DateTime.Today.ToString("dddd"));
                    break;
                case "whats the date":
                case "whats todays date":
                    sSynth.SpeakAsync(DateTime.Today.ToString("dd-MM-yyyy"));
                    break;

                //OTHER COMMANDS
                case "go fullscreen":
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                    TopMost = true;
                    sSynth.SpeakAsync("expanding");
                    break;
                case "exit fullscreen":
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    TopMost = false;
                    break;
                case "switch window":
                    SendKeys.Send("%{TAB " + count + "}");
                    count += 1;
                    break;
                case "reset":
                    count = 1;
                    timer = 11;
                    lblTimer.Visible = false;
                    ShutdownTimer.Enabled = false;
                    lstCommands.Visible = false;
                    break;
                case "out of the way":
                    if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
                    {
                        WindowState = FormWindowState.Minimized;
                        sSynth.SpeakAsync("My apologies");
                    }
                    break;
                case "come back":
                    if (WindowState == FormWindowState.Minimized)
                    {
                        sSynth.SpeakAsync("Alright?");
                        WindowState = FormWindowState.Normal;
                    }
                    break;
                case "show commands":
                    string[] commands = (File.ReadAllLines(@"txt file location"));
                    sSynth.SpeakAsync("Very well");
                    lstCommands.Items.Clear();
                    lstCommands.SelectionMode = SelectionMode.None;
                    lstCommands.Visible = true;
                    foreach (string command in commands)
                    {
                        lstCommands.Items.Add(command);
                    }
                    break;
                case "hide listbox":
                    lstCommands.Visible = false;
                    break;        
         }
        }
       }
}