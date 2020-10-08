/*
 * Al Curry   
 * October 7, 2020 
 * 
 * LOC problem - defined in detail at url below, also .pdf file in repository.
 * https://ccd-school.de/en/coding-dojo/application-katas/loc/
 * 
 *  
 */

using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LinesOfCode
{
    class Program
    {

        private static int LinesOfCode(string inputStr)
        {

            int newLineCount = 0;
            int removedLineCount = 0;
            int origLineCount = GetLineCount(inputStr);

            Debug.WriteLine("number of lines in string : " + origLineCount);

            /*
              use regular expressions to
                remove string from "//" to end of line or end of string
                remove string from "/*" to closing "*\/"
            */
            Regex matchSlashComments = new Regex(@"//.*?$", RegexOptions.Multiline);
            Regex matchMultiLineComments = new Regex(@"/\*(.|\n)*?\*/");

            string noComments = matchSlashComments.Replace(inputStr, "");
            noComments = matchMultiLineComments.Replace(noComments, "");

            Debug.WriteLine(noComments);

            newLineCount = GetLineCount(noComments, false);
            removedLineCount = origLineCount - newLineCount;

            Console.WriteLine("(" + removedLineCount + " lines with only comments or whitespace removed)");

            return newLineCount;

        }

        /* nt
         * count lines in string input, either all or excluding blank lines 
         */
        private static int GetLineCount(string input, bool includeBlankAndComment=true)
        {
            /*
             If all lines are to be counted (includeBlankAndComment is true, or its default),
             increment count when '\n' is found
             If blank and comment lines are to be excluded from the count, check the position
             in the line (the value of j), before incrementing count.  When called with false,
             comments should have been replaced with blanks.
            */

            int len = input.Length;
            int count = len != 0 ? 1 : 0;

            int j = 0;
            for (int i = 0; i < len - 1; ++i)
            {
                
                // In a production environment, likely additional line break values should be checked
                // (more case clauses in additon to '\n').
                switch (input[i])
                {
                    case '\n':
                        // If all lines are to be counted (includeBlankAndComment is true, or its default),
                        // increment count when '\n' is found
                        // If blank and comment lines are to be excluded from the count, check the position
                        // in the line, value of j.  When called with false, only comments should have been
                        // replaced with blanks.
                             
                        if ((includeBlankAndComment) | (j != 0))
                            ++count;
                        
                        j = 0;
                        break;
                    default:
                        // move char count past null or white space 
                        if (!string.IsNullOrWhiteSpace(input[i].ToString()))
                            j++;
                        break;
                }
            }
            
            return count;
        }
        static void Main(string[] args)
        {

            /* call LinesOfCode() function with various test strings */
            
            string testStr1 = @"int x = 0;
            /* Line 1  */

            what about this code ; /* Line 2 */
            x = x+1;
            /* test it more
             ok
                54321 */
            /*a”*/”b
            return 1;";

            Console.WriteLine("TEST 1");
            Console.WriteLine(LinesOfCode(testStr1) + " lines of executable code\n");
            
            Console.WriteLine("TEST 2");
            Console.WriteLine(LinesOfCode("SimpleCase\nA//gain\n") + " lines of executable code\n");

            Console.WriteLine("TEST 3");
            Console.WriteLine(LinesOfCode("") + " lines of executable code\n");

            Console.WriteLine("TEST 4");
            Console.WriteLine(LinesOfCode("SimpleCase") + " lines of executable code\n");

            Console.WriteLine("TEST 5");
            Console.WriteLine(LinesOfCode("SimpleCase\nAgain\n") + " lines of executable code\n");
            
            Console.WriteLine("TEST 6");
            Console.WriteLine(LinesOfCode(@"    _  _     _  _  _  _  _ 
                                             | _ | _ || _ || _ | _ || _ || _ |
                                             || _  _ |  | _ || _ |  || _ | _ |
                                            // take it out
                                            // more

                                                _  _  _  _  _  _     _
                                             | _ || _ || || || _ |  |  || _
                                                | _ || _ || _ || _ |  |  |  | _ | ") +
                                                " lines of executable code\n");
            

 
        }

    }
}
