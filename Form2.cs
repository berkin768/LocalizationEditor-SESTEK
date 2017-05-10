using RavSoft.GoogleTranslator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalizationEditor
{
    public partial class Form2 : Form
    {
        string baseLanguage;
        string targetLanguage;
        private readonly DataGridViewRow _dr;

        public Form2(string wordToBeTranslated, string translateResult, string baseLang, string target, DataGridViewRow dr)
        {
            InitializeComponent();
            textBoxTranslate.Text = wordToBeTranslated;
            textBoxResult.Text = translateResult;
            baseLanguage = baseLang;
            targetLanguage = target;
            _dr = dr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Translator t = new Translator();
            string translation = t.Translate(textBoxTranslate.Text + "", baseLanguage, targetLanguage);
            textBoxResult.Text = translation;
        }

        private void textBoxTranslate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Translator t = new Translator();
                string translation = t.Translate(textBoxTranslate.Text + "", baseLanguage, targetLanguage);
                textBoxResult.Text = translation;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baseLanguage == "Turkish")
            {
                _dr.Cells["EN"].Value = textBoxResult.Text;
            }
            else
            {
                _dr.Cells["TR"].Value = textBoxResult.Text;
            }

            Close();

        }


    }
}
