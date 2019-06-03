using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

/*
 *  read(список переменных); while выражение do список присваиваний enw_while; write(список переменных)
 *  logical ; not - унарная ; and | or | imp ; 0|1 ; макс длина - 10 
 */


namespace LexickAnalizator
{
    public partial class Form1 : Form
    {

        static int type; // =1 - идентификатор ; =2 - константы ; =3 - ключевые слова ; =4 - разделители ;
        string temp;

        static List<string> tableR = new List<string>();
        static List<string> tableI = new List<string>();
        static List<string> tableC = new List<string>();
        static List<string> tableL = new List<string>();
        static List<string> tableE = new List<string>();
        static List<string> LConv = new List<string>();

        private List<string> IDENTIFIES = new List<string>();
        private List<string> CONSTANTS = new List<string>();
        private Stack<string> TokensStack = new Stack<string>();
        private Stack<string> TokensShell = new Stack<string>();
        private int CounterIdentifies = 0;
        private int CounterConstants = 0;

        private static bool IsEnter = false;
        private static string ReadString = "";
        private static string OutMessage = "";

        public List<Stack<string>> OUT = new List<Stack<string>>();

        static Dictionary<string, int> Perems = new Dictionary<string, int>();

        private struct KeyWords
        {
            public string Words;
            public string WordKey;

            public KeyWords(string a, string b)
            {
                Words = a;
                WordKey = b;
            }

        }

        private struct snd
        {
            public List<Stack<string>> IN;
            public RichTextBox rtb;

            public snd(List<Stack<string>> a, RichTextBox b)
            {
                IN = a;
                rtb = b;
            }
        };

        private struct ConstIdent
        {
            public string Ident;
            public string Const;

            public ConstIdent(string a, string b)
            {
                Ident = a;
                Const = b;
            }
        };
        
        private KeyWords[] KEYS =
        {
            new KeyWords("var", "01"), new KeyWords("logical", "02"), new KeyWords("begin", "03"),
            new KeyWords("end", "04"), new KeyWords("read", "05"), new KeyWords("write", "06"),
            new KeyWords("while", "07"), new KeyWords("do", "08"), new KeyWords("end_while", "09")
        };

        private KeyWords[] CHARS =
        {
            new KeyWords(":", "10"), new KeyWords(";", "11"), new KeyWords("=", "12"),
            new KeyWords("not","13"), new KeyWords("or", "14"), new KeyWords("imp", "15"), new KeyWords("and", "16"),
            new KeyWords("(", "17"), new KeyWords(")", "18"), new KeyWords(",", "19")
        };

        private delegate void AddText(string msg);

        private delegate void IsVisible(bool msg);

        string AllTextProgram;
        static int i;
        static int rowNumber = 0;
        static char[] limitries = { ',', '.', '(', ')', ':', '=', ';', ' ', '\n', '\r' };
        static string[] reservedKeyWords = { "var","logical","while","do","end_while",
            "read","write","begin","end","and","or","imp","not"};

