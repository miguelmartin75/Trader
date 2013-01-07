using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GameLib
{
    public class NameableObject : ICodeable
    {
        #region Constructors

        public NameableObject()
        {
            Name = "Un-named";
        }


        public NameableObject(string name)
        {
            this.Name = name;
        }

        #endregion



        #region Public Properties

        public string Name
        {
            get;
            set;
        }

        #endregion



        #region Overridden Methods

        public virtual void ReadFromStream(StreamReader streamReader)
        {
            // Get the name value, lol.
			string nameValue = StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '=');

            Name = nameValue;
        }


        public virtual void WriteToStream(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("Name=" + this.Name);

            streamWriter.Flush();
        }


        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}
