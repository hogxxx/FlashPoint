
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using Unity.VisualScripting.Dependencies.Sqlite;

static class MyDataBase
{
    private const string fileName = "db.bytes";
    private static string DBPath;
    private static SqliteConnection connection;
    private static SqliteCommand command;
}