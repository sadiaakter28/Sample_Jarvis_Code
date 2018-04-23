using System; // Namespace Declaration
using System.Collections.Generic;//System.Collections.Generic Namespace. The System.Collections.Generic namespace contains interfaces and classes that define generic collections, which allow users to create strongly typed collections that provide better type safety and performance than non-generic strongly typed collections.//
using System.IO;//System.IO namespace is used for Input Output operations.
//System.IO is a Child of System namespace.
using System.ComponentModel;//System.ComponentModel namespace exists for supporting component development - components can be visual (controls) and non-visuals.
using System.Data;
using System.Drawing;
using System.Linq;//The System.Linq namespace provides classes and interfaces that support queries that use Language-Integrated Query (LINQ).
using System.Text;//The System.Text namespace contains classes, abstract base classes and helper classes
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;      //will allow us to creat a topping voice(sText to Speech)
using System.Speech.Recognition;    //will allow the computer to recognize our voice
using System.Threading;             //take support of the recognization

namespace Speaker
{ //code declarations
    public partial class Form1 : Form
//public partial class Form1 : Form By using partial it is possible to write the definition of same class in two different source file in the same namespace.It will be treated as same during compilation.You can find a class with same name Form1 in your project which is created automatically.
//Form1 is the name of the Form and : is used to inherit the properties of base class . Here Form represents System.Windows.Forms.Form. We are inheriting to access the properties and methods of base class.
    {
        public Form1()
        {
            InitializeComponent();             //InitializeComponent() method in Visual Studio.NET C# or VB.NET is method that is automatically created and managed by Windows Forms designer and it defines everything you see on the form. Everything done on the form in VS.NET using designers generates code. Every single control added and property set will generate code and that code goes into InitializeComponent() method.
        }

        Random rnd = new Random();//Random class is used to create random numbers.

        string QEvent;/*The QEvent class is the base class of all event classes. 
						Event objects contain event parameters. 
						It's main event loop (QCoreApplication::exec()) fetches native window system events from the event queue, 
						translates them into QEvents, and sends the translated events to QObjects.*/
        int count = 1;
        string ProcWindow;
        double timer = 10;
        int EmailNum = 0;
        DateTime timenow = DateTime.Now;
        



        //Form declaration....
        SpeechSynthesizer sSynth = new SpeechSynthesizer(); /*SpeechSynthesizer: provides access to the functionalities of an 
                                                            installed speech synthesis engine*/
        
        PromptBuilder pBuilder = new PromptBuilder(); /*tells it what to speack, PromptBuilder: PromptBuilder is a class. 
                                                        creats an empty prompt object & provides methods for adding content, selecting voices, controlling voice attributes & 
                                                        also it is used for controlling the pronounciations of spoken words*/
        
        SpeechRecognitionEngine sRecognize = new SpeechRecognitionEngine(); /*SpeechRecognitionEngine: provides the means to access 
                                                                            & manage an In-Process Speech recognition engine. speech recognizer will recognize phrases*/
 

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;    //cannot click start again
            button3.Enabled = true;
            

            //set the grammar so to speak & this is for speech recognizer it will only recognize the words that you type in the code
            Choices sList = new Choices();  /*Choices: represents a set if alternatives in the constraints of a speech recognition grammar*/
            sList.Add(new string[] 
			{

                "Hi Alex", "i am alex"," Alex",  "hello", " hello Alex","print my name", "open movie","say hello","test","it works", "thank you",

                //Answer
                 "i am 25 days old", "i am doing great sadia", "I am Fine", "thank you sadia","hello Sadia. how are you?", "today i am fine",

            //Question
                "what is your name?", "how old are you alex?", "how are you?", "i am doing great sadia, how about you?",  "what is my name?","what is the current time?",
                "what is the todays date"," What time is it?", "What day is it? ", "Whats today's date?", " Whats the date?",
                //Other question
                " Hows the weather?", " Whats the weather like?", " Whats it like outside", " What will tomorrow be like ", "Whats tomorrows forecast ", "Whats tomorrow like ",
                "Whats the temperature ?", "Whats the temperature outside ",
                //Sadia
                "where live in Sadia?", "sadia are you completed your graduation?", "Which food sadia like most?", "what is sadia future plan?",
                //Munia
                "munia how old are you?", "where live in munia?", "munia are you completed your graduation?", "Which food munia like most?","Which color munia like most?", "what is munia future plan?",
                //Ayshi
                "ayshi how old are you?", "where live in ayshi?", "ayshi are you completed your graduation?","Which food ayshi like most?", "Which color ayshi like most?", "what is your future plan ayshi?",
            
                //Open & Close 
                "open chrome", "open AI", "open mozilla",
                "open google","open my facebook","open my folder","open my linkedin", "open my Youtube","open my c drive","close Prolog","open website","open program",
                "open Notepad","open Prolog","open Study","open Software","open AI",
                "Are Lights on?","go fullscreen", "exit fullscreen","switch window","reset","come back",
                " Goodbye", " Goodbye Alex", " Stop talking", "out of the way",
                " Close Alex","close Study","close movie","close Software","close AI","close Prolog","close Notepad",
                "exit", "close", "quit", "so",
                "Switch Window ", "Close window ", "Out of the way ", "Come back",
                //other
                "Play music ", "Play a random song ",
                "You decide ", "Play ", "Pause ", "Turn Shuffle On ", "Turn Shuffle Off ", "Next Song", " Previous Song ", "Fast Forward",
                " Stop Music ", "Turn Up ","Turn Down ", "Mute ", "Unmute ", "What song is playing ", "Fullscreen ", "Exit Fullscreen",
                " Play video ",  " Show default commands ",
                "Show shell commands ", "Show web commands ", "Show social commands", " Show Music Library", " Show Video Library",
                " Show Email List ", "Show listbox", " Hide listbox", " Shutdown ", "Log off ", "Restart ", "Abort",
                "Set the alarm", " What time is the alarm", " Clear the alarm ", "Stop listening ", "Alex Come Back Online",
                " Refresh libraries", " Change video directory ", "Change music directory", " Check for new emails", " Read the email",
                " Open the email ", "Next email", " Previous email", " Clear email list ", "Change Language ",
               //Word
                " hello "," Alex "," what "," is "," your "," name ", " open "," mozilla ", " print ", " my ", " name "," test ",
                " open " ," chrome ", "it"," works", "thank"," you","what"," is"," the"," current"," time", "how"," are"," you",
                "today"," i"," am"," fine","exit", "quit", "so"," hi "," is "," your "," name ","  am  ","  Sadia  ","  Ayshi  ","  Munia  ","  I ","  in  ","  B.sc  ","  CSE ",
                " Honourable ","  Course  "," Teacher  ","  Nadira Anjum Nipa  ","  Today  ","  our  ","  Artificial  Intellegence  ","  presentation  ","  our  ",
                "  project  ","  is ","   voice  ","  recognition.  ","  This ","  is  ","  most  ","  of ","  the  ","  precious  ","  please  ","  keep  ",
                " quite ", " and ", " clam ",

                //Digits
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
                "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39",
                "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58",
                "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77",
                "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93,", "94", "95", "96",
                "97", "98", "99", "100",
            });
            Grammar gr = new Grammar(new GrammarBuilder(sList));


            //for prevent error.....
//Exception Handling - try-catch


            try
            {
                //get recognizing.....
                sRecognize.RequestRecognizerUpdate();       //updating the detailes 
                sRecognize.LoadGrammar(gr);     //Load grammar 
                sRecognize.SpeechRecognized += SRecognize_SpeechRecognized; /*if my system reognize this word it rises an event SpeechRecognized*/
                sRecognize.SetInputToDefaultAudioDevice();      //set the default audio device, which microphone to use 
                sRecognize.RecognizeAsync(RecognizeMode.Multiple);      //recognize my word
            }
            catch(Exception ex)//Catch (exception type)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void SRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            int ranNum;
            string speech = e.Result.Text;

            switch (e.Result.Text.ToString())
            {
            //Alex
                case "what is your name?":
                    sSynth.SpeakAsync("i am alex");
                    break;
                case "Alex":
                    ranNum = rnd.Next(1, 5);
                    if (ranNum == 1) { QEvent = ""; sSynth.SpeakAsync("Yes Sadia"); }
                    else if (ranNum == 2) { QEvent = ""; sSynth.SpeakAsync("Yes?"); }
                    else if (ranNum == 3) { QEvent = ""; sSynth.SpeakAsync("How may I help?"); }
                    else if (ranNum == 4) { QEvent = ""; sSynth.SpeakAsync("How may I be of assistance?"); }
                    break;
                case "hello":
                case "hello alex":
                    timenow = DateTime.Now;
                    if (timenow.Hour >= 5 && timenow.Hour < 12)
                    { sSynth.SpeakAsync("Goodmorning Sadia,how are you?"); }
                    if (timenow.Hour >= 12 && timenow.Hour < 18)
                    { sSynth.SpeakAsync("Good afternoon Sadia,how are you?"); }
                    if (timenow.Hour >= 18 && timenow.Hour < 24)
                    { sSynth.SpeakAsync("Good evening Sadia,how are you?"); }
                    if (timenow.Hour < 5)
                    { sSynth.SpeakAsync("Hello Sadia, it's getting late"); }
                    break;

                case "say hello":
                    MessageBox.Show("Hello sadia. How are you?");
                    break;

                case "how old are you alex?":
                    sSynth.SpeakAsync("i am 25 days old");
                    break;
                case "how are you?":
                    sSynth.SpeakAsync("i am doing great sadia, how about you?");
                    break;
                case "I am Fine":
                    sSynth.SpeakAsync("thank you sadia");
                    break;
                case "what is my name?":
                    sSynth.SpeakAsync("your name is sadia");
                    break;
                case "thank you":
                    sSynth.SpeakAsync("pleasure is mine sadia");
                    break;

                //Date & Time
                case "what is the current time?":
                    sSynth.SpeakAsync("current is " + DateTime.Now.ToLongTimeString());
                    break;
                case "What day is it?":
                    sSynth.SpeakAsync("today is" + DateTime.Today.ToString("dddd"));
                    break;
                case "What is the date?":
                case "what is the todays date":
                    sSynth.SpeakAsync("current is " + DateTime.Now.ToLongDateString());
                    break;

                //SHELL COMMANDS
                case "open Study":
                    System.Diagnostics.Process.Start("E:/Study");
                    sSynth.SpeakAsync("Loading");
                    break;
                case "open movie":
                    System.Diagnostics.Process.Start("G:/");
                    sSynth.SpeakAsync("Loading");
                    break;
                case "open Software":
                    System.Diagnostics.Process.Start("D:/");
                    sSynth.SpeakAsync("Loading");
                    break;
                case "open AI":
                    System.Diagnostics.Process.Start("E:/Study/Level-4   Term-1/Artificial Intelligence Lab");
                    sSynth.SpeakAsync("Loading");
                    break;
                case "open Prolog":
                    System.Diagnostics.Process.Start("C:/Program Files/swipl/bin/swipl - win.exe");
                    sSynth.SpeakAsync("Loading");
                    break;
                //CLOSE PROGRAMS
                case "close Study":
                    ProcWindow = "Study";
                    StopWindow();
                    break;
                case "close movie":
                    ProcWindow = "Media";
                    StopWindow();
                    break;
                case "close Software":
                    ProcWindow = "Software";
                    StopWindow();
                    break;
                case "close AI":
                    ProcWindow = "AI";
                    StopWindow();
                    break;
                case "close Prolog":
                    ProcWindow = "Prolog";
                    StopWindow();
                    break;

                // Application Commands
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
                case "switch window":
                    SendKeys.Send("%{TAB " + count + "}");
                    count += 1;
                    break;
                case "Close window":
                    SendKeys.SendWait("%{F4}");
                    break;
                case "Are Lights on?":
                    sSynth.SpeakAsync("Let Me Check");
                    break;

                //WEBSITES
                case "open website":
                    System.Diagnostics.Process.Start("https://www.google.com/");
                    break;

                //Open Tab
                case "open chrome":
                    System.Diagnostics.Process.Start("chrome", "https://www.google.com/chrome/");
                    break;
                case "open google":
                    System.Diagnostics.Process.Start("chrome", "https://www.google.com/");
                    break;
                case "open my facebook":
                    System.Diagnostics.Process.Start("chrome", "https://www.facebook.com/");
                    break;
                case "open my Youtube":
                    System.Diagnostics.Process.Start("chrome", "https://www.youtube.com/channel/UCifclInuyA1EOf_wAQFFUVA");
                    break;
                case "open my linkedin":
                    System.Diagnostics.Process.Start("chrome", "https://www.linkedin.com/in/sadia-akter-2aa836105/");
                    break; 

                /*Shutdown / Restart / Logoff
                case "Shutdown":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "shutdown";
                        sSynth.SpeakAsync("Are you sure you want to " + QEvent + "?");
                    }
                    break;
                case "Log off":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "logoff";
                        sSynth.SpeakAsync("Are you sure you want to " + QEvent + "?");
                    }
                    break;

                case "Restart":
                    if (ShutdownTimer.Enabled == false)
                    {
                        QEvent = "restart";
                        sSynth.SpeakAsync("Are you sure you want to " + QEvent + "?");
                    }
                    break;
                case "Abort":
                    if (ShutdownTimer.Enabled == true)
                    {
                        timer = 11;
                        lblTimer.Text = timer.ToString();
                        ShutdownTimer.Enabled = false;
                        lblTimer.Visible = false;
                    }
                    break;
                case "Yes":
                    if (QEvent == "shutdown" || QEvent == "logoff" || QEvent == "restart")
                    {
                        sSynth.SpeakAsync("I will begin the countdown to " + QEvent);
                        button3.Enabled = true;
                        buttonClose.Visible = true;
                    }
                    break;
                case "No":
                    if (QEvent == "shutdown" || QEvent == "logoff" || QEvent == "restart")
                    {
                        sSynth.SpeakAsync("My mistake");
                        QEvent = String.Empty;
                    }
                    break;  */

                //Exit
                case "Stop talking":
                    sSynth.SpeakAsyncCancelAll();
                    
                    { sSynth.Speak("fine"); }
                    break;
                case "close":
                case "Goodbye":
                case "Goodbye Alex":
                case "Close Alex":
                case "Exit":
                case "Stop":
                    Application.Exit();
                    break;
            }
            
            if (e.Result.Text == "open my folder")
            {
                System.Diagnostics.Process.Start("c:\\");
            }
            else if (e.Result.Text == "open mojilla")
            {
                System.Diagnostics.Process.Start("Mojill Firefox");
            }

            else
            {
                //this will append the text or add it to what it is plus 
                textMessage.Text = textMessage.Text + "" + e.Result.Text.ToString() + Environment.NewLine;
            }
        }

