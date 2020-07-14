namespace Banking.Domain
{
    //4. Добавить класс ServiceProvider (Id, Name, ServiceType)
    public class ServiceProvider : Entity
    {
        public string ServiceName { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}