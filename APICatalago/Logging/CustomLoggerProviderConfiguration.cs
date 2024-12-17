namespace APICatalogo.Logging
{
    //Essa classe define a configuração do provedpr de log personalizado
    public class CustomLoggerProviderConfiguration
    {
        //Define o nivel minino de log a sr registrado,como padrão LogLevel.Warning
        public LogLevel LogLevel { get; set;} = LogLevel.Warning;
        //Defie o ID do evento de log, comopadrão sendo zero
        public int EventId { get; set; } = 0;
    }
}
