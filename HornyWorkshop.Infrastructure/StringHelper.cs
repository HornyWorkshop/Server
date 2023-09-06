﻿namespace HornyWorkshop.Server.HornyWorkshop.Infrastructure;

public class StringHelper
{
    public static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable
            .Repeat(chars, length)
            .Select(s => s[Random.Shared.Next(s.Length)])
            .ToArray());
    }
}