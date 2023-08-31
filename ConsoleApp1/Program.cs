using System.Reflection.PortableExecutable;
using System.Text;

internal enum RESOURCE_DIRECTORY_TYPE
{
    Undefined = 0,
    RT_CURSOR = 1,
    RT_BITMAP = 2,
    RT_ICON = 3,
    RT_MENU = 4,
    RT_DIALOG = 5,
    RT_STRING = 6,
    RT_FONTDIR = 7,
    RT_FONT = 8,
    RT_ACCELERATOR = 9,
    RT_RCDATA = 10,
    RT_MESSAGETABLE = 11,
    RT_GROUP_CURSOR2 = 12,
    RT_GROUP_CURSOR4 = 14,
    RT_VERSION = 16,
    RT_DLGINCLUDE = 17,
    RT_PLUGPLAY = 19,
    RT_VXD = 20,
    RT_ANICURSOR = 21,
    RT_ANIICON = 22,
    RT_HTML = 23,
    RT_MANIFEST = 24,
    RT_DLGINIT = 240,
    RT_TOOLBAR = 241,
}

internal readonly struct IMAGE_RESOURCE_DIRECTORY
{
    internal SectionCharacteristics Characteristics { get; }
    internal uint TimeDateStamp { get; }
    internal ushort MajorVersion { get; }
    internal ushort MinorVersion { get; }
    internal ushort NumberOfNamedEntries { get; }
    internal ushort NumberOfIdEntries { get; }

    internal IMAGE_RESOURCE_DIRECTORY(BinaryReader reader)
    {
        Characteristics = (SectionCharacteristics)reader.ReadUInt32();
        TimeDateStamp = reader.ReadUInt32();
        MajorVersion = reader.ReadUInt16();
        MinorVersion = reader.ReadUInt16();
        NumberOfNamedEntries = reader.ReadUInt16();
        NumberOfIdEntries = reader.ReadUInt16();
    }
}

internal readonly struct IMAGE_RESOURCE_DIRECTORY_ENTRY
{
    internal uint NameOffset { get; }
    internal uint OffsetToData { get; }

    public bool IsNameString => (NameOffset & 0x80000000) > 0;
    public uint NameAddress => NameOffset & 0x7FFFFFFF;
    public RESOURCE_DIRECTORY_TYPE NameType => IsNameString ? RESOURCE_DIRECTORY_TYPE.Undefined : (RESOURCE_DIRECTORY_TYPE)NameAddress;
    public bool IsDirectory => (OffsetToData & 0x80000000) > 0;
    public uint DirectoryAddress => OffsetToData & 0x7FFFFFFF;
    public bool IsDataEntry => !IsNameString && !IsDirectory;

    internal IMAGE_RESOURCE_DIRECTORY_ENTRY(BinaryReader reader)
    {
        NameOffset = reader.ReadUInt32();
        OffsetToData = reader.ReadUInt32();
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        using var stream = File.OpenRead("L:\\[ScrewThisNoise] Koikatsu BetterRepack RX1\\Koikatu.exe");
        using var pe = new PEReader(stream);

        var s = pe.PEHeaders.SectionHeaders.First( e => e.Name == ".rsrc");
       
        var section = pe.GetSectionData(".rsrc");
        using var reader = new BinaryReader(new MemoryStream(section.GetContent().ToArray()), Encoding.ASCII, false);
        
        var directory = new IMAGE_RESOURCE_DIRECTORY(reader);

        var entries = Enumerable.Range(0, directory.NumberOfIdEntries).Select(e => new IMAGE_RESOURCE_DIRECTORY_ENTRY(reader)).ToArray();
        var entry = entries.FirstOrDefault(e => e.NameType == RESOURCE_DIRECTORY_TYPE.RT_ICON);

        reader.BaseStream.Position = entry.DirectoryAddress;

        directory = new IMAGE_RESOURCE_DIRECTORY(reader);
        
        entries = Enumerable.Range(0, directory.NumberOfIdEntries).Select(e => new IMAGE_RESOURCE_DIRECTORY_ENTRY(reader)).ToArray();
        entry = entries.FirstOrDefault(e => e.NameType == RESOURCE_DIRECTORY_TYPE.RT_ICON);

        reader.BaseStream.Position = entry.DirectoryAddress;

        directory = new IMAGE_RESOURCE_DIRECTORY(reader);
        entries = Enumerable.Range(0, directory.NumberOfIdEntries).Select(e => new IMAGE_RESOURCE_DIRECTORY_ENTRY(reader)).ToArray();

        var q = 1;
    }
}

internal readonly struct ResourceDirectoryTable { };
