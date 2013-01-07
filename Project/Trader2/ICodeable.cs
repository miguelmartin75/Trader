using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public interface ICodeable
{
	/// <summary>
	/// Reads from a stream.
	/// </summary>
	/// <param name="streamReader">The stream you wish to read from.</param>
    void ReadFromStream(StreamReader streamReader);


	/// <summary>
	/// Writers to a stream.
    /// </summary>
    /// <param name="streamWriter">The stream you wish to write to.</param>
	void WriteToStream(StreamWriter streamWriter);
}