        static Dictionary<string, List<string>> rulesTable = new Dictionary<string, List<string>>();
        static Stack<string> textStack = new Stack<string>();
        static Stack<string> tempBuf = new Stack<string>();
        public Form1()
        {
            InitializeComponent();

            tableR = new List<string>();
            tableI = new List<string>();
            tableC = new List<string>();
            LConv = new List<string>();

            #region Задание словаря правил

            rulesTable["НС"] = new List<string>();
            rulesTable["НС"].Add("ПЕРЕМ ВЫЧ$");

            rulesTable["ПРИСВ"] = new List<string>();
            rulesTable["ПРИСВ"].Add("ОМЯ& = ПОДВЫР ;");

            rulesTable["ИМЯ"] = new List<string>();
            rulesTable["ИМЯ"].Add("ОМЯ");
            rulesTable["ИМЯ"].Add("ИМЯ , ИМЯ");

            rulesTable["ОПЕРАНД"] = new List<string>();
            rulesTable["ОПЕРАНД"].Add("0");
            rulesTable["ОПЕРАНД"].Add("1");
            rulesTable["ОПЕРАНД"].Add("ОМЯ*");

            rulesTable["УНОП"] = new List<string>();
            rulesTable["УНОП"].Add("not");

            rulesTable["БИНОП"] = new List<string>();
            rulesTable["БИНОП"].Add("and");
            rulesTable["БИНОП"].Add("or");
            rulesTable["БИНОП"].Add("imp");

            rulesTable["ПОДВЫР"] = new List<string>();
            rulesTable["ПОДВЫР"].Add("ОПЕРАНД");
            rulesTable["ПОДВЫР"].Add("УНОП ПОДВЫР");
            rulesTable["ПОДВЫР"].Add("ПОДВЫР БИНОП ПОДВЫР");            

            rulesTable["ПЕРЕМ"] = new List<string>();
            rulesTable["ПЕРЕМ"].Add("var ИМЯ : logical ;");

            rulesTable["ВЫЧ$"] = new List<string>();
            rulesTable["ВЫЧ$"].Add("begin СПДЕЙСТ end");

            rulesTable["ДЕЙСТВ"] = new List<string>();
            rulesTable["ДЕЙСТВ"].Add("read ( ИМЯ ) ;");
            rulesTable["ДЕЙСТВ"].Add("while ПОДВЫР do СПДЕЙСТ end_while ;");
            rulesTable["ДЕЙСТВ"].Add("write ( ИМЯ ) ;");

            rulesTable["СПДЕЙСТ"] = new List<string>();
            rulesTable["СПДЕЙСТ"].Add("ПРИСВ");
            rulesTable["СПДЕЙСТ"].Add("СПДЕЙСТ ПРИСВ ;");
            rulesTable["СПДЕЙСТ"].Add("ДЕЙСТВ");
            rulesTable["СПДЕЙСТ"].Add("СПДЕЙСТ ДЕЙСТВ ;");
            rulesTable["СПДЕЙСТ"].Add("СПДЕЙСТ ДЕЙСТВ");
            rulesTable["СПДЕЙСТ"].Add("СПДЕЙСТ ;");
            rulesTable["СПДЕЙСТ"].Add("ПОДВЫР ;");
            rulesTable["СПДЕЙСТ"].Add("СПДЕЙСТ ПОДВЫР ;");
            rulesTable["СПДЕЙСТ"].Add("СПДЕЙСТ СПДЕЙСТ");

            #endregion
        }

        void StartLexikAnaliz()
        {

            for (i = 0; i < AllTextProgram.Length; i++)
            {
                if (Analysis(AllTextProgram[i]) == 1) break;
            }
            if (temp != null)
                if (Result(temp) == 2)
                {
                    textStack.Clear();
                    textStack.Push("ОШИБКА");
                }
        }

        int Analysis(char nextChar)
        {
            int acsiiCode = nextChar;
            // Проверяем относится ли код символа к буквам английского алфавита и знаку нижнего подчеркивания
            if (((acsiiCode >= 65) && (acsiiCode <= 90)) || ((acsiiCode >= 97) && (acsiiCode <= 122)) || (acsiiCode == 95))
            {
                if (temp == null)
                    type = 1;
                else
                {
                    if (temp.Contains("0") || temp.Contains("1") || temp.Contains("2") || temp.Contains("3") ||
                        temp.Contains("4") || temp.Contains("5") || temp.Contains("6") || temp.Contains("7") ||
                        temp.Contains("8") || temp.Contains("9"))
                        type = 5;
                }
                temp += nextChar;
                return 0;
            }

            // Проверяем на наличие цифр
            if ((acsiiCode >= 48) && (acsiiCode <= 57))
            {
                if (((acsiiCode == 48) || (acsiiCode == 49)) && temp == null)
                    type = 2;
                else type = 5;
                temp += nextChar;
                return 0;
            }

            // проверка на принадлежность к массиву разделителей.

            if (limitries.Contains(nextChar))
            {
                if (nextChar == '\n') rowNumber++;
                if (temp != null)
                {
                    if (Result(temp) == 2)
                    {
                        textStack.Clear();
                        textStack.Push("ОШИБКА");
                        return 1;
                    }
                    temp = null;
                }

                type = 3;

                temp = nextChar.ToString();
                if (i != AllTextProgram.Length - 1 && nextChar != ' ' && nextChar != '\n')
                    if (Result(temp) == 1)
                    {
                        textStack.Clear();
                        textStack.Push("ОШИБКА");
                        return 1;
                    }
                temp = null;
                return 0;
            }
            else
            {
                if (nextChar == '*' || nextChar == '&')
                    temp += nextChar;
            }
            return 0;
        }

