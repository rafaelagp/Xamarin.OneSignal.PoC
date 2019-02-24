namespace NotificationPusher
{
    class Program
    {
        static void Main(string[] args)
        {
            const string cargo = "";
            const string cpf = "";
            const string deviceId = "";

            //ServicoNotificacao
            //    .EnviarNotificacaoLogoutAsync(cpf, deviceId)
            //    .Wait();
            //ServicoNotificacao
            //    .EnviarNotificacaoAtualizacaoPorCargoAsync(cargo)
            //    .Wait();
            ServicoNotificacao
                .EnviarNotificacaoAtualizacaoPorCpfAsync(cpf)
                .Wait();
        }
    }
}
