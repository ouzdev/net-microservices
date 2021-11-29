namespace CommandService.EventProcessing{

    public interface IEventProcessing{
        void ProcessEvent(string message);
    }
}