        private int Result(string temp)
        {

            if (reservedKeyWords.Contains(temp))
            {
                if (!tableR.Contains(temp))
                {
                    switch (temp)
                    {
                        case "logical":
                            if (!tableR.Contains("var"))
                                OutMessage = $"Отсутствует VAR!";
                            break;
                        case "begin":
                            if (!tableR.Contains("logical"))
                                OutMessage = $"Отсутствует LOGICAL!";
                            if (!tableR.Contains("var"))
                                OutMessage = $"Отсутствует VAR!";
                            break;
                        case "end":
                            if (!tableR.Contains("begin"))
                                OutMessage = $"Отсутствует BEGIN!";
                            if (!tableR.Contains("logical"))
                                OutMessage = $"Отсутствует LOGICAL!";
                            if (!tableR.Contains("var"))
                                OutMessage = $"Отсутствует VAR!";
                            break;
                        default:
                            break;
                    }
                    if (OutMessage != "")
                        return 2;
                    tableR.Add(temp);
                }
                else
                {
                    switch (temp)
                    {
                        case "var":
                            OutMessage = $"Использовано зарезервированное слово {temp}!";
                            break;
                        case "begin":
                            OutMessage = $"Использовано зарезервированное слово {temp}!";
                            break;
                        case "end":
                            OutMessage = $"Использовано зарезервированное слово {temp}!";
                            break;
                        case "logical":
                            OutMessage = $"Использовано зарезервированное слово {temp}!";
                            break;
                        default:
                            break;
                    }
                }
                if (OutMessage != "")
                    return 2;
                switch (temp)
                {
                    case "var":
                        TokensShell.Push("01");
                        break;
                    case "logical":
                        TokensShell.Push("02");
                        break;
                    case "begin":
                        TokensShell.Push("03");
                        break;
                    case "end":
                        TokensShell.Push("04");
                        break;
                    case "read":
                        TokensShell.Push("05");
                        break;
                    case "write":
                        TokensShell.Push("06");
                        break;
                    case "while":
                        TokensShell.Push("07");
                        break;
                    case "do":
                        TokensShell.Push("08");
                        break;
                    case "end_while":
                        TokensShell.Push("09");
                        break;
                    case "not":
                        TokensShell.Push("13");
                        break;
                    case "or":
                        TokensShell.Push("14");
                        break;
                    case "imp":
                        TokensShell.Push("15");
                        break;
                    case "and":
                        TokensShell.Push("16");
                        break;
                }
                textStack.Push(temp);

                if (StartSyntaxisAnaliz() == 2) MessageBox.Show("Ошибка");
                return 0;
            }

            switch (type)
            {
                case 1:
                    if (tableR.Contains("var") && !tableR.Contains("begin")
                        && !tableI.Contains(temp) && !tableR.Contains(temp) && temp.Length <= 10)
                    {
                        IDENTIFIES.Add(temp);
                        tableI.Add(temp);
                        TokensShell.Push("20");
                    }
                    else
                    {
                        var temp1 = temp.Replace("*", string.Empty);
                        temp1 = temp1.Replace("&", string.Empty);
                        if (temp1.Length > 10)
                        {
                            OutMessage = $"Слишком большое имя переменной {temp1} (макс. 10 симв.)!";
                            break;
                        }
                        if (tableR.Contains("var") && !tableR.Contains("begin") && !tableR.Contains(temp1) && temp.Length <= 10)
                        {
                            OutMessage = $"Переменная {temp1} уже объявлена!";
                            break;
                        }
                        if (tableI.Contains(temp1))
                        {
                            IDENTIFIES.Add(temp1);
                            TokensShell.Push("20");
                            break;
                        }
                        if ( !tableI.Contains(temp1))
                        {
                            OutMessage = $"Переменная {temp1} не объявлена!";
                            break;
                        }

                    }
                    break;
                case 2:
                    {
                        CONSTANTS.Add(temp);
                        TokensShell.Push("21");
                        if (!tableC.Contains(temp))
                            tableC.Add(temp);
                    }
                    break;
                case 3:
                    if(!tableL.Contains(temp))
                    tableL.Add(temp);
                    switch (temp)
                    {
                        case ":":
                            TokensShell.Push("10");
                            break;
                        case ";":
                            TokensShell.Push("11");
                            break;
                        case "=":
                            TokensShell.Push("12");
                            break;
                        case "(":
                            TokensShell.Push("17");
                            break;
                        case ")":
                            TokensShell.Push("18");
                            break;
                        case ",":
                            TokensShell.Push("19");
                            break;
                    }
                    break;
                case 5:
                    return 1;
            }
            textStack.Push(temp);
            if (StartSyntaxisAnaliz() == 2) MessageBox.Show("Ошибка");
            return 0;
        }

