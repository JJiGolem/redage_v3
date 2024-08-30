using MySql.Data.MySqlClient;
using Redage.SDK;
using System;
using Redage.SDK.Models;
using System.IO;

namespace NeptuneEvo.Functions
{
    class BackupSql
    {
        public static void Backup()
        {
            Main.Log.Write("Backup Starting");
            
            var config = Settings.ReadAsync("mainDB", new MysqlSettings());
            
            var connection =
                $"Host={config.Server};" +
                $"User={config.User};" +
                $"Password={config.Password};" +
                $"Database={config.DataBase};" +
                $"SslMode=None;";

            if (Directory.Exists("backups") is false)
                Directory.CreateDirectory("backups");

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        var date = DateTime.Now;
                        mb.ExportToFile($"backups/{date:dd.MM.yyyy HH.mm}.sql");
                        conn.Close();
                    }
                }
            }

            Main.Log.Write("Backup End");
        }
    }
}
