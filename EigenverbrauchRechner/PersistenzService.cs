using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EigenverbrauchRechner
{
    class PersistenzService<T>
    {
        public void Save(T item)
        {
            XmlWriter xmlWriter = null;

            try
            {
                var fileStream = new FileStream(@"data.xml", FileMode.Create);
                xmlWriter = XmlWriter.Create(fileStream, new XmlWriterSettings
                {
                    CloseOutput = true,
                    Indent = true,
                    IndentChars = "    "
                });

                var dataContractSerializer = new DataContractSerializer(typeof(T));
                dataContractSerializer.WriteObject(xmlWriter, item);
            }
            finally
            {
                if (xmlWriter != null)
                    xmlWriter.Close();
            }
        }

        public T Load()
        {
            XmlReader xmlReader = null;

            try
            {
                var fileStream = new FileStream(@"data.xml", FileMode.Open);
                xmlReader = XmlReader.Create(fileStream, new XmlReaderSettings
                {
                    CloseInput = true
                });

                var dataContractSerializer = new DataContractSerializer(typeof(T));
                return (T)dataContractSerializer.ReadObject(xmlReader);
            }
            finally
            {
                if (xmlReader != null)
                    xmlReader.Close();
            }
        }

        public PersistenzService()
        {
        }
    }
}