        /// <summary>
        /// Проанализировать
        /// </summary>
        /// <returns>0 - СВЕРТ, 1 - ПЕРЕНОС, 2 - ОШИБКА</returns>
        static int StartSyntaxisAnaliz()
        {
            string str = "";
            if (textStack.Peek().Contains('*') || textStack.Peek().Contains('&'))
            {
                if (textStack.Peek().Contains('*'))
                {
                    str = textStack.Pop();
                    textStack.Push(str.Replace("*", string.Empty));
                    str = "*";
                }
                else
                {
                    str = textStack.Pop();
                    textStack.Push(str.Replace("&", string.Empty));
                    str = "&";
                }
            }

            if (tableI.Contains(textStack.Peek()))
            {
                str = "ОМЯ" + str;
                textStack.Pop();
                textStack.Push(str);
            }
            bool ydal = true;
            foreach (var listStr in rulesTable)
            {
                foreach (var value in listStr.Value)
                {
                    if (value.Contains(textStack.Peek()))
                    {
                        if (value.EndsWith(textStack.Peek()))
                        {
                            string row = "";
                            ydal = true;
                            Stack<string> tempStack = new Stack<string>();
                            do
                            {
                                if (textStack.Count != 0)
                                {
                                    tempStack.Push(textStack.Peek());
                                    row = textStack.Pop() + ' ' + row;
                                    row = row.Replace("  ", " ");
                                }
                                else
                                {
                                    ydal = false;
                                    while (tempStack.Count != 0)
                                    {
                                        textStack.Push(tempStack.Pop());
                                    }
                                    break;
                                }
                            } while (row.Remove(row.Length - 1) != value);
                            if (ydal)
                            {
                                textStack.Push(listStr.Key);

                            }
                            while (AdditionalAnaliz() != 1)
                                continue;

                            break;
                        }
                    }
                }
            }
            return 1;
        }

        static int AdditionalAnaliz()
        {
            foreach (var listStr in rulesTable)
            {
                foreach (var value in listStr.Value)
                {
                    if (value.Contains(textStack.Peek()))
                    {
                        if (value.EndsWith(textStack.Peek()))
                        {
                            bool done = true;
                            string row = "";
                            Stack<string> stRow = new Stack<string>();
                            do
                            {
                                if (textStack.Count != 0)
                                {
                                    stRow.Push(textStack.Peek());
                                    row = textStack.Pop() + ' ' + row;
                                    row = row.Replace("  ", " ");
                                }
                                else
                                {
                                    while (stRow.Count != 0)
                                    {
                                        textStack.Push(stRow.Pop());
                                    }

                                    done = false;
                                    break;
                                }

                            } while (row.Remove(row.Length - 1) != value);
                            if (done)
                            {
                                textStack.Push(listStr.Key);
                                return 0;
                            }
                        }
                    }
                }
            }
            return 1;
        }

        static int Implication(int first, int second)
        {
            switch (first)
            {
                case 0:
                    return 1;
                case 1:
                    if (second == 0)
                        return 0;
                    break;
                default:
                    break;
            }
            return 1;
        }

        static int And(int first, int second)
        {
            if (first == 1 && second == 1)
                return 1;
            else
                return 0;
        }

        static int Or(int first, int second)
        {
            if (first == 1 || second == 1)
                return 1;
            else
                return 0;
        }

        private void FindOperations()
        {
            while (TokensStack.Peek() != "03")
            {
                if (TokensStack.Pop() == "20")
                {
                    CounterIdentifies++;
                }
            }
            while (TokensStack.Count != 0)
            {
                switch (TokensStack.Peek())
                {
                    case "05":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();

                            s1.Push(TokensStack.Pop());
                            while (TokensStack.Peek() != "11")
                            {
                                if (TokensStack.Pop() == "20")
                                {
                                    s1.Push(IDENTIFIES[CounterIdentifies++]);
                                }
                            }
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    case "06":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            s1.Push(TokensStack.Pop());
                            while (TokensStack.Peek() != "11")
                            {
                                if (TokensStack.Pop() == "20")
                                {
                                    s1.Push(IDENTIFIES[CounterIdentifies++]);
                                }
                            }
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    case "07":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            s1.Push(TokensStack.Pop());

                            while (TokensStack.Peek() != "08")
                            {
                                if (TokensStack.Peek() == "08")
                                    break;

                                string a = TokensStack.Pop();
                                switch (a)
                                {
                                    case "20":
                                        s1.Push(IDENTIFIES[CounterIdentifies++]);
                                        break;

                                    case "08":
                                        s2 = Equal("09");
                                        while (s2.Count != 0)
                                            s1.Push(s2.Pop());
                                        break;
                                    default:
                                        TokensStack.Push(a);
                                        s2 = Equal("08", false);
                                        while (s2.Count != 0)
                                            s1.Push(s2.Pop());
                                        break;
                                }
                            }
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    case "09":
                        {
                            Stack<string> s1 = new Stack<string>();
                            s1.Push(TokensStack.Pop());
                            OUT.Add(s1);
                            break;
                        }
                    case "12":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            s1.Push(IDENTIFIES[CounterIdentifies++]);
                            TokensStack.Pop();
                            s2 = Equal("11");
                            while (s2.Count != 0)
                                s1.Push(s2.Pop());
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    default:
                        {
                            TokensStack.Pop();
                            break;
                        }
                }
            }
        }

