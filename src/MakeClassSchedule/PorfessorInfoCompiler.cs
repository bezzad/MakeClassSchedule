using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakeClassSchedule
{
    /// <summary>
    /// Schedule Scanner and Parser Grammer's:
    /// 
    /// S -> ɛ;
    /// S -> FREE;
    /// S -> A;
    /// B -> & A;
    /// B -> ɛ;
    /// A -> E { T } B;
    /// E -> SUN;
    /// E -> MON;
    /// E -> THU;
    /// E -> WED;
    /// E -> THR;
    /// E -> FRI;
    /// E -> SAT;
    /// D -> & T;
    /// D -> ɛ;
    /// T -> N ~ N D;
    /// N -> 8;
    /// N -> 9;
    /// N -> 10;
    /// N -> 11;
    /// N -> 12;
    /// N -> 13;
    /// N -> 14;
    /// N -> 15;
    /// N -> 16;
    /// N -> 17;
    /// N -> 18;
    /// N -> 19;
    /// N -> 20;
    /// </summary>
    class ProfessorInfoCompiler
    {
        internal static List<TokenType> anyToken = new List<TokenType>();
        private bool[,] compiledData;
        public bool[,] CompiledData { get { return compiledData; } }

        /// <summary>
        /// Constructor of this class
        /// </summary>
        public ProfessorInfoCompiler()
        {
            // clear bool[,] compilerData array by false
            compiledData = new bool[12, 8];
            anyToken.Clear();
        }

        #region Scaner Method

        public bool StartScanner(string strData)
        {
            if(getToken(strData))
            {
                if (Parser()) return true;
                else return false;
            }
            else return false;
        }
        
        /// <summary>
        /// get any token in last line in a List of TokenType Struct's Frame
        /// </summary>
        /// <param name="last"></param>
        /// <returns></returns>
        private bool getToken(string ScheduleData)
        {
            // create end of line 
            ScheduleData += " ";
            //
            // spell the last line to word
            char[] spell = ScheduleData.ToCharArray();

            string buffer = "";
            for (int index = 0; index < spell.Length; index++)
            //foreach (char token in spell)
            {
                char token = spell[index];

                #region WhiteSpace
                if (char.IsWhiteSpace(token)) // Example: "    " or Tab
                {
                    buffer = "";
                    continue;
                }
                #endregion WhiteSpace
                #region Other
                switch(token)
                {
                    #region Day
                    case 'S': // SUN || SAT token
                        {
                            buffer += token.ToString(); // buffer = "S"
                            token = spell[++index]; 
                            buffer += token.ToString(); // buffer = "SU" or "SA"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "SUN" or "SAT"
                            if (buffer == "SUN" || buffer == "SAT")
                            {
                                addToken(buffer, "Day");
                                buffer = string.Empty;
                            }
                            else return false;
                        }
                        break;
                    case 'M': // MON token
                        {
                            buffer += token.ToString() ; // buffer = "M"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "MO"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "MON"
                            if (buffer == "MON")
                            {
                                addToken(buffer, "Day");
                                buffer = string.Empty;
                            }
                            else return false;
                        }
                        break;
                    case 'F': // FREE || FRI token
                        {
                            buffer += token.ToString(); // buffer = "F"
                            token = spell[++index]; // token = "R"
                            buffer += token.ToString(); // buffer = "FR"
                            token = spell[++index]; 
                            buffer += token.ToString(); // buffer = "FRI" or "FRE"
                            if (buffer == "FRI")
                            {
                                addToken(buffer, "Day");
                                buffer = string.Empty;
                            }
                            else
                            {
                                token = spell[++index];
                                buffer += token.ToString(); // buffer = "FREE"
                                if (buffer == "FREE")
                                {
                                    addToken(buffer, "FREE");
                                    buffer = string.Empty;
                                }
                                else return false;
                            }
                        }
                        break;
                    case 'T': // THU || THR token
                        {
                            buffer += token.ToString(); // buffer = "T"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "TH"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "THU" or "THR"
                            if (buffer == "THU" || buffer == "THR")
                            {
                                addToken(buffer, "Day");
                                buffer = string.Empty;
                            }
                            else return false;
                        }
                        break;
                    case 'W': // WED token
                        {
                            buffer += token.ToString(); // buffer = "W"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "WE"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "WED"
                            if (buffer == "WED")
                            {
                                addToken(buffer, "Day");
                                buffer = string.Empty;
                            }
                            else return false;
                        }
                        break;
                    #endregion
                    #region Separator
                    case '{': // { token
                    case '}': // } token
                    // case ':': // : token (Old Compiler)   
                    case '~': // ~ token
                    case '&': // & token 
                        {
                            addToken(token.ToString(), "Separator");
                        }
                        break;
                    #endregion
                    #region Number
                    case '8': // 8 token or 9 token
                    case '9': 
                        {
                            addToken(token.ToString(), "Num");
                        }
                        break;
                    case '1': // 10 || 11 || 12 || ... || 19 token
                        {
                            buffer += token.ToString(); // buffer = "1"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "10" or "11" or "12" or ... or "19"
                            if (char.IsDigit(token))
                            {
                                addToken(buffer, "Num");
                                buffer = string.Empty;
                            }
                            else return false;
                        }
                        break;
                    case '2': // 20 token
                        {
                            buffer += token.ToString(); // buffer = "2"
                            token = spell[++index];
                            buffer += token.ToString(); // buffer = "20"
                            if (token == '0')
                            {
                                addToken(buffer, "Num");
                                buffer = string.Empty;
                            }
                            else return false;
                        }
                        break;
                    #endregion
                    #region Error (other token is incorrect)
                    default: // error
                        return false;
                    #endregion
                }
                #endregion other
            }
            return true;
        }

        private void addToken(string Token, string Type)
        {
            switch (Type)
            {
                case "Day":
                case "Separator":
                case "Num":
                case "FREE":
                    {
                        TokenType objToken = new TokenType();
                        objToken.Token = Token;
                        objToken.Type = Type;
                        anyToken.Add(objToken);
                    }
                    break;
            }
        }
        
        #endregion

        #region Parser Method

        TokenType Lookahead;
        int counter_lah = 0;
        internal static bool error = true;

        private bool Parser()
        {
            error = false;
            compiledData = new bool[12, 8];
            counter_lah = 0;
            try
            {
                Lookahead = anyToken[counter_lah];
            }
            catch 
            {
                TokenType newNullToken = new TokenType();
                newNullToken.Token = "";
                newNullToken.Type = "NULL";
                Lookahead = newNullToken;
            }
            counter_lah++;
            S();
            return !error;
        }

        private void Match(string tt)
        {
            if (error) return;
            if (Lookahead.Token == tt)
            {
                try
                {
                    Lookahead = anyToken[counter_lah];
                    counter_lah++;
                }
                catch { return; }
            }
            else error = true;
        }

        private void S()
        {
            if (error) return;
            switch (Lookahead.Type)
            {
                case "FREE": // S -> FREE
                    {
                        for (int i = 0; i < 12; i++)
                            for (int j = 0; j < 8; j++)
                                compiledData[i, j] = true;
                    }
                    break;
                case "NULL": // S -> FREE | ɛ
                    {
                        for (int i = 0; i < 12; i++)
                            for (int j = 0; j < 8; j++)
                                compiledData[i, j] = false;
                    }
                    break;
                default: // S -> A
                    A();
                    break;
            }
        }

        private void A()
        {
            if (error) return;
            E();
            Match("{");
            T();
            Match("}");
            B();
        }

        private void B()
        {
            if (error) return;
            if (Lookahead.Token == "&")
            {
                Match("&");
                A();
            }
        }

        private int day_Index = 0;
        private void E()
        {
            if (error) return;
            if (Lookahead.Type == "Day")
            {
                switch (Lookahead.Token)
                {
                    case "SAT":
                        {
                            Match("SAT");
                            day_Index = 1;
                        }
                        break;
                    case "SUN":
                        {
                            Match("SUN");
                            day_Index = 2;
                        }
                        break;
                    case "MON":
                        {
                            Match("MON");
                            day_Index = 3;
                        }
                        break;
                    case "THU":
                        {
                            Match("THU");
                            day_Index = 4;
                        }
                        break;
                    case "WED":
                        {
                            Match("WED");
                            day_Index = 5;
                        }
                        break;
                    case "THR":
                        {
                            Match("THR");
                            day_Index = 6;
                        }
                        break;
                    case "FRI":
                        {
                            Match("FRI");
                            day_Index = 7;
                        }
                        break;
                    default: error = true;
                        break;
                }
            }
            else error = true;
        }

        private void D()
        {
            if (error) return;
            setCompiledData();
            if (Lookahead.Token == "&")
            {
                Match("&");
                T();
            }
        }

        private void T()
        {
            if (error) return;
            N();
            Match("~");
            N();
            D();
        }

        private int left_Time = 0;
        private void N()
        {
            if (error) return;
            if (Lookahead.Type == "Num")
            {
                left_Time = int.Parse(Lookahead.Token);
                Match(Lookahead.Token);
            }
            else error = true;
        }

        private void setCompiledData()
        {
            // OLD Compiler for (8:00 ~ 8:30) --> (19:30 ~ 20:00)
            // row.index in compilerData Array = ([right_Time - 8] + [left_Time - 30]) × 2
            // Scilicet: index = [allTime - 8.5] * 2 
            // Example:
            // if   left_Time = 11  &   right_Time = 30
            // then     allTime = 11,5
            // and index = [11,5 - 8,5] * 2 = 6
            // double allTime = (right_Time == 30) ? left_Time + 0.5 : left_Time;
            // int index = Convert.ToInt32((allTime - 8.5) * 2);
            //
            // New Compiler for (8:00 ~ 9:00) --> (19:00 ~ 20:00)
            int index = left_Time - 9;
            compiledData[index, day_Index] = true;
        }

        #endregion
    }
}


/// <summary>
/// Save Scaner Data in Token & Type of Token's
/// </summary>
struct TokenType
{
    public string Token;
    public string Type;
};
