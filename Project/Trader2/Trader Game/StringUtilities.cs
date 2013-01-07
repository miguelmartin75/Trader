using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class StringUtilities
{
    /// <summary>
    /// Grabs a variable from a string with the following format:
    /// nameOfVariable= someValue
    /// Where nameOfVariable is just the name you would like to identify the variable as.
    /// And someValue is the actual variable value.
    /// </summary>
    /// <param name="str">The string with the correct format.</param>
    /// <param name="characterToLookForAfterTheString">The character that seperates the nameOfVariable and someValue (as in '=').</param>
    /// <returns>The variable's value as a string.</returns>
    public static string GrabVariableFromString(string str, char characterToLookForAfterTheString)
    {
        string temp;

        temp = str.Substring(str.IndexOf(characterToLookForAfterTheString) + 1,
            str.Length - 1 - str.IndexOf(characterToLookForAfterTheString));

        // return the variable back,
        // but make sure there is no white space.
        return temp.Trim();
    }
}