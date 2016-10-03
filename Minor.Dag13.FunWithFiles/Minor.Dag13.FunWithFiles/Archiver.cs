using System.IO;

namespace Minor.Dag13.FunWithFiles
{

    public class Archiver
    {
        private string _documentsPath;
        private FileSystemWatcher _watcher;

        public Archiver(string documentsPath)
        {
            _documentsPath = documentsPath;
            _watcher = new FileSystemWatcher();
            _watcher.Path = _documentsPath;
            _watcher.Filter = "*.txt";
            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            _watcher.Created += _watcher_Created;
            _watcher.Changed += _watcher_Changed;
            _watcher.EnableRaisingEvents = true;
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            FileChangedEventCount++;
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            FileCreatedEventCount++;
        }

        public int FileCreatedEventCount { get; set; }
        public int FileChangedEventCount { get; set; }
    }

}