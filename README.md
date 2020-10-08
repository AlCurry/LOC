### LOC function - "Lines of Code"

#### Al Curry  

#### October 7, 2020 
---
<ins>Write a C# function that counts lines of code </ins>
1. Detailed problem described in pdf in this repository.
1. Accept a string as the function parameter.
1. The function will remove single line comments - preceded by "//".
1. The function will remove multi line comments - surrounded by "/*" and "*/".
1. The function will return the number of lines of code remaining after comments are removed.



#### Design / Code Descriptrion
---
1.  One code file, Program.cs, in directory countLinesOfCode.
1.  Main program calls LinesOfCode several times with different strings, 
    the input code
1.  Function LinesOfCode
    - argument is the string of code whose non-comment lines are to be counted
    - call getLineCount to count all lines in the string
    - define 2 regular expressions, for single and multi-line comments
    - call the Regex replace function with each
    - call getLineCount to count lines after comments have been removed
    - print the number of comment or whitespace lines removed
      (variation #1 requirement, for now not returned, just printed -
       returning multiple values could be handled in a few ways but 
       omitted for now)
    - return the count of lines
1.  Function GetLineCount 
    - parameters are the string of lines and a boolean to count 
      blanks and comment, defaulting to true
    - iterate through characters remaining in the string
    - look for line feed ("\n")
    - don't count blank lines
    - return the count of lines 
1.  Screenshot of output - output.png.

<ins>Disclaimer</ins>

It’s been some time since I studied C# or worked with Microsoft Visual Studio.  Uncertain about commenting standards at your organization, most places i’ve worked this was encouraged.  I’ve read about clean code and see that commenting is sometimes discouraged.  Glad to adapt to a company’s coding standard.  Aware of xml commenting in C#, and can see its merits, but here used classic format comments.
