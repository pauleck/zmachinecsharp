using System;
using ZFileFormat.HeaderV5;
using System.IO;
using System.Reflection;
using Models.Datatypes;
using Helper;

namespace FileLoaders
{
    public class V5Loader
    {
        public string FileName {get; set; }
        public Header Header { get; set; }

        public V5Loader (string fileName)
        {
            FileName = fileName;
        }

        public void LoadFile()
        {
            //Header = new Header { VersionNumber = new ZDecimal { DecimalValue = 5 } };
            Header = new Header();

            var fileContents = File.ReadAllBytes(FileName);
            var filePosition = 0;

            foreach (var prop in typeof(Header).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                // Magic to initialize the property to it's type
                var myType = prop.PropertyType;
                var constructor = myType.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    prop.SetValue(Header, constructor.Invoke(null));
                }
                else
                {
                    prop.SetValue(Header, null);
                }

                // Now set the value!
                var instanceField = prop.GetValue(Header);
                if (instanceField is ZOneByte)
                {
                    prop.SetValue(Header, new ZOneByte { Value = fileContents[filePosition]});
                    filePosition++;
                }

                if (instanceField is IZCollectionOfBools)
                {
                    var byt = fileContents[filePosition];
                    var bitPosition = 0;

                    foreach (var boolProps in instanceField.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (boolProps.PropertyType.Name != nameof(ZFiller))
                        {
                            boolProps.SetValue(instanceField, new ZBool { B = BinaryHelpers.IsBitSet(byt, bitPosition)});
                        }
                        bitPosition++;
                    }

                    filePosition++;
                }

                if (instanceField is ZTwoBytes)
                {
                    var firstByte = fileContents[filePosition];
                    var secondByte = fileContents[filePosition+1];
                    filePosition = filePosition + 2;

                    var value = 256 * firstByte + secondByte;
                    prop.SetValue(Header, new ZTwoBytes { Value = (UInt16)value });
                }
            }
        }
    }
}