        private Stack<string> Equal(string end, bool whl = true)
        {
            Stack<string> s1 = new Stack<string>();
            Stack<string> s2 = new Stack<string>();
            if (whl)
                s1.Push("$");
            Stack<string> operations = new Stack<string>();
            operations.Push("00");
            while (TokensStack.Peek() != end)
            {
                switch (TokensStack.Peek())
                {
                    case "20": { s1.Push(IDENTIFIES[CounterIdentifies++]); TokensStack.Pop(); break; }
                    case "21": { s1.Push(CONSTANTS[CounterConstants++]); TokensStack.Pop(); break; }
                    default:
                        {
                            if (s1.Count == 0 && TokensStack.Peek() == "13")
                                s1.Push("not");
                            else
                            {
                                if (whl)
                                {
                                    //для not
                                    //если стек пуст и мы считываем not
                                    if (s1.Peek() == "$" && TokensStack.Peek() == "13")
                                        s1.Push("not");
                                }
                            }
                            if (operations.Peek() == "17" && TokensStack.Peek() == "13")
                                s1.Push("not");
                            if (operations.Peek() == "17" || operations.Peek() == "00")
                            {
                                operations.Push(TokensStack.Pop());
                                break;
                            }
                            if (TokensStack.Peek() == "17")
                            {
                                operations.Push(TokensStack.Pop());
                                break;
                            }
                            if (TokensStack.Peek() == "18")
                            {
                                while (operations.Peek() != "17")
                                {
                                    s1.Push(BinOp(operations.Pop()));
                                }
                                TokensStack.Pop();
                                operations.Pop();
                                break;
                            }
                            if (Convert.ToInt32(TokensStack.Peek()) > Convert.ToInt32(operations.Peek()))
                            {
                                operations.Push(TokensStack.Pop());
                            }
                            else
                            {
                                while (Convert.ToInt32(TokensStack.Peek()) > Convert.ToInt32(operations.Peek()) || operations.Peek() != "17")
                                {
                                    if (operations.Peek() == "00")
                                        break;
                                    s1.Push(BinOp(operations.Pop()));
                                }
                            }
                            break;
                        }
                }
            }
            while (operations.Peek() != "00")
            {
                if (operations.Peek() == "13")
                {
                    operations.Pop();
                    break;
                }
                s1.Push(BinOp(operations.Pop()));
            }
            if (whl)
                s1.Push("$");
            while (s1.Count != 0)
                s2.Push(s1.Pop());
            return s2;
        }

        private string BinOp(string str)
        {
            if (str == "14")
                return "or";
            if (str == "15")
                return "imp";
            return "and";
        }

        private static List<String> CopyOne(snd[] snd1, int k)
        {
            List<string> temp = new List<string>();
            while (snd1[0].IN[k].Count() != 0)
            {

                string a = snd1[0].IN[k].Pop();
                temp.Add(a);
            }
            return temp;
        }

        private static List<List<string>> Copy(snd[] snd1, int k)
        {
            int i = 0, j = 0;
            List<List<string>> temp = new List<List<string>>();
            while (snd1[0].IN[k].Peek() != "09")
            {
                temp.Add(new List<string>());
                while (snd1[0].IN[k].Count() != 0)
                {

                    string a = snd1[0].IN[k].Pop();
                    temp[i].Add(a);
                    j++;
                }
                i++;
                k++;
            }
            if (snd1[0].IN[k].Peek() == "09")
                snd1[0].IN[k].Pop();
            return temp;
        } //копирует стеки состояний для действий в цикле while