        private void StopWindow()
        {
            
        }
//EventArgs e is a parameter called e that contains the event data, 
        private void button3_Click(object sender, EventArgs e)//Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
        {
            sRecognize.RecognizeAsyncStop();        // stop recognition
            button2.Enabled = true;
            button3.Enabled = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Read (Button click)
            pBuilder.ClearContent(); /*clear the content that is being spoken or has been into the variable*/
            pBuilder.AppendText(textMessage.Text); /**/
            

            sSynth.Rate = trackBarSpeed.Value;      //sets the speed
            sSynth.Volume = trackBarVolume.Value;       //sets the Volume
            sSynth.SpeakAsync(textMessage.Text);

            
            button1.Enabled = false;    //cannot click start again
            buttonClose.Enabled = true;
            
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            //Pause (Button click)
            sSynth.Pause();

            buttonPause.Enabled = false;    //cannot click start again
            buttonContinue.Enabled = true;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            //Continue (Button click)
            sSynth.Resume();

            buttonPause.Enabled = true;    //cannot click start again
            buttonContinue.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Record (Button click)
            sSynth.Rate = trackBarSpeed.Value;
            sSynth.Volume = trackBarVolume.Value;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Wave Files| *.wav";
            sfd.ShowDialog();
            sSynth.SetOutputToWaveFile(sfd.FileName);
            sSynth.Speak(textMessage.Text);
            sSynth.SetOutputToDefaultAudioDevice();
            MessageBox.Show("Recocrding Cmpleted..","text to speech");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            //Stop (Button click)
            sRecognize.RecognizeAsyncStop(); // stop recognition
            
            button1.Enabled = true;
            buttonPause.Enabled = true;
            buttonContinue.Enabled = true;
            buttonRecord.Enabled = true;
            buttonClose.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

    }
}