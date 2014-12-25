using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    public class LZWAlgorithm
    {
        private int tableCount = 0;
        private List<string> table;

        public LZWAlgorithm()
        {

        }
        public string Compress(string input)
        {
            string result = "";
            table = new List<string>();
            char C = input[0];
            string P = C + "";
            
            for (int i = 1; i < input.Length; i++)
            {
                C = input[i];

                if (Find(P + C))
                {
                    P += C;
                }
                else
                {
                    if (P.Length == 1)
                        result += P;
                    else
                        result += "<" + (int)(255 + FindElemReturnIntex(P)) + ">";
                    table.Add(P + C);
                    P = C + "";
                }

            }
            if (P.Length == 1)
                result += P;
            else
                result += "<" + (int)(255 + FindElemReturnIntex(P)) + ">";
            return result;
        }

        public string Decompress(string input)
        {
            table = new List<string>();
            int k = input[0];
            string result = (char)k + "";
            string w = (char)k + "";
            char CH = (char)k;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == '<')
                {
                    string tryParse = "";
                    bool normalEnded = false;
                    for (int q = i + 1; q < input.Length; q++)
                    {
                        if (input[q] >= '0' && input[q] <= '9')
                        {
                            tryParse += input[q];
                        }
                        else if (input[q] == '>')
                        {
                            normalEnded = true;
                            break;
                        }
                        else
                            break;
                    }
                    if (normalEnded)
                    {
                        if (int.TryParse(tryParse, out k))
                        {
                            i += tryParse.Length + 1;
                        }
                    }
                }
                else
                {
                    k = input[i];
                }
                string entry = "";
                if (k <= 255)
                {
                    entry = (char)k + "";
                }
                else
                {
                    if (k - 256 < table.Count)
                        entry = table[k - 256];
                    else
                    {
                        entry = w + CH;
                    }
                }
                result += entry;
                CH = entry[0];
                table.Add(w + entry[0]);
                w = entry;
            }
            return result;
        }

        private bool Find(string s)
        {
            foreach (string elem in table)
            {
                if (elem == s)
                {
                    return true;
                }
            }
            return false;
        }
        private int FindElemReturnIntex(string s)
        {
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i] == s)
                {
                    return i + 1;
                }
            }
            return -1;
        }
    }
}