        private static string Operation(Stack<string> a, List<ConstIdent> CI)
        {
            Stack<string> s1 = new Stack<string>();
            while (a.Peek() != "$")
            {
                switch (a.Peek())
                {
                    case "or":
                        {
                            a.Pop();
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (a.Peek() != "$")
                                s1.Push(Or(b1, c1).ToString());
                            else
                                return Or(b1, c1).ToString();
                            break;
                        }
                    case "imp":
                        {
                            a.Pop();
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (a.Peek() != "$")
                                s1.Push(Implication(c1, b1).ToString());
                            else
                                return Implication(c1, b1).ToString();
                            break;
                        }
                    case "and":
                        {
                            a.Pop();
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (a.Peek() != "$")
                                s1.Push(And(c1, b1).ToString());
                            else
                                return And(c1, b1).ToString();
                            break;
                        }
                    case "not":
                        {
                            a.Pop();
                            int b1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(a.Pop(), CI));
                                if (b1 == 1)
                                    b1 = 0;
                                else
                                    b1 = 1;
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (a.Peek() != "$")
                                s1.Push(b1.ToString());
                            else
                                return b1.ToString();
                            break;
                        }
                    default:
                        {
                            s1.Push(a.Pop());
                            if (a.Peek() == "$" && s1.Count == 1)
                            {
                                return s1.Pop();
                            }
                            break;
                        }
                }
            }
            return "error";
        }

