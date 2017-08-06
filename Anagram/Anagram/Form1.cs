using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Anagram
{
    public partial class Form1 : Form
    {
        string[] FileLines = new string[26000];
        HashSet<string> fileLineSet = new HashSet<string>();
        public Form1()
        {
            InitializeComponent();

            FileLines = File.ReadAllLines(@"..\..\words.txt");
            fileLineSet = new HashSet<string>(FileLines);

        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            string sword = textBoxWord.Text;

            var result = new List<string>();
            GenerateAnagram(result, "", sword);

            // remove duplicates from list
            List<string> uniqueresult = result.Distinct().ToList();


            //IEnumerable<string> result = Enumerable.Empty<string>();
            // result =  GenerateAnagramAlt(sword);

            foreach (var s in uniqueresult)
            {
                bool match = fileLineSet.Contains(s);
                if (match) listBoxResult.Items.Add(s);
                // else listBoxResult.Items.Add(s + " not found");
            }
            

        }

        static void GenerateAnagram(IList<string> result, string prefix, string src)
        {
            if (src.Length == 0)
            {
                result.Add(prefix);
                return;
            }

            for (int i = 0; i < src.Length; i++)
            {
                string tempPrefix = src[i].ToString();
                string newSrc = src.Substring(0, i) + src.Substring(i + 1);
                var temp = new List<string>();
                GenerateAnagram(temp, tempPrefix, newSrc);
                foreach (var s in temp)
                {
                    result.Add(prefix + s);
                }
            }
        }

        // can't work out how to use this one
        static IEnumerable<string> GenerateAnagramAlt(string src)
        {
            if (src.Length == 0) yield break;
            if (src.Length == 1) yield return src;

            foreach (string rest in GenerateAnagramAlt(src.Substring(1)))
            {
                for (int i = 0; i < src.Length; i++)
                {
                    string temp = rest.Substring(0, i) + src[0] + rest.Substring(i);
                    yield return temp;
                }
            }
        }




    }
}
