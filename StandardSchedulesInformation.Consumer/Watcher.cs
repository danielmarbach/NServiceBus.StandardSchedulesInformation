using System;
using System.Reactive.Linq;
using NServiceBus;
using RxFileSystemWatcher;
using StandardSchedulesInformation.Consumer.Commands;

namespace StandardSchedulesInformation.Consumer
{
    public class Watcher : IWantToRunWhenBusStartsAndStops
    {
        private FileDropWatcher watcher;
        private IDisposable droppedSubscription;

        public IBus Bus { get; set; }

        public void Start()
        {
            this.watcher = new FileDropWatcher(@"C:\droplocation", "*.snd");
            
            this.droppedSubscription = this.watcher.Dropped
                .Select(file => new ProcessFile(file.FullPath, file.Name, Guid.NewGuid()))
                .Subscribe(msg => this.Bus.SendLocal(msg));

            this.watcher.Start();
        }

        public void Stop()
        {
            this.droppedSubscription.Dispose();
            this.watcher.Stop();
            this.watcher.Dispose();
        }
    }
}