        private static string Operation(List<string> a, List<ConstIdent> CI, bool cpy = true)
        {
            int i;
            if (cpy)
                i = 2;
            else
                i = 0;
            Stack<string> s1 = new Stack<string>();
            while (a[i] != "$")
            {
                switch (a[i])
                {
                    case "or":
                        {
                            i++;
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (i < a.Count)
                            {
                                if (a[i] != "$")
                                {
                                    s1.Push(Or(b1, c1).ToString());
                                    break;
                                }
                            }
                            return Or(b1, c1).ToString();
                        }
                    case "imp":
                        {
                            i++;
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (i < a.Count)
                            {
                                if (a[i] != "$")
                                {
                                    s1.Push(Implication(c1, b1).ToString());
                                    break;
                                }
                            }
                            return Implication(c1, b1).ToString();
                        }
                    case "and":
                        {
                            i++;
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            if (i < a.Count)
                            {
                                if (a[i] != "$")
                                {
                                    s1.Push(And(c1, b1).ToString());
                                    break;
                                }
                            }
                            return And(c1, b1).ToString();
                        }
                    case "not":
                        {
                            i++;
                            int b1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(a[i], CI));

                                if (b1 == 1)
                                    b1 = 0;
                                else
                                    b1 = 1;
                            }
                            catch
                            {
                                return "variable is not set";
                            }
                            i++;
                            if (i < a.Count)
                            {
                                if (a[i] != "$")
                                {
                                    s1.Push(b1.ToString());
                                    break;
                                }
                            }
                            return b1.ToString();
                        }
                    default:
                        {
                            s1.Push(a[i]);
                            i++;
                            if (a[i] == "$" && s1.Count == 1)
                            {
                                return s1.Pop();
                            }
                            break;
                        }
                }
            }
            return "error";
        }//перегрузка для цикла

        private static void Run(object INI)
        {
            snd[] snd1 = (snd[])INI;
            List<ConstIdent> CI = new List<ConstIdent>();
            for (int i = 0; i < snd1[0].IN.Count(); i++)
            {
                while (snd1[0].IN[i].Count() != 0)
                {
                    switch (snd1[0].IN[i].Peek())
                    {
                        case "05":
                            {
                                if (snd1[0].rtb.InvokeRequired)
                                    snd1[0].rtb.Invoke(new IsVisible((s) => snd1[0].rtb.ReadOnly = s), false);

                                snd1[0].IN[i].Pop();
                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "ENTER DATA\n");

                                while (snd1[0].IN[i].Count != 0)
                                {
                                    int rr = 0;
                                    string b = "";
                                    string a = snd1[0].IN[i].Pop().Replace("*", string.Empty);
                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), a + " = ");

                                    while (rr == 0)
                                    {
                                        while (IsEnter == false)
                                        {
                                            Thread.Sleep(100);
                                        }
                                        b = ReadString;
                                        b = b.Substring(a.Length + 2);
                                        try
                                        {
                                            int k = Convert.ToInt32(b);
                                            if (!(k == 0 || k == 1))
                                                throw new Exception();
                                            IsEnter = false;
                                            rr++;
                                        }
                                        catch
                                        {
                                            if (snd1[0].rtb.InvokeRequired)
                                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                    "Incorrect type\n" + a + " = ");
                                            IsEnter = false;
                                        }
                                    }
                                    CI.Add(new ConstIdent(a, b));
                                }
                                IsEnter = false;
                                if (snd1[0].rtb.InvokeRequired)
                                    snd1[0].rtb.Invoke(new IsVisible((s) => snd1[0].rtb.ReadOnly = s), true);
                                break;
                            }
                        case "06":
                            {
                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "OUTPUT DATA\n");
                                snd1[0].IN[i].Pop();
                                try
                                {
                                    while (snd1[0].IN[i].Count != 0)
                                    {
                                        for (int j = CI.Count - 1; j >= 0; j--)
                                        {

                                            if (snd1[0].IN[i].Peek() == CI[j].Ident)
                                            {
                                                try
                                                {
                                                    Convert.ToInt32(CI[j].Const);
                                                    if (snd1[0].rtb.InvokeRequired)
                                                        snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                            Convert.ToString(CI[j].Ident + " = " + CI[j].Const + "\n"));
                                                }
                                                catch
                                                {
                                                    if (snd1[0].rtb.InvokeRequired)
                                                        snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                        Convert.ToString($"Переменная {CI[j].Ident} не определена!\n"));
                                                    return;
                                                }
                                                snd1[0].IN[i].Pop();
                                                break;
                                            }

                                        }
                                    }
                                }
                                catch
                                {
                                    if (snd1[0].rtb.InvokeRequired)
                                        snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                            Convert.ToString($"Ошибка в коде"));
                                    return;
                                }
                                break;
                            }
                        case "07":
                            {
                                Stack<string> s1 = new Stack<string>();
                                snd1[0].IN[i].Pop();
                                var list = CopyOne(snd1, i);
                                int j = 0;
                                if (list.Count == 1)
                                {
                                    string a = list[j];
                                    j++;
                                    string err = TryFind(list[j], CI);
                                    j++;
                                    break;
                                }
                                else
                                {
                                    string ww = Operation(list, CI, false);
                                    if (ww == "variable is not set" || ww == "zero division")
                                        if (snd1[0].rtb.InvokeRequired)
                                            snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), ww + "\n");
                                }
                                CycleWhile(list, ref i, snd1, ref CI);
                                break;
                            }
                        default:
                            {
                                if (snd1[0].IN[i].Count() == 4)
                                {
                                    string a = snd1[0].IN[i].Pop();
                                    snd1[0].IN[i].Pop();
                                    string err = TryFind(snd1[0].IN[i].Pop(), CI);
                                    CI.Add(new ConstIdent(a, err));
                                    snd1[0].IN[i].Pop();
                                    break;
                                }
                                else
                                {
                                    string a = snd1[0].IN[i].Pop();
                                    snd1[0].IN[i].Pop();
                                    string ww = Operation(snd1[0].IN[i], CI);
                                    if (ww == "variable is not set" || ww == "zero division")
                                        if (snd1[0].rtb.InvokeRequired)
                                            snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), ww + "\n");
                                    CI.Add(new ConstIdent(a, ww));
                                    snd1[0].IN[i].Pop();
                                }
                                break;
                            }
                    }
                }
            }
            snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "COMPILATOR WORKED\n");
        }

        private static void CycleWhile(List<string> list, ref int Id, snd[] snd1, ref List<ConstIdent> CI)
        {
            Id++;
            List<List<string>> temp = Copy(snd1, Id);
            while (Operation(list, CI, false) == "1")
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    int j = 0;
                    switch (temp[i][j])
                    {
                        case "05":
                            {
                                if (snd1[0].rtb.InvokeRequired)
                                    snd1[0].rtb.Invoke(new IsVisible((s) => snd1[0].rtb.ReadOnly = s), false);

                                j++;
                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "ENTER DATA\n");

                                while (temp[i].Count() != j)
                                {
                                    int rr = 0;
                                    string b = "";
                                    string a = temp[i][j];
                                    j++;
                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), a + " = ");

                                    while (rr == 0)
                                    {
                                        while (IsEnter == false)
                                        {
                                            Thread.Sleep(100);
                                        }

                                        b = ReadString;
                                        b = b.Substring(a.Length + 2);

                                        try
                                        {
                                            int k = Convert.ToInt32(b);
                                            if (!(k == 0 || k == 1))
                                                throw new Exception();
                                            IsEnter = false;
                                            rr++;
                                        }
                                        catch
                                        {
                                            if (snd1[0].rtb.InvokeRequired)
                                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                    "Incorrect type\n" + a + " = ");
                                            IsEnter = false;
                                        }
                                    }
                                    CI.Add(new ConstIdent(a, b));
                                }
                                IsEnter = false;
                                if (snd1[0].rtb.InvokeRequired)
                                    snd1[0].rtb.Invoke(new IsVisible((s) => snd1[0].rtb.ReadOnly = s), true);

                                break;
                            }
                        case "06":
                            {
                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "OUTPUT DATA\n");
                                j++;

                                while (temp[i].Count() != j)
                                {
                                    for (int k = CI.Count - 1; k >= 0; k--)
                                    {
                                        if (temp[i][j] == CI[k].Ident)
                                        {
                                            try
                                            {
                                                Convert.ToInt32(CI[k].Const);
                                                if (snd1[0].rtb.InvokeRequired)
                                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                        Convert.ToString(CI[k].Ident + " = " + CI[k].Const + "\n"));
                                            }
                                            catch
                                            {
                                                if (snd1[0].rtb.InvokeRequired)
                                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "");
                                            }
                                            j++;
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        default://идет по нему когда выражение
                            {
                                if (temp[i].Count() - 2 == 4)
                                {
                                    string a = temp[i][j];
                                    j += 2;
                                    string err = TryFind(temp[i][j], CI);
                                    j++;
                                    CI.Add(new ConstIdent(a, err));
                                    j++;
                                    break;
                                }
                                else
                                {
                                    string a = temp[i][j];
                                    j += 2;
                                    string ww = Operation(temp[i], CI);
                                    CI.Add(new ConstIdent(a, ww));
                                    j++;
                                }
                                break;
                            }
                    }
                }
            }
        }

        private static string TryFind(string a, List<ConstIdent> ci)
        {
            int ret;
            int kol = 0;
            while (true)
            {
                try
                {
                    ret = Convert.ToInt32(a);
                    return a;
                }
                catch
                {
                    kol = 0;
                    for (int j = ci.Count - 1; j >= 0; j--)
                    {
                        if (ci[j].Ident == a.Replace("*", string.Empty))
                        {
                            a = ci[j].Const;
                            kol++;
                            break;
                        }
                    }
                    if (kol == 0)
                        return "variable is not set";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBoxOut.Clear();
            tableL.Clear();
            tableR.Clear();
            tableI.Clear();
            tableE.Clear();
            tableC.Clear();
            Perems.Clear();
            AllTextProgram = richTextBox1.Text;
            AllTextProgram.ToLower();
            temp = "";
            i = 0;
            rowNumber = 0;
            textStack.Clear();
            TokensStack.Clear();
            TokensShell.Clear();
            IDENTIFIES.Clear();
            CONSTANTS.Clear();
            TokensStack.Clear();
            TokensShell.Clear();
            CounterIdentifies = 0;
            CounterConstants = 0;
            ReadString = "";
            OUT.Clear();
            tempBuf.Clear();
            OutMessage = "";

            StartLexikAnaliz();
            if (OutMessage != "")
            {
                richTextBoxOut.Text = OutMessage;
                return;
            }
            if (textStack.Peek() != "НС")
            {
                richTextBoxOut.Text = "Ошибка в коде!";
            }
            else
            {
                richTextBoxOut.Focus();
                TokensStack.Push("$");
                TokensShell.Push("$");
                while (TokensShell.Count != 0)
                {
                    TokensStack.Push(TokensShell.Pop());
                }
                FindOperations();
                snd[] snd1 = { new snd(OUT, richTextBoxOut) };
                Thread thread = new Thread(Run);
                thread.Start(snd1);
                richTextBox2.Text += "Константы:\n";
                foreach (var t in tableC)
                {
                    richTextBox2.Text += t + '\n';
                }
                richTextBox2.Text += "Зарезервированные слова:\n";
                foreach (var t in tableR)
                {
                    richTextBox2.Text += t + '\n';
                }
                richTextBox2.Text += "Идентификаторы:\n";
                foreach (var t in tableI)
                {
                    richTextBox2.Text += t + '\n';
                }
                richTextBox2.Text += "Лексемы:\n";
                foreach (var t in tableL)
                {
                    richTextBox2.Text += t + '\n';
                }
            }            
        }

        private void richTextBoxOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (richTextBoxOut.ReadOnly == false)
                {
                    ReadString =
                        richTextBoxOut.Lines[
                            richTextBoxOut.GetLineFromCharIndex(richTextBoxOut.GetFirstCharIndexFromLine(richTextBoxOut.SelectionStart - 1))];
                    IsEnter = true;
                }
            }
        }
    }

}
