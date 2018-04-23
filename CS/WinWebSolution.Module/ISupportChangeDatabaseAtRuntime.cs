namespace WinWebSolution.Module {
    public interface ISupportChangeDatabaseAtRuntime {
        void ChangeTo(string newConnectionString);
    }
}
