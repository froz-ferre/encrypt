using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static string Encrypt(string word, string text, int key)
        {
            char[] NewAlpha = new char[65536];

            //  массив с кл.словом(word) на своем месте
            for (int i = key, j = 0; i < key + word.Length; i++, j++)
                NewAlpha[i] = word.ToCharArray()[j];

            // полностью сформированный новый массив NewAlpha
            for (int i = key + word.Length, l = 0; i < 65536; i++, l++)
            {
                if (i == 65535)
                    i = 0;

                int count = 0;

                do
                {
                    if (count != 0)
                    {
                        l++;
                        count = 0;
                    }

                    for (int j = key/*start_word*/; j < key + word.Length/*end_word*/; j++)
                        if (NewAlpha[j] == (char)l)
                        {
                            count++;
                            break;
                        }

                    if (count == 0)
                        NewAlpha[i] = (char)l;

                } while (count != 0);               

                if (i == key - 1)
                {
                    for (int j = key/*start_word*/; j < key + word.Length/*end_word*/; j++)
                        if (NewAlpha[j] == (char)l)
                            count++;
                    if (count == 0)
                    {
                        NewAlpha[i] = (char)l;
                        break;
                    }                       
                    else
                        break;
                    
                }
                
            }

            char[] SourseText = new char[text.Length];
            SourseText = text.ToCharArray();

            for (int i = 0; i < text.Length; i++)
                SourseText[i] = NewAlpha[(int)SourseText[i]];

            string result = new string(SourseText);

            return result;
        }

        static string Decrypt(string word, string text, int key)
        {
            char[] NewAlpha = new char[65536];

            //  массив с кл.словом(word) на своем месте
            for (int i = key, j = 0; i < key + word.Length; i++, j++)
                NewAlpha[i] = word.ToCharArray()[j];

            // полностью сформированный новый массив NewAlpha
            for (int i = key + word.Length, l = 0; i < 65536; i++, l++)
            {
                if (i == 65535)
                    i = 0;

                int count = 0;

                do
                {
                    if (count != 0)
                    {
                        l++;
                        count = 0;
                    }

                    for (int j = key/*start_word*/; j < key + word.Length/*end_word*/; j++)
                        if (NewAlpha[j] == (char)l)
                        {
                            count++;
                            break;
                        }

                    if (count == 0)
                        NewAlpha[i] = (char)l;

                } while (count != 0);

                if (i == key - 1)
                {
                    for (int j = key/*start_word*/; j < key + word.Length/*end_word*/; j++)
                        if (NewAlpha[j] == (char)l)
                            count++;
                    if (count == 0)
                    {
                        NewAlpha[i] = (char)l;
                        break;
                    }
                    else
                        break;

                }

            }

            char[] SourseText = new char[text.Length];
            SourseText = text.ToCharArray();

            for (int i = 0; i < text.Length; i++)
                for (int j = 0; j < 65536; j++)
                    if (SourseText[i] == NewAlpha[j])                   
                    {
                        SourseText[i] = (char)j;
                        break;
                    }

            string result = new string(SourseText);

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Encrypt("hello", "FE", 13));
            Console.WriteLine(Decrypt("hello", "43", 13));
            Console.ReadLine();
        }
    }
}
