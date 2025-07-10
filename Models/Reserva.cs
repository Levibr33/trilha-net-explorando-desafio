namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            {

                if (hospedes.Count > Suite.Capacidade)
                {
                    throw new InvalidOperationException($"O número de hóspedes ({hospedes.Count}) excede a capacidade da suíte ({Suite.Capacidade}).");
                }

            }
            Hospedes = hospedes;
            Console.WriteLine("Castro feito com sucesso!");
        }

        public void CadastrarSuite(Suite suite)
        {
            if (suite == null)
            {
                throw new ArgumentNullException(nameof(suite), "A suíte não pode ser nula.");
            }

            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Suíte não cadastrada.");
            }

            decimal valTotal = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valTotal *= 0.9m;
            }

            return valTotal;
        }
    }
}