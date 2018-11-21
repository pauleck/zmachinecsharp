using Models.Datatypes;

namespace ZFileFormat.HeaderV5
{
    public class Flags1 : IZCollectionOfBools
    {
        public ZBool ColoursAvailable { get; set; }
        public ZFiller Filler1 { get; set; }
        public ZBool BoldfaceAvailable { get; set; }
        public ZBool ItalicAvailable { get; set; }
        public ZBool FixedSpaceStyleAvailable { get; set; }
        public ZFiller Filler2 { get; set; }
        public ZBool TimedKeyboardInputAvailable { get; set; }
    }

    public class Flags2 : IZCollectionOfBools
    {
        public ZBool IsTranscriptingOn { get; set; }
        public ZFiller Filler1 { get; set; }
        public ZFiller Filler2 { get; set; }
        public ZBool UsePictures { get; set; }
        public ZBool UseUndoOpcodes { get; set; }
        public ZBool UseMouse { get; set; }
        public ZBool UseColours { get; set; }
        public ZBool UseSoundEffects { get; set; }
    }

    public class Header
    {
        public ZOneByte VersionNumber { get; set; }
        public Flags1 Flags1 { get; set; }
        public ZTwoBytes BaseOfHighMemory { get; set; }
        public ZTwoBytes InitialProgramCounter { get; set; }
        public ZTwoBytes LocationDictionary { get; set; }
        public ZTwoBytes LocationObjectTable { get; set; }
        public ZTwoBytes LocationGlobalVariablesTable { get; set; }
        public ZTwoBytes StaticMemoryBase { get; set; }
        public Flags2 Flags2 { get; set; }
        public ZTwoBytes LocationAbbreviationTable { get; set; }
        public ZTwoBytes FileLength { get; set; }
        public ZTwoBytes FileChecksum { get; set; }
        public ZOneByte InterpreterNumber { get; set; }
        public ZOneByte InterpreterVersion { get; set; }
    }
}