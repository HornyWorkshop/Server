namespace HornyWorkshop.Services.WorkshopService.DataTypes;

// public sealed record CreateGameInput(LangInput Name);
public sealed record CreateGameInput(LangInput Name, ICollection<IFile> Icons);
public sealed record EditGameInput(int Id, LangInput? Name, IFile? File);

public sealed record CreateTagInput(LangInput Name);
public sealed record EditTagInput(int Id, LangInput Name);

public sealed record CreateFranchiseInput(LangInput Name);
public sealed record CreatePersonInput(LangInput Name, int Franchise);

public sealed record PersonInput(LangInput Name, int Franchise);

public sealed record CardInput(LangInput Name, ICollection<int> Tags, ICollection<int> Person, ICollection<int> Franchise);
public sealed record CardVersionInput(IFile File);
