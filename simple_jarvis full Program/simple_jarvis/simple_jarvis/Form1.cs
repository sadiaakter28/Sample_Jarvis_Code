using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace simple_jarvis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x = 1;

        SpeechRecognitionEngine mRecognize = new SpeechRecognitionEngine();

        public void mRecog_aktif()
        {
            try
            {
                Choices sList = new Choices();

                sList.Add(new string[] { "open google","open my facebook","open my folder" });

                Grammar gr = new Grammar(new GrammarBuilder(sList));
                mRecognize.RequestRecognizerUpdate();
                mRecognize.LoadGrammar(gr);
                mRecognize.SpeechRecognized += mRecognize_SpeechRecognized;
                mRecognize.SetInputToDefaultAudioDevice();
                mRecognize.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
        }




        void mRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Text == "open google")
            {
                System.Diagnostics.Process.Start("www.google.com");
            }

            else if (e.Result.Text == "open my facebook")
            {
                System.Diagnostics.Process.Start("www.facebook.com");
            }

            else if (e.Result.Text == "open my folder")
            {
                System.Diagnostics.Process.Start("c:\\");
            }

        }


        #region animasi
        private void timer1_Tick(object sender, EventArgs e)
        {

                ovalShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                timer1.Stop();
                timer2.Start();
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
          
                ovalShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                timer2.Stop();
                timer3.Start();
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
           
                ovalShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                timer3.Stop();
                timer4.Start();
            
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
           
                ovalShape2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                timer4.Stop();
                timer1.Start();
          
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            mRecog_aktif();
        }

    